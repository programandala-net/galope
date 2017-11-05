\ galope/dollar-store-new.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

: $!new ( ca len a -- ) dup $off $! ;

  \ doc{
  \
  \ $!new ( ca len a -- )
  \
  \ Re-create a dynamic string _a_ with the given character string _ca
  \ len_. The data space used by the previous contents of the dynamic
  \ string is released.
  \
  \ See: `$empty`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-11-18: Factored out from Fendo's file
\ <fendo.markup.html.attributes.fs>
\ (http://programandala.net/en.program.fendo.html).
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-05: Improve documentation.
