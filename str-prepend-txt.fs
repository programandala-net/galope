\ galope/str-prepend-txt.fs
\ `str-prepend-txt`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require ffl/str.fs
  \ Forth Foundation Library (http://irdvo.github.io/ffl/)

require ./str-txt-concatenation-question.fs  \ `str-txt-concatenation?`

: str-prepend-txt  ( ca len str -- )
  2dup str-txt-concatenation?
  if  bl over str-prepend-char  then  str-prepend-string  ;
  \ Prepend a text _ca len_ to a FFL's dynamic string _str_,
  \ with a space separator if needed.

\ ==============================================================
\ Change log

\ 2016-07-21: Extract from _Asalto y castigo_
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
