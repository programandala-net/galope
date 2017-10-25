\ galope/row.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./xy.fs

: row ( -- u ) xy nip ;

  \ doc{
  \
  \ row ( -- u )
  \
  \ Return the current row _u_ (Y coordinate).
  \
  \ See: `column`, `xy`, `last-row`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-08 Extracted from 'xy.fs'.
\
\ 2017-08-17: Update change log layout. Update header and source
\ style.
\
\ 2017-10-25: Improve documentation.
