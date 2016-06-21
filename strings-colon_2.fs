\ galope/strings-colon_2.fs
\ Constant string array, version 2

\ This file is part of Galope

\ Copyright (C) 2013,2014 Marcos Cruz (programandala.net)

\ History
\ 2013-08-30: Written.
\ 2013-11-11: Warning comment improved.
\ 2013-11-30: File renamed. Note about ';strings'.
\ 2014-01-08: Fix: Header filename.
\ 2014-03-05: Typo in comment.
\ 2014-11-02: Comments fixed and updated.
\ 2014-11-17: Module name updated.

\ WARNING: This code works because Gforth creates strings in the heap
\ (the dynamically allocated memory); it is not saved in Forth system
\ images.

\ NOTE: The file <galope/strings-colon_1.fs> has a simpler version
\ that requires explicit compilation of every string with '2,', what
\ can be an advantage if the stack is short.  The file
\ <galope/semicolon-strings.fs> defines an alternative ending.

require ./module.fs

module: galope-strings-colon-2-module

variable depth0
: #strings  ( -- n )
  depth depth0 @ - 2/
  ;
: strings,  ( ca'1 len'1 ... ca'n len'n n -- )
  \ Compile the addresses and lengths of the strings.
  0 ?do  2,  loop
  ;
: last!  ( dfa -- )
  \ Store the address of the last string compiled.
  here 2 cells - swap !
  ;

export

: strings:  ( "name" -- dfa )
  \ Start the definition of a constant string array.
  \ dfa = data field address of the array,
  \   that will keep the address of the last string compiled.
  create  here  0 ,  depth depth0 !
  does>   ( n -- ca len )
    ( n dfa ) @ swap 2 cells * - 2@
  ;
: /strings  ( dfa ca'1 len'1 ... ca'n len'n -- n )
  \ End the definition of a constant string array.
  \ dfa = data field address of the array
  \ n = number of strings compiled in the array
  #strings dup >r strings, ( dfa ) last!  r>
  ;

false [if]

\ Usage example

strings: Esperanto-numbers

  s" nul"
  s" unu" s" du" s" tri" s" kvar" s" kvin"
  s" ses" s" sep" s" ok" s" naŭ" s" dek"

/strings . ." strings in the array" cr

[then]

;module
