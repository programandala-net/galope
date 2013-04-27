\ galope/x-c-store.fs
\ 'xc!'

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-09-21 Added. This word is missing in the utf-8.fs file of
\ Gforth 0.7.0.

[ifundef] xc!

  defer xc!
  : u8!  ( xc a -- )
    \ Store xchar xc at address a.
    u8!+ drop
    ;
  ' u8! is xc!

[then]
