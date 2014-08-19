\ galope/seconds-to-time.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-17 Written for Finto
\ (http://programandala.net/en.program.finto.html).

: seconds>time  { seconds -- hours minutes seconds }
  seconds 3600 / dup >r  \ hours
  seconds 60 / r@ 60 * - dup  \ minutes
  60 * r> 3600 * + seconds swap -  \ seconds
  ;
