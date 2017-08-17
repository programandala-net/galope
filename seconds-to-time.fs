\ galope/seconds-to-time.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ ==============================================================

: seconds>time  { seconds -- hours minutes seconds }
  seconds 3600 / dup >r  \ hours
  seconds 60 / r@ 60 * - dup  \ minutes
  60 * r> 3600 * + seconds swap -  \ seconds
  ;

\ ==============================================================
\ Change log

\ 2014-02-17 Written for Finto
\ (http://programandala.net/en.program.finto.html).
\
\ 2017-08-17: Update change log layout. Update header.

