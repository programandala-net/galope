\ galope/dollar-store-comma.fs
\ $!,

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

: $!, ( ca len -- ) here cell allot $! ;
  \ Compile a dynamic string.

\ ==============================================================
\ Change log

\ 2013-07-12 Added. Taken from Fendo's file
\ <fendo_markup_wiki.fs>
\ (http://programandala.net/en.program.fendo)
\
\ 2017-08-17: Update change log layout and source style.
