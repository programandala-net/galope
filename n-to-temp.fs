\ galope/n-to-temp.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

: n>temp ( x[n] ... x[1] n -- a )
  dup 1+ dup cells allocate throw dup >r
  swap cells bounds ?do i ! cell +loop r> ;

  \ doc{
  \
  \ n>temp ( x[n] ... x[1] n -- a )
  \
  \ Remove _n+1_ items from the  data stack and store them at _a_,
  \ which is the address of a contiguous data space reserved by
  \ ``allocate``.
  \
  \ The cell pointed by _a_ contains _n_, the next cell contains
  \ _x[1]_ and so on.
  \
  \ The items can be retrieved later by `temp>n`, which also frees the
  \ data space pointed by _a_.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-12-07: First version, needed by Fendo
\ (http://programandala.net/en.program.fendo.html).
