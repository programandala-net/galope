\ galope/microseconds.fs
\ microseconds

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

require ./module.fs

module: galope-microseconds-module

: overtime?  ( d -- wf )
  utime d<  ;

export

: microseconds  ( u -- )
  \ Wait a number of microseconds or until a key is pressed.
  s>d utime d+
  begin  2dup overtime? key? 0= or  until
  begin  2dup overtime? key? or     until
  2drop ;

;module

\ ==============================================================
\ Change log

\ 2012-06-18: Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).
\
\ 2012-09-24: 'time?' renamed to 'overtime?'.
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2014-11-17: Module name updated.
\
\ 2016-01-16: Updated header and layout.
\
\ 2017-08-17: Update change log layout. Update header.
