\ galope/search-array.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2015, 2017.

\ ==============================================================
\ License

\ This program is free software; you can redistribute it and/or
\ modify it under the terms of the GNU General Public License as
\ published by the Free Software Foundation; either version 2 of
\ the License, or (at your option) any later version.
\ See http://www.gnu.org/licenses/gpl-2.0.html.

\ ==============================================================
\ Credit

\ This program is based on:

\ -----------------------------------------------------
\ 4tH library - ROW - Copyright 2007,2009 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License
\ Generic table-search routine
\ -----------------------------------------------------

\ Website of 4tH: thebeez.home.xs4all.nl/4tH/

\ ==============================================================

true value end-of-array

  \ doc{
  \
  \ end-of-array ( -- x )
  \
  \ A variable defined by ``value`` and used by `search-array` as a
  \ fake key that is used as end-of-array marker.  It can be
  \ configured by the application. Its default value is _true_.
  \
  \ }doc

defer array-key? ( i*x a -- f )

  \ doc{
  \
  \ array-key? ( i*x a -- f )
  \
  \ Is key value _i*x_ identical to the key stored at _a_?
  \
  \ ``array-key?`` is used by `search-array`; it's a deferred word whose
  \ default action is ``(array-key?)``.  The default action can be
  \ restored by `reset-search-array`.
  \
  \ See: `drop-array-key`.
  \
  \ }doc

defer drop-array-key ( i*x a f -- a f )

  \ doc{
  \
  \ drop-array-key ( i*x a f -- a f )
  \
  \ Remove key vaule _i*x_ from the stack.
  \
  \ ``drop-array-key`` is used by `search-array`; it's a deferred word whose
  \ default action is ``(drop-array-key)``.  The default action can be
  \ restored by `reset-search-array`.
  \
  \ See: `array-key?`.
  \
  \ }doc

: (array-key?) ( x a -- f ) @ = ;

  \ doc{
  \
  \ (array-key?) ( x a -- f )
  \
  \ Is key value _x_ identical to the key stored at _a_?
  \
  \ Default action of `array-key?`, which is used by `search-array`.
  \ This default action can be restored by `reset-search-array`.
  \
  \ }doc

: (drop-array-key) ( x a f -- a f ) rot drop ;

  \ doc{
  \
  \ (drop-array-key) ( x a f -- a f )
  \
  \ Default action of `drop-array-key`, which is used by `search-array`.
  \ This default action can be restored by `reset-search-array`.
  \
  \ }doc

: reset-search-array ( -- )
  ['] (array-key?) is array-key?
  ['] (drop-array-key) is drop-array-key ;

  \ doc{
  \
  \ reset-search-array ( -- )
  \
  \ Reset the default values of `drop-array-key` and `array-key?`, which are
  \ used by `search-array`.
  \
  \ }doc

reset-search-array

: search-array ( x a u -- a' f )
  cells >r
  begin   dup @ end-of-array <> dup
  while   drop 2dup array-key? dup 0=
  while   drop r@ +
  repeat  then  rdrop drop-array-key ;

  \ doc{
  \
  \ search-array ( x a u -- a2 f )
  \
  \ Search an array for key _x_. The array has _u_ cells in every
  \ item.  The searching starts at _a_, which is the address of a key
  \ in the array.
  \
  \ If key _x_ is found, return its address _a2_ _true_; otherwise
  \ return _false_ and _a2_ is the address of the last key searched.
  \
  \ NOTE: The deferred words `drop-array-key` and `array-key?` can be
  \ configured by the application, in order to make them
  \ suitable for the structure of the array (size of items and
  \ position of keys). Their default action works with single-cell
  \ keys.
  \
  \ Usage example:
  \ ----

  \ create array1
  \   \ Array with two single-cell fields (key and value).
  \    3 , 300 ,
  \   10 , 100 ,
  \    5 , 500 ,
  \   end-of-array , 1000 , \ default value
  \ 10 array1 2 search-array ( a f )  \ search for key 10

  \ 0 to end-of-array
  \ create array2
  \   \ An array with three fields (value1, key and value2).
  \   3000 , 3 , 300 ,
  \   1000 , -1 , 100 ,
  \   4000 , 4 , 400 ,
  \   6400 , end-of-array , 640 , \ default values
  \ 4 array2 cell+ 3 search-array ( a f )  \ search for key 4

  \ ----
  \
  \ }doc

\ ==============================================================

false [if]  \ testing

marker --search-array-testing--

create array1
  \ Array with two single-cell fields (key and value).
  3 , 300 ,
  1 , 100 ,
  5 , 500 ,
  4 , 400 ,
  2 , 200 ,
  end-of-array , 1000 , \ default value

: test1
  5 array1 2 search-array ( a f )  \ search for 5
  assert( dup )  \ found
  assert( over @ 5 = )  \ pointer to the found value
  2drop
  ;

test1

  4 array1 2 search-array cr .( Found:     ) . .
123 array1 2 search-array cr .( Not found: ) . .

64 to end-of-array

create array2
  \ An array with three fields (value1, key and value2).
  3000 , 3 , 300 ,
  1000 , -1 , 100 ,
  5000 , 5 , 500 ,
  4000 , 4 , 400 ,
  2000 , 2 , 200 ,
  6400 , end-of-array , 640 , \ default values

: test2
  64 to end-of-array

  \ 32 array2 cell+ 3 search-array ( a f )  \ search for a missing key (32)
  \ assert( dup 0= )  \ not found
  \ assert( over @ end-of-array = )  \ pointer to the end of array key

  4 array2 cell+ 3 search-array ( a f )  \ search for a missing key (32)
  cr .s
  2drop ;

test2

--search-array-testing--

[then]

\ ==============================================================
\ Change log

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
\
\ 2017-08-17: Update change log layout.  Update stack notation.
\
\ 2017-11-06: Rename `array-search` `search-array`. Rename `key-drop`
\ `drop-array-key`. Rename `key-found?` `array-key?`. Improve
\ documentation. Update the source code style.
