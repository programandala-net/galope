\ galope/long_strings.fs
\ Long strings

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ These module was inspired by lina ciforth's strings
\ (http://home.hccnet.nl/a.w.m.van.der.horst/ciforth.html).

\ History

\ 2012-04-20 First version: 'lplace', 'ls,', 'lcount' and
\ 'lsconstant'.

\ 2012-05-01 Some minor changes; 'chars' added.

\ Todo

\ 'ls"', 'lsliteral'.
\ Alternative common heap version of 'lsconstant' with defered kernel.

: lplace ( a1 u1 a2 -- )
  2dup ! cell+ swap chars move
  ;
: ls, ( a u -- )
  here over chars cell+ allot lplace align
  ;
: lcount ( a1 -- a2 u )
  dup cell+ swap @
  ;
: lsconstant (  a1 u "name" -- )
  create ls,
  does> ( pfa -- a2 u ) lcount
  ;
