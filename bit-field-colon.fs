\ galope/bit-field-colon.fs
\ `bitfield:`
\ Bit fields for data structures.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2018.

\ ==============================================================

require ./package.fs
require ./n-to-str-plus.fs  \ `n>str+`

package galope-bit-field-colon

variable bitmask

1 constant first-bitmask

: next-bitmask ( -- u ) bitmask @ 1 lshift ;
  \ Update the bitmask to the next bit.

: update-bitmask ( n -- n' )
  next-bitmask ?dup 0= if  first-bitmask  then  bitmask ! ;
  \ Update the bitmask, ready for the next bit field.

: first-bitmask? ( -- f ) bitmask @ first-bitmask = ;
  \ Is the current bitmask the first one?

: get-bitmask ( n -- n' u )
  first-bitmask? cell and + bitmask @ ;
  \ Get the current bitmask _u_. If _u_ is the first bitmask,
  \ update the cell offset _n_.

public

: begin-bitfields ( n1 "name" -- ca len n1 n2 )
  parse-name save-mem
  rot aligned dup cell -  first-bitmask bitmask ! ;

  \ doc{
  \
  \ begin-bitfields ( n1 "name" -- ca len n1 n2 )
  \
  \ Begin a set of bitfields called _name_ that starts at the offset
  \ _n1_ in the data structure, leaving _name_ in the preserved
  \ string _ca len_. _n2_ is used to calculate the length of the
  \ bitfields set at the end.
  \
  \ See also: `end-bitfields`, `bitfield:`.
  \
  \ }doc

: end-bitfields ( ca len n1 n2 -- n3 )
  2swap nextname over - cell+ dup >r +field r> ;

  \ doc{
  \
  \ end-bitfields ( ca len n1 n2 -- n3 )
  \
  \ End a set of bitfields with name _ca len_ that starts at the
  \ offset _n1_ in the data structure and ends at offset _n2_, leaving
  \ the length of the bitfields set _n3_ in address units.
  \
  \ See also: `begin-bitfields`.
  \
  \ }doc

: bitfield: ( n "name" -- n' )
  create get-bitmask over 2, update-bitmask
  does> ( a -- u a' ) ( a dfa ) 2@ rot + ;

  \ doc{
  \
  \ bitfield: ( n "name" -- n' )
  \
  \ Create a bit field _name_ in a bit-field set started by
  \ `begin-bitfields` in a data structure, with offset _n_ from the
  \ start of the datea structure.  When executed, ``name`` will return
  \ its bit-field identifier _u a_, ie. bitmask _u_ and the address
  \ _a_ that holds the bit.
  \
  \ }doc

: bit-on ( u a -- ) dup @ rot or swap ! ;

  \ doc{
  \
  \ bit-on ( u a -- )
  \
  \ Turn a bit field _u a_ on.
  \
  \ See also: `bit-off`, `begin-bitfields`, `bitfield:`, `bit!`,
  \ `bit@`.
  \
  \ }doc

: bit-off ( u a -- ) dup @ rot invert and swap ! ;

  \ doc{
  \
  \ bit-off ( u a -- )
  \
  \ Turn a bit field _u a_ off.
  \
  \ See also: `bit-on`, `begin-bitfields`, `bitfield:`, `bit!`,
  \ `bit@`.
  \
  \ }doc

: bit! ( f u a -- ) rot if bit-on exit then bit-off ;

  \ doc{
  \
  \ bit! ( f u a -- )
  \
  \ Store _f_ in a bit field _u a_.
  \
  \ See also: `bit@`, `begin-bitfields`, `bitfield:`, `bit-on`,
  \ `bit-off`.
  \
  \ }doc

: bit@ ( u a -- f ) @ and 0<> ;

  \ doc{
  \
  \ bit@ ( u a -- f )
  \
  \ Fetch _f_ from bit field _u a_.  Store _f_ in a bit field _u a_.
  \
  \ See also: `bit!`, `begin-bitfields`, `bitfield:`, `bit-on`,
  \ `bit-off`.
  \
  \ }doc

end-package

\ ==============================================================
\ Usage example

\ ----
\ 0
\   field: thing>something
\   begin-bitfields
\     bitfield: thing>flag0
\     bitfield: thing>flag1
\     bitfield: thing>flag2
\   end-bitfields
\   field: thing>other
\ constant /thing
\ ----

\ ==============================================================
\ Debug tests

false [if]

\ cr %10000000000000000000000000000000 .
\ cr s" max-n" environment? drop . key drop
\ cr s" max-u" environment? drop u. key drop
\ quit

0
  field: cf00
  field: cf01
  field: cf02
  begin-bitfields the-bitfields
    bitfield: bf00
    bitfield: bf01
    bitfield: bf02
    bitfield: bf03
    bitfield: bf04
    bitfield: bf05
    bitfield: bf06
    bitfield: bf07
    bitfield: bf08
    bitfield: bf09
    bitfield: bf10
    bitfield: bf11
    bitfield: bf12
    bitfield: bf13
    bitfield: bf14
    bitfield: bf15
    bitfield: bf16
    bitfield: bf17
    bitfield: bf18
    bitfield: bf19
    bitfield: bf20
    bitfield: bf21
    bitfield: bf22
    bitfield: bf23
    bitfield: bf24
    bitfield: bf25
    bitfield: bf26
    bitfield: bf27
    bitfield: bf28
    bitfield: bf29
    bitfield: bf30
cr .( about to define bf31)
    bitfield: bf31
 cr .( about to define bf00-2)
    bitfield: bf00-2
\    bitfield: bf01-2
    \ bitfield: bf03-2
  end-bitfields
  field: cf03

constant /thing

[then]

\ ==============================================================
\ Change log

\ 2016-06-23: Extract from the project "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html)
\ in order to reuse it in other projects. Improve with some name
\ changes. Translate comments.
\
\ 2016-06-26: Update header.
\
\ 2016-07-02: Rewrite. Improve with `begin-bitfields` and
\ `end-bitfields`.
\
\ 2016-07-03: Make `bitfields-name` configurable, in case the
\ application needs to manipulate all bitfields as a whole (for
\ example, por saving and restoring them). Fix calculation of offset.
\
\ 2016-07-05: Make `begin-bitfields` parse the name of the bit fields
\ set. Make `end-bitfields` return the length of the bit fields set.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-11-28: Update source style. Improve documentation.
\
\ 2018-12-19: Fix documentation.
