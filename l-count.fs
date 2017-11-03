\ galope/l-count.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ Credit:
\
\ These module was inspired by lina ciforth's strings
\ (http://home.hccnet.nl/a.w.m.van.der.horst/ciforth.html).

\ ==============================================================

: lcount ( a1 -- a2 len ) dup cell+ swap @ ;

  \ doc{
  \
  \ lcount ( a1 -- a2 len )
  \
  \ Return the long string _a2 len_ for the counted long string stored
  \ at _a1_.
  \
  \ See: `ls,`, `lplace`, `lsconstant`.
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
