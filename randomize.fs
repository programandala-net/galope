\ galope/randomize.fs
\ Change the random seed

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2013-08-30 Change: 'utime' instead of 'time&date'.

require random.fs  \ Gforth's 'random'

: randomize
  \ time&date 2drop 2drop * seed !
  utime * seed !
  ;

