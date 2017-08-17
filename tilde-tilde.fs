\ galope/tilde-tilde.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012,2014 Marcos Cruz (programandala.net)

\ ==============================================================

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

\ ==============================================================
\ Change log

\ 2012-05-19: Taken from another project of the author.
\
\ 2014-03-02: 'warnings' is preserved and turned off.
\
\ 2017-08-17: Update change log layout.
