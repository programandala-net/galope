\ galope/tilde-tilde.fs

\ This file is part of Galope

\ Copyright (C) 2012,2014 Marcos Cruz (programandala.net)

\ History
\ 2012-05-19: Taken from another project of the author.
\ 2014-03-02: 'warnings' is preserved and turned off.

here ," CHECK POINT compiled in " constant ~~title
warnings @  warnings off
: ~~  ( -- )
  \ Modified version of Gforth's '~~'.
  postpone ~~title postpone count
  postpone cr postpone type
  latest postpone literal postpone .name
  postpone ~~  postpone key postpone drop
  ;  immediate
warnings !
