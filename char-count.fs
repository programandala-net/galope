\ galope/char-count.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

: char-count ( ca len c -- n )
  0 2swap bounds ?do over i c@ = abs + loop nip ;

  \ doc{
  \
  \ char-count ( ca len c -- n )
  \
  \ Count the number of occurrences of character _c_ in string _ca
  \ len_.
  \
  \ See: `instr`, `instr?`, `char-replaced`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-06: First version.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-26: Improve documentation.
