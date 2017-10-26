\ galope/instr-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: instr? ( c ca len -- f )
  bounds ?do
    dup i c@ = ?dup if unloop nip exit then
  loop drop false ;

  \ doc{
  \
  \ instr? ( c ca len -- f )
  \
  \ Is char _c_ in string _ca len_? If so, return _true_. Otherwise
  \ return _false_
  \
  \ See: `instr`, `contains?`, `hunt`, `char-count`, `char-replaced`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-17 Written as 'instr'.
\
\ 2013-08-27 Renamed to 'instr?'; a new 'instr' is defined apart.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style and stack notation.
\
\ 2017-10-25: Improve documentation.
\
\ 2017-10-26: Improve documentation.
