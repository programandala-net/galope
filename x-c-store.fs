\ galope/x-c-store.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

[undefined] xc! [if]

  defer xc!
  : u8! ( xc xca -- ) u8!+ drop ;
  ' u8! is xc!

  \ doc{
  \
  \ xc! ( xc xca -- )
  \
  \ Store xchar _xc_ at address _xca_.
  \
  \ ``xc!`` is a deferred word whose default action is ``u8!``.
  \
  \ }doc

[then]

\ ==============================================================
\ Change log

\ 2012-09-21 Added. This word is missing in the <utf-8.fs> file of
\ Gforth 0.7.0.
\
\ 2017-08-19: Update change log layout. Update source style and stack
\ notation. Document. `xc!` is still missing from Gforth 0.7.9.
