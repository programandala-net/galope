\ galope/gforth-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

s" gforth" environment?
dup [if] nip nip [then]
constant gforth?

  \ doc{
  \
  \ gforth? ( -- f )
  \
  \ Return _true_ if the program is running on Gforth. Otherwise
  \ return _false_.
  \
  \ See: `[gforth?]`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08 Added.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
