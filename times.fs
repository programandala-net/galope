\ galope/times.fs
\ Execute an execution token several times.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-08-08: Code taken from:
\
\ Newsgroups: comp.lang.forth
\ From: Rob Sciuk (rob at controlq dot com)
\ Date: Wed, 7 Aug 2013 18:39:48 -0400
\ Message-ID: <alpine.BSF.2.00.1308071836490.16825@yoko.controlq.com>

\ 2015-01-29: Alternative version without locals.
\ 2015-10-15: Alternative version without locals or variables.

0 [if]

\ Original MiniForth code:

: times  ( xt n -- )
  \ Execute xt n times.
  0
  begin   over over -
  while   3 pick execute ++
  repeat  drop drop drop
  ;

[then]

0 [if]

\ Converted to Gforth:

: times  ( xt n -- )
  \ Execute xt n times.
  0
  begin   2dup <>
  while   2 pick execute 1+
  repeat  2drop drop
  ;

[then]


1 [if]

\ Improved version: the stack is usable by the xt:

: times  ( i*x xt n -- j*x )
  \ Execute xt n times.
  { xt n }  begin  n  while  xt execute  n 1- to n  repeat
  ;

[then]

0 [if]

\ Alternative version without locals.

require ./module.fs

module: galope-times-module

variable times-count
variable times-xt

export

: times  ( i*x xt n -- j*x )
  \ Execute xt n times.
  times-count !  times-xt !
  begin  times-count @
  while  times-xt perform  -1 times-count +!
  repeat
  ;

;module
[then]

0 [if]

\ 2015-10-15:
\ Alternative version without locals or variables.

variable times-count
variable times-xt

: times  ( i*x xt n -- j*x )
  \ Execute xt n times.
  2>r
  begin   2r> 1- 2dup 2>r
  while   execute
  repeat  drop 2rdrop
  ;

[then]
