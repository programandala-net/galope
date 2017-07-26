\ galope/dirname.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

require ./gforth-question.fs

gforth? [if]

  also c-lib
  synonym dirname dirname
  previous

[else]

  \ Credit:
  \ Code from Gforth 0.7.3.

  require ./scan-back.fs

  : dirname ( ca1 len1 -- ca2 len2 )
    '\' scan-back ;

[then]

  \ doc{
  \
  \ dirname ( ca1 len1 -- ca2 len2 )
  \
  \ Return the directory name _ca2 len2_ from the file name _ca1
  \ len1_, including the final "/".
  \
  \ See: `basename`, `scan-back`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-07-26: In Gforth 0.7.3. `dirname` was defined in
\ `forth-wordlist`, but in Gforth 0.7.9. it's defined in the `c-lib`
\ vocabulary. This module solves it.
