\ galope/constant_string_arrays_1.fs
\ Constant string array, version 1

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-30 Extracted from 'La isla del Coco', a program by the same
\ author.
\ 2013-11-11 Warning comment improved.

\ Warning: This code works because Gforth creates strings in the heap
\ (the dynamically allocated memory), that is not save in Forth system
\ images.

\ Note: The file <galope/constant_string_arrays_2.fs> has an improved
\ version that transparently compiles the strings.

: strings:  ( "name" -- dfa )
  \ Start the definition of a constant string array.
  \ The strings must be compiled with '2,'.
  create  here 
  does>   ( n -- ca len )
    ( n dfa ) swap 2 cells * + 2@
  ;
: /strings  ( dfa -- n )
  \ End the definition of a constant string array.
  \ dfa = data field address of the array, left by 'strings:'
  \ n = number of strings compiled in the array
  here swap - cell / 2/ 
  ;

false [if]

\ Usage example

strings: Esperanto-numbers

  s" nul" 2,
  s" unu" 2, s" du" 2, s" tri" 2, s" kvar" 2, s" kvin" 2,
  s" ses" 2, s" sep" 2, s" ok" 2, s" naŭ" 2, s" dek" 2,

/strings . ." strings in the array" cr

[then]

