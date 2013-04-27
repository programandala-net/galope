\ galope/randomize.fs
\ Change the random seed

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

require random.fs  \ Gforth's 'random'

: randomize
  time&date 2drop 2drop * seed !
  ;

