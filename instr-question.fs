\ galope/instr-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-08-17 Written as 'instr'.
\ 2013-08-27 Renamed to 'instr?'; a new 'instr' is defined apart.

: instr?  ( c ca len -- wf )
  \ Is char c in string ca len?
  bounds ?do
    dup i c@ = ?dup if  unloop nip exit  then
  loop  drop false
  ;

