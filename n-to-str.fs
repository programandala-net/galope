\ galope/n-to-str.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2015,
\ 2017, 2018.

\ ==============================================================

require ./d-to-str.fs

: n>str ( n -- ca len ) s>d d>str ;

  \ doc{
  \
  \ n>str ( n -- ca len )
  \
  \ Convert _n_ to string _ca len_.
  \
  \ See: `d>str`, `ud>str`, `c>str`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-11-26: First version.
\
\ 2014-01-29: Fix: "./" path for 'require'.
\
\ 2015-10-15: Updated filenames.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-12-04: Improve documentation.
\
\ 2018-07-24: Improve documentation.
