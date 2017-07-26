\ galope/basename.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

require ./gforth-question.fs

gforth? [if]

  also c-lib
  synonym basename basename
  previous

[else]

  \ Credit:
  \ Code from Gforth 0.7.3.

  require ./dirname.fs

  : basename ( ca1 len1 -- ca2 len2 )
    2dup dirname nip /string ;

[then]

  \ doc{
  \
  \ basename ( ca1 len1 -- ca2 len2 )
  \
  \ Return the file name _ca2 len2_ without directory component from
  \ the file name _ca1 len1_.
  \
  \ See: `dirname`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-07-26: In Gforth 0.7.3. `basename` was defined in
\ `forth-wordlist`, but in Gforth 0.7.9. it's defined in the `c-lib`
\ vocabulary. This module solves it.
