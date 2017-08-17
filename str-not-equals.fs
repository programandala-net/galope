\ galope/str-not-equals.fs
\ str<>

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

: str<>  ( ca1 len1 ca2 len2 -- wf )
  \ Are two strings different?
  compare 0<>
  ;
