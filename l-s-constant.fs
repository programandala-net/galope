\ galope/l-s-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ Credit:
\
\ These module was inspired by lina ciforth's strings
\ (http://home.hccnet.nl/a.w.m.van.der.horst/ciforth.html).

\ ==============================================================

require ./l-s-comma.fs
require ./l-count.fs

: lsconstant (  a len "name" -- )
  create ls,
  does> ( -- a2 len ) ( dfa ) lcount ;

  \ doc{
  \
  \ lsconstant (  a len "name" -- )
  \
  \ Store the long string _a len_ in data space.  Create a definition
  \ _name_ that will return _a len_.
  \
  \ See: `ls,`, `lcount`, `lplace`.
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
