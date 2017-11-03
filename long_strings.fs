\ galope/long_strings.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

\ Credit:
\
\ These module was inspired by lina ciforth's strings
\ (http://home.hccnet.nl/a.w.m.van.der.horst/ciforth.html).

\ ==============================================================

: lplace ( a1 len1 a2 -- )
  2dup ! cell+ swap chars move ;

  \ doc{
  \
  \ lplace ( a1 len1 a2 -- )
  \
  \ Place the long string _a1 len1_ at _a2_.
  \
  \ See: `ls,`, `lcount`, `lsconstant`.
  \
  \ }doc

: ls, ( a len -- )
  here over chars cell+ allot lplace align ;

  \ doc{
  \
  \ ls, ( a len -- )
  \
  \ Reserve one cell and _len_ characters of data space and store the
  \ long string _a len_ in the space. _len_ is stored in the first
  \ cell of the space, followed by all characters.
  \
  \ See: `lplace`, `lcount`, `lsconstant`.
  \
  \ }doc

: lcount ( a1 -- a2 len )
  dup cell+ swap @ ;

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

\ 2012-04-20 First version: 'lplace', 'ls,', 'lcount' and
\ 'lsconstant'.
\
\ 2012-05-01 Some minor changes; 'chars' added.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style and stack notation.
\
\ 2017-11-03: Improve documentation.
