\ galope/dirname.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Credit: Code from Gforth 0.7.3.

\ ==============================================================

[undefined] dirname [if]

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
  \ NOTE: ``dirname`` is already included in Gforth.
  \
  \ See: `basename`, `scan-back`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-07-26: In Gforth 0.7.3. `dirname` was defined in
\ `forth-wordlist`, but in Gforth 0.7.9. it's defined in the `c-lib`
\ vocabulary. This module solves it.
\
\ 2017-08-20: `dirname` has been moved to `forth-wordlist` in Gforth
\ 0.7.9, which is under development. Therefore, an `[undefined]` check
\ is added here. Improve documentation.
