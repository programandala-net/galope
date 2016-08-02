\ galope/strings-colon_1.fs
\ Constant string array, version 1

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2016.

\ ==============================================================

\ WARNING: This code works because Gforth creates strings in the heap
\ (the dynamically allocated memory), which is not saved in Forth
\ system images.

\ NOTE: The file <galope/strings-colon_2.fs> has an improved version
\ that transparently compiles the strings.  The file
\ <galope/semicolon-strings.fs> defines an alternative ending.

\ ==============================================================

: strings:  ( "name" -- a )
  create  here
  does>   ( n -- ca len )  ( n dfa ) swap 2 cells * + 2@  ;
  \ Start the definition of a constant string array, leaving the data
  \ field address _a_ were the double-cell references to the strings
  \ will be compiled.  The strings must be compiled with '2,'.

: /strings  ( a -- n )  here swap - cell / 2/  ;
  \ End the definition of a constant string array, whose data field
  \ address _a_ was left by `strings:`, leaving the number of strings
  \ compiled in the array, _n_.

\ ==============================================================
\ Usage example

false [if]

strings: Esperanto-numbers

  s" nul" 2,
  s" unu" 2, s" du" 2, s" tri" 2, s" kvar" 2, s" kvin" 2,
  s" ses" 2, s" sep" 2, s" ok" 2, s" naŭ" 2, s" dek" 2,

/strings . ." strings in the array" cr

[then]

\ ==============================================================
\ History

\ 2013-08-30: Extract from `La isla del Coco`
\ (http://programandala.net/es.programa.la_isla_del_coco.forth.html).
\
\ 2013-11-11: Improve warning comment.
\
\ 2013-11-30: Rename file. Add note about ';strings'.
\
\ 2014-01-08: Fix header filename.
\
\ 2014-03-05: Fix typo in comment.
\
\ 2014-11-02: Fix and update comments.
\
\ 2016-08-02: Update source layout and file header.

