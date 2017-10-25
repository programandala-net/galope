\ galope/contains-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from Charscan library (2002-2003), public domain

\ ==============================================================

: contains? ( ca1 len1 ca2 len2 -- ca1 len1 f )
  2over 2swap search nip nip ;

  \ doc{
  \
  \ contains? ( ca1 len1 ca2 len2 -- ca1 len1 f )
  \
  \ Does a string _ca1 len1_ contains string _ca2 len2_?
  \
  \ See: `hunt`, `instr`, `instr?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-12-10 Added.
\
\ 2013-11-06 Changed the stack notation of flag.
\
\ 2017-08-17: Update change log layout. Update header.  Update stack
\ notation.
\
\ 2017-10-25: Update stack notation. Improve documentation.
