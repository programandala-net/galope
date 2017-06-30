\ galope/seconds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-06-18 Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).

require ./microseconds.fs

: seconds  ( u -- )
  \ Wait a number of seconds or until a key is pressed.
  1000000 * microseconds
  ;
