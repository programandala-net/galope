\ galope/l-place.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ Credit:
\
\ These module was inspired by lina ciforth's strings
\ (http://home.hccnet.nl/a.w.m.van.der.horst/ciforth.html).

\ ==============================================================

: lplace ( a1 len1 a2 -- ) 2dup ! cell+ swap chars move ;

  \ doc{
  \
  \ lplace ( a1 len1 a2 -- )
  \
  \ Place the long string _a1 len1_ at _a2_.
  \
  \ See: `ls,`, `lcount`, `lsconstant`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ ----------------------------------------------
\ <long_strings.fs>

\ 2012-04-20 First version: 'lplace', 'ls,', 'lcount' and
\ 'lsconstant'.
\
\ 2012-05-01 Some minor changes; 'chars' added.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style and stack notation.

\ ----------------------------------------------
\ <l-place.fs>

\ 2017-11-03: Improve documentation. Extract from <long_strings.fs>.
