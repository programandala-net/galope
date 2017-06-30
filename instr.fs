\ galope/instr.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-08-27 Written, based on 'instr?'.

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
