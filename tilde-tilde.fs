\ galope/tilde-tilde.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-19 Taken from another project of the author.

here ," CHECK POINT compiled in " constant ~~title
: ~~
  \ Modified version of Gforth's '~~'.
  postpone ~~title postpone count
  postpone cr postpone type
  latest postpone literal postpone .name
  postpone ~~  postpone key postpone drop
  ;  immediate

