\ galope/strings-colon_2.fs
\ Constant string array, version 2

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2016.

\ ==============================================================

\ WARNING: This code works because Gforth creates strings in the heap
\ (the dynamically allocated memory), which is not saved in Forth
\ system images.

\ NOTE: The file <galope/strings-colon_1.fs> has a simpler version
\ that requires explicit compilation of every string with `2,`, what
\ can be an advantage if the stack is short.  The file
\ <galope/semicolon-strings.fs> defines an alternative ending.

\ ==============================================================

require ./module.fs

module: galope-strings-colon-2-module

variable depth0

: #strings  ( -- n )  depth depth0 @ - 2/  ;

: strings,  ( ca'1 len'1 ... ca'n len'n n -- )
  0 ?do  2,  loop  ;
  \ Compile the addresses and lengths of the strings.

: last!  ( dfa -- )  here [ 2 cells ] literal - swap !  ;
  \ Store the address of the last string compiled.

export

: strings:  ( "name" -- a )
  create  here  0 ,  depth depth0 !
  does>   ( n -- ca len )  ( n dfa ) @ swap 2 cells * - 2@  ;
  \ Start the definition of a constant string array, leaving the data
  \ field address _a_, that will hold the address of the last string
  \ compiled by `/strings`.

: /strings  ( a ca'1 len'1 ... ca'n len'n -- n )
  #strings dup >r strings, ( dfa ) last!  r>  ;
  \ End the definition of a constant string array, whose data field
  \ address _a_ was left by `strings:`, compiling strings _ca'1 len'1
  \ ... ca'n len'n_ and leaving their number _n_.

\ ==============================================================
\ Usage example

false [if]

strings: Esperanto-numbers

  s" nul"
  s" unu" s" du" s" tri" s" kvar" s" kvin"
  s" ses" s" sep" s" ok" s" naŭ" s" dek"

/strings . ." strings in the array" cr

[then]

;module

\ ==============================================================
\ History

\ 2013-08-30: Start.
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
\ 2014-11-17: Update module name.
\
\ 2016-08-02: Update source layout and file header.
