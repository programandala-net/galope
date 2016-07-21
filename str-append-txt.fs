\ galope/str-append-txt.fs
\ `str-append-txt`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ ==============================================================

require ffl/str.fs
  \ Forth Foundation Library (http://irdvo.github.io/ffl/)

require ./str-txt-concatenation-question.fs  \ `str-txt-concatenation?`

\ ==============================================================

: str-append-txt  ( ca len str -- )
  2dup str-txt-concatenation?
  if  bl over str-append-char  then  str-append-string  ;
  \ Append a text _ca len_ to a FFL's dynamic string _str_,
  \ with a space separator if needed.

\ ==============================================================
\ History

\ 2016-07-21: Extract from _Asalto y castigo_
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
