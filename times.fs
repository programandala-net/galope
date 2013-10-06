\ galope/times.fs
\ Execute an execution token several times.

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-08 Taken from:
\
\ Newsgroups: comp.lang.forth
\ From: Rob Sciuk <rob@controlq.com>
\ Date: Wed, 7 Aug 2013 18:39:48 -0400
\ Message-ID: <alpine.BSF.2.00.1308071836490.16825@yoko.controlq.com>

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
  begin   2dup -
  while   2 pick execute 1+
  repeat  2drop drop
  ;

[then]

\ Improved version; the stack is usable by the xt:

: times  ( i*x xt n -- j*x )
  \ Execute xt n times.
  { xt n }  begin  n  while  xt execute  n 1- to n  repeat
  ;

