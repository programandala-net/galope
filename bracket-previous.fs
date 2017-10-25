\ galope/bracket-previous.fs
\ [previous]

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: [previous] ( -- ) previous ; immediate

  \ doc{
  \
  \ [previous] ( -- )
  \
  \ Transform the search order consisting of _widn .. wid2 wid1_
  \ (where _wid1_ is searched first) into _widn .. wid2_.
  \ ``[previous]`` is an immediate word.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo).
\
\ 2017-08-20: Update change log layout. Update source style.
\
\ 2017-10-25: Improve documentation.
