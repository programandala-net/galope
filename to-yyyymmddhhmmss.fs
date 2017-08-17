\ galope/to-yyyymmddhhmmss.fs
\ `>yyyymmddhhmmss`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014..2017.

\ ==============================================================

require ./n-to-str-plus.fs  \ `n>str+`
require ./module.fs

module: galope-to-yyyymmddhhmmss-module

: <##> ( u -- ca len ) s>d <<# # #s #> #>> ;

: <##>+ ( u ca1 len1 -- ca2 len2 ) rot <##> s+ ;

export

: >yyyymmddhhmmss ( second minute hour day month year -- ca len )
  n>str <##>+ <##>+ <##>+ <##>+ <##>+ ;
  \ Convert the given date and time to a string with the ISO format
  \ "yyyymmddhhmmss".

;module

\ ==============================================================
\ Change log

\ 2014-02-17: Extracted from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html),
\ to be reused in Finto
\ (http://programandala.net/en.program.finto.html).
\
\ 2014-02-23: Fix: Some changes done to adapt the code were wrong.
\
\ 2014-02-23: Change: The original code used a circular string buffer;
\ add '<<#' are '#>>'; rename tool words.
\
\ 2015-10-15: Update the name of the module <n-to-str.fs>.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-08-17: Update source style.
