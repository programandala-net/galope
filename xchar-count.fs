\ galope/xchar-count.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017, 2018.

\ ==============================================================

require ./xbounds.fs

: xchar-count ( xca len xc -- n )
  0 2swap xbounds ?do  xc@+ 3 pick = abs rot + swap
                  loop drop nip ;

  \ doc{
  \
  \ xchar-count ( xca len xc -- n )
  \
  \ Count the number of occurrences of character _xc_ in string _xca
  \ len_.
  \
  \ See: `xbounds`, `last-xchar`, `'last-xchar`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-12-06: First version.
\
\ 2015-10-13: Renamed.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2018-07-24: Improve documentation.
