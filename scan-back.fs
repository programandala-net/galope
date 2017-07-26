\ galope/scan-back.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

require ./gforth-question.fs

gforth? [if]

  also c-lib
  synonym scan-back scan-back
  previous

[else]

  \ Credit:
  \ Code from Gforth 0.7.3.

  : scan-back {: ca len1 c -- ca len2 :}
    ca 1- ca len1 + 1- u-do
    i c@ c = if
      ca i over - 1+ unloop exit endif
    1 -loop
    ca 0 ;

[then]

  \ doc{
  \
  \ scan-back ( ca len1 c -- ca len2 )
  \
  \ The last occurence of _c_ in _ca len1_ is at _len2-1_; if it does
  \ not occur, __len2__=0.
  \
  \ }doc

[then]

\ ==============================================================
\ Change log

\ 2017-07-26: In Gforth 0.7.3. `scan-back` was defined in
\ `forth-wordlist`, but in Gforth 0.7.9. it's defined in the `c-lib`
\ vocabulary. This module solves it.
