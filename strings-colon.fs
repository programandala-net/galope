\ galope/strings-colon.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2016, 2017.

\ ==============================================================

require ./module.fs

module: galope-strings-colon-module

variable depth0

: #strings ( -- n ) depth depth0 @ - 2/ ;

: strings, ( ca'1 len'1 ... ca'n len'n n -- )
  0 ?do 2, loop ;
  \ Compile the addresses and lengths of the strings.

: last! ( dfa -- ) here [ 2 cells ] literal - swap ! ;
  \ Store the address of the last string compiled.

export

: strings: ( "name" -- a )
  create here 0 , depth depth0 !
  does> ( n -- ca len ) ( n dfa ) @ swap 2 cells * - 2@ ;

  \ doc{
  \
  \ strings: ( "name" -- a )
  \
  \ Start the definition of a constant string array, leaving the
  \ address _a_, which will hold the address of the last string
  \ compiled by `/strings`.

  \ Usage example:

  \ ----
  \ \ This example is Gforth-specific, because Gforth preserves
  \ \ all parsed strings in the heap, so their addresses are unique.
  \
  \ strings: esperanto-number

  \   s" nul"
  \   s" unu" s" du" s" tri" s" kvar" s" kvin"
  \   s" ses" s" sep" s" ok" s" naŭ" s" dek"

  \ /strings . ." strings in the array" cr
  \
  \ 0 esperanto-number type
  \ 1 esperanto-number type
  \ ----

  \ See: `2arrayed`, `2array`.
  \
  \ }doc

: /strings ( a ca'1 len'1 ... ca'n len'n -- n )
  #strings dup >r strings, ( dfa ) last! r> ;

  \ doc{
  \
  \ /strings ( a ca'1 len'1 ... ca'n len'n -- n )
  \
  \ End the definition of a constant string array, whose
  \ _a_ was left by `strings:`, compiling strings _ca'1 len'1
  \ ... ca'n len'n_ and leaving their number _n_.
  \
  \ See `strings:` for a usage example.
  \
  \ }doc

;module

\ ==============================================================
\ Change log

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
\
\ 2017-08-16: Remove the "2" suffix from the filename, after removing
\ the old version "1", which has been superseded by `2arrayed`.
\ Remove note about `;strings`, which has been removed from the
\ library.  Improve documentation. Update source style.