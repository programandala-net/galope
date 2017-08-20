\ galope/n-r-from.fs
\ nr>

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

[undefined] nr> [if]

: nr> ( -- i×n +n ) ( R: j×n +n -- )
  r> r> { a n } \ save _n_ and the return address
  n  begin  dup
     while  r> swap 1-
     repeat drop n
  a >r ; \ restore the return address

[then]

\ ==============================================================
\ Change log

\ 2013-08-10 Written after the Forth-2012 standard.
\
\ 2017-08-17: Update change log layout and source style.
