\ galope/n-to-str.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2015,
\ 2017.

\ ==============================================================

require ./d-to-str.fs

: n>str ( n -- ca len ) s>d d>str ;

\ ==============================================================
\ Change log

\ 2013-11-26: First version.
\
\ 2014-01-29: Fix: "./" path for 'require'.
\
\ 2015-10-15: Updated filenames.
\
\ 2017-08-17: Update change log layout and source style.
