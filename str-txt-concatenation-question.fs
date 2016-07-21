\ galope/str-txt-concatenation-question.fs
\ `str-txt-concatenation?`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

\ Forth Foundation Library
\ http://irdvo.github.io/ffl/

require ffl/str.fs

\ ==============================================================

: str-txt-concatenation?  ( len str -- f )
  str-length@ 0<> swap 0<> and  ;
  \ Do a string of _len_ chars and a FFL's dynamic string _str_ need a
  \ separation space when they are concatenated?

\ ==============================================================
\ History

\ 2016-07-21: Extract from _Asalto y castigo_
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
