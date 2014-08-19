\ galope/to-yyyymmddhhmmss.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-17: Extracted from Asalto y castigo
\ (http://programandala.net/es.programa.asalto_y_castigo.html), to be
\ reused in Finto (http://programandala.net/en.program.finto.html).
\ 2014-02-23: Fix: Some changes done to adapt the code were wrong.
\ 2014-02-23: Change: The original code used a circular string buffer;
\   '<<#' are '#>>' are added; tool words are renamed.

require ./number-to-string-plus.fs
require ./module.fs

module: galope_to-yyyymmddhhmmss_module

: <##>  ( u -- ca len )
  s>d <<# # #s #> #>>
  ;
: <##>+  ( u ca1 len1 -- ca2 len2 )
  rot <##> s+
  ;

export

: >yyyymmddhhmmss  ( second minute hour day month year -- ca len )
  \ Convert the given date and time to a string with the ISO format
  \ "yyyymmddhhmmss".
  n>str <##>+ <##>+ <##>+ <##>+ <##>+
  ;

;module
