\ galope/array-search.fs

\ xxx Unfinished

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ This program is free software; you can redistribute it and/or
\ modify it under the terms of the GNU General Public License as
\ published by the Free Software Foundation; either version 2 of
\ the License, or (at your option) any later version.

\ http://gnu.org/licenses/
\ http://gnu.org/licenses/gpl.html
\ http://www.gnu.org/licenses/gpl-2.0.html

\ This program is based on:
\ -----------------------------------------------------
\ 4tH library - ROW - Copyright 2007,2009 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License
\ Generic table-search routine
\ -----------------------------------------------------

\ History
\
\ 2012-04-24: First changes to 4tH's row.4th
\
\ 2012-04-29: More changes. Number keys only. First working version.
\ 'key-drop' was refactored and defered. Testings.
\
\ 2012-09-14: Some cosmetic reformat of the code.
\
\ 2012-09-21: Typos fixed.
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2015-10-13: Renamed words.


true value end-of-array  \ fake key
defer key-found?  ( i*x a -- wf )
defer key-drop  ( i*x a wf -- a wf )  \ remove the key searched for

: number-key-found?  ( n a -- wf )
  @ =
  ;
' number-key-found? is key-found?
: number-key-drop  ( n a wf -- a wf )
  rot drop
  ;
' number-key-drop is key-drop

: array-search  ( n a u -- a' wf )
  \ n = key searched for
  \ a = address of the first key to be searched
  \ u = number of cells in every element
  \ a' = address of the found key
  \ wf = found?
  cells >r
  begin   dup @ end-of-array <> dup
  while   drop 2dup key-found? dup 0=
  while   drop r@ +
  repeat  then  rdrop key-drop
  ;

true  [if]  \ testing

marker --array-search-testing--

create array1 \ array with two fields (key and value)
3 , 300 ,
1 , 100 ,
5 , 500 ,
4 , 400 ,
2 , 200 ,
true , 1000 , \ default end of array (true) and optional default value (1000)

: test1
  5 array1 2 array-search ( a wf )  \ search for 5
  assert( dup )  \ found
  assert( over @ 5 = )  \ pointer to the found value
  2drop
  ;

test1

create array2 \ array with three fields (value1, key and value2)
3000 , 3 , 300 ,
1000 , 1 , 100 ,
5000 , 5 , 500 ,
4000 , 4 , 400 ,
2000 , 2 , 200 ,
6400 , 64 , 640 , \ custom end of array (64) and optional default values

: test2
  64 to end-of-array
  32 array2 cell+ 3 array-search  ( a wf )  \ search for a missing key (32)
  assert( dup 0= )  \ not found
  assert( over @ end-of-array = )  \ pointer to the end of array key
  2drop
  ;

test2

--array-search-testing--

[then]
