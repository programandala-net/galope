\ galope/dollar-comma.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

: $, ( ca len -- ) align here 0 , $! ;

  \ doc{
  \
  \ $, ( ca len -- )
  \
  \ Reserve one cell of data space and store string _ca len_ in the
  \ cell as a dynamic string.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-12 Added. Taken from Fendo's file
\ <fendo_markup_wiki.fs>
\ (http://programandala.net/en.program.fendo)
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-10-30: Fix. Rename `$!,` `$,`.
