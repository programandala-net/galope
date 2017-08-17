\ galope/long_strings.fs
\ Long strings

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ Credit:
\
\ These module was inspired by lina ciforth's strings
\ (http://home.hccnet.nl/a.w.m.van.der.horst/ciforth.html).

\ ==============================================================

\ XXX TODO -- 'ls"', 'lsliteral'.
\ XXX TODO -- Alternative common heap version of 'lsconstant' with defered kernel.

: lplace ( a1 len1 a2 -- )
  2dup ! cell+ swap chars move ;

: ls, ( a len -- )
  here over chars cell+ allot lplace align ;

: lcount ( a1 -- a2 len )
  dup cell+ swap @ ;

: lsconstant (  a1 len "name" -- )
  create ls,
  does> ( -- a2 len ) ( pfa ) lcount ;

\ ==============================================================
\ Change log

\ 2012-04-20 First version: 'lplace', 'ls,', 'lcount' and
\ 'lsconstant'.
\
\ 2012-05-01 Some minor changes; 'chars' added.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style and stack notation.
