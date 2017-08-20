\ galope/scan-back.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Credit: Code from Gforth 0.7.3.

\ ==============================================================

[undefined] scan-back [if]

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
  \ NOTE: ``scan-back`` is already included in Gforth.
  \
  \ }doc

[then]

\ ==============================================================
\ Change log

\ 2017-07-26: In Gforth 0.7.3. `scan-back` was defined in
\ `forth-wordlist`, but in Gforth 0.7.9. it's defined in the `c-lib`
\ vocabulary. This module solves it.
\
\ 2017-08-20: `scan-back` has been moved back to `forth-wordlist` in
\ Gforth 0.7.9, which is under development. Therefore, an
\ `[undefined]` check is added here. Improve documentation.
