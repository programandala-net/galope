\ galope/times.fs
\ Execute an execution token several times.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ Credit:
\   Original code from:
\   Newsgroups: comp.lang.forth
\   From: Rob Sciuk (rob at controlq dot com)
\   Date: Wed, 7 Aug 2013 18:39:48 -0400
\   Message-ID: <alpine.BSF.2.00.1308071836490.16825@yoko.controlq.com>

\ ==============================================================

0 [if]

\ Original MiniForth code:

: times  ( xt n -- )
  0 begin  over over -
    while  3 pick execute ++
    repeat drop drop drop ;
  \ Execute _xt_ _n_ times.

[then]

0 [if]

\ Converted to Gforth:

: times ( xt n -- )
  0 begin  2dup <>
    while  2 pick execute 1+
    repeat 2drop drop ;
  \ Execute _xt_ _n_ times.

[then]

0 [if]

\ Improved version: the stack is usable by the xt:

: times ( i*x xt n -- j*x )
  { xt n } begin  n
           while  xt execute n 1- to n
           repeat ;

[then]

0 [if]

\ Alternative version without locals.

require ./package.fs

package galope-times

variable times-count
variable times-xt

public

: times  ( i*x xt n -- j*x )
  times-count ! times-xt !
  begin  times-count @
  while  times-xt perform  -1 times-count +!
  repeat ;
  \ Execute _xt_ _n_ times.

end-package

[then]

0 [if]

\ 2015-10-15: Alternative version without locals or variables.

: times ( i*x xt n -- j*x )
  2>r begin  2r> 1- 2dup 2>r
      while  execute
      repeat drop 2rdrop ;
  \ Execute _xt_ _n_ times.

[then]

: times ( i*x xt n -- j*x )
  swap { xt } 0 ?do xt execute loop ;

  \ doc{
  \
  \ times ( i*x xt n -- j*x )
  \
  \ Execute _xt_ _n_ times.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-08: Code taken from:
\
\ Newsgroups: comp.lang.forth
\ From: Rob Sciuk (rob at controlq dot com)
\ Date: Wed, 7 Aug 2013 18:39:48 -0400
\ Message-ID: <alpine.BSF.2.00.1308071836490.16825@yoko.controlq.com>

\ 2015-01-29: Alternative version without locals.
\
\ 2015-10-15: Alternative version without locals or variables.
\
\ 2017-08-18: Use `package` instead of `module:`. Update source style.
\ Document. Write a simpler version with `?do`.
