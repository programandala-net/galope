\ galope/colon-alias.fs
\ :alias

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: :alias  ( xt ca len -- ) nextname alias ;
  \ Create an alias with the given name for the given xt.
  \ ca len = name of the new alias
  \ xt = execution token of the original word

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo).
\
\ 2017-08-20: Update change log layout.
