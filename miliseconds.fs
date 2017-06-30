\ galope/miliseconds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-06-18 Taken from the program Autohipnosis, by the same
\ author (http://programandala.net/es.program.autohipnosis).
\ 2012-09-14 Code reformated.

require ./microseconds.fs

: miliseconds  ( u -- )
  \ Wait a number of miliseconds or until a key is pressed.
  1000 * microseconds
  ;

