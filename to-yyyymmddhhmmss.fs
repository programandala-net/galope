\ galope/to-yyyymmddhhmmss.fs
\ `>yyyymmddhhmmss`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014..2018.

\ ==============================================================

require ./n-to-str-plus.fs  \ `n>str+`
require ./package.fs

package galope-to-yyyymmddhhmmss

: <##> ( u -- ca len ) s>d <<# # #s #> #>> ;

: <##>+ ( u ca1 len1 -- ca2 len2 ) rot <##> s+ ;

public

: >yyyymmddhhmmss ( second minute hour day month year -- ca len )
  n>str <##>+ <##>+ <##>+ <##>+ <##>+ ;

  \ doc{
  \
  \ >yyyymmddhhmmss ( second minute hour day month year -- ca len )
  \
  \ Convert the given date and time, as returned by ``time&date``,
  \ into a string _ca len_ with the ISO format "yyyymmddhhmmss".
  \
  \ See: `time&date>iso`, `iso-date>extended`.
  \
  \ }doc

end-package

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
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2018-07-22: Improve documentation.
