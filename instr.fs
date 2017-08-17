\ galope/instr.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ ==============================================================

: instr  ( c ca len -- n true | false )
  \ Is char c in string ca len? If so, return its position.
  { character address lenght }
  address lenght bounds ?do
    [ false ] [if]  \ first version
      character i c@ = ?dup if  i address - swap unloop exit then
    [else]  \ faster
      character i c@ = if  i address - true unloop exit then
    [then]
  loop  false
  ;

\ ==============================================================
\ Change log

\ 2013-08-27 Written, based on 'instr?'.
\
\ 2017-08-17: Update change log layout. Update header.
