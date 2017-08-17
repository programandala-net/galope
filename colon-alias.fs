\ galope/colon-alias.fs
\ :alias

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

: :alias  ( xt ca len -- )
  \ Create an alias with the given name for the given xt.
  \ ca len = name of the new alias
  \ xt = execution token of the original word
  nextname alias
  ;
