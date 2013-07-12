\ galope/microseconds.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-06-18 Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).
\ 2012-09-24 'time?' renamed to 'overtime?'.

require ./module.fs

module: galope_microseconds

: overtime?  ( d -- ff )
  utime d<
  ;

export 

: microseconds  ( u -- )
  \ Wait a number of microseconds or until a key is pressed.
  s>d utime d+
  begin  2dup overtime? key? 0= or  until
  begin  2dup overtime? key? or     until
  2drop
  ;

;module
