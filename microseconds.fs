\ galope/microseconds.fs
\ microseconds

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012,2016

\ Licence
\
\ You may do whatever you want with this work, so long as you
\ retain the copyright/authorship/acknowledgment/credit
\ notice(s) and this license in all redistributed copies and
\ derived works.  There is no warranty.

\ History
\
\ 2012-06-18: Taken from the Autohipnosis program
\ (http://programandala.net/es.programa.autohipnosis).
\ 2012-09-24: 'time?' renamed to 'overtime?'.
\ 2013-11-06: Changed the stack notation of flag.
\ 2014-11-17: Module name updated.
\ 2016-01-16: Updated header and layout.

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
