\ galope/n-temp-from.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./minus-cell-bounds.fs

: ntemp> ( a -- x[n] ... x[1] n )
  dup >r
  dup @ 1+ cells -cell-bounds ?do i @ [ cell negate ] literal +loop
      r> free throw ;

  \ doc{
  \
  \ ntemp> ( a -- x[n] ... x[1] n )
  \ 
  \ Retrieve _n_ items from _a_, which were stored by `n>temp`,  and
  \ also free the data space pointed by _a_, which was reserved by
  \ `n>temp` with ``allocate``.
  \
  \ The cell pointed by _a_ contains _n_, the next cell contains
  \ _x[1]_ and so on.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-12-07: First version, needed by Fendo
\ (http://programandala.net/en.program.fendo.html).
