\ galope/gcd.fs
\ `gcd`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Will Baden, 1986-04-10.

\ ==============================================================

: gcd ( n1 n2 -- n3 ) begin ?dup while tuck mod repeat ;

  \ doc{
  \
  \ gcd ( n1 n2 -- n3 )
  \
  \ Return the greatest common divisor _n3_ of _n1_ and _n2_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-29: Copy from code found on 2015-12-13 in
\ <http://atariwiki.strotmann.de/wiki/Wiki.jsp?page=Local%20Variables>.
\
\ 2017-08-17: Update change log layout. Update source style.
\
\ 2017-11-28: Improve documentation.
