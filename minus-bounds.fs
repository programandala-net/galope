\ galope/minus-bounds.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

: -bounds ( ca1 len1 -- ca1 ca2 ) 2dup + 1- nip ;

  \ doc{
  \
  \ -bounds ( ca1 len1 -- ca1 ca2 )
  \
  \ Convert character string _ca1 len1_ to the parameters _ca1 ca2_
  \ needed by a ``do ... -1 +loop``, being _ca2_ the address of the
  \ last character of the string, in order to examine that string in
  \ reverse order, character by character.
  \
  \ See: `-cell-bounds`.
  \
  \ }doc

  \ XXX OLD
  \
  \  over 1- >r + 1- r> swap  \ This variant works with '1 -loop'
  \
  \ `do ... 1 -loop` does not work the same way in Gforth and can not
  \ be used with this '-bounds'.

\ ==============================================================
\ Change log

\ 2013-07-11: Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\
\ 2014-11-09: New: Comment about '-loop' in Gforth.
\
\ 2017-08-17: Update change log layout, header and source style.
\
\ 2017-11-04: Fix stack comment. Improve documentation.
