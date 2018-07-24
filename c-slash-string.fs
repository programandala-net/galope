\ galope/c-slash-string.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017, 2018.

\ ==============================================================

: c/string ( ca1 len1 c -- ca1 len1 | ca2 len2 )
  >r 2dup r> scan nip - ;

  \ doc{
  \
  \ c/string ( ca1 len1 c -- ca1 len1 | ca2 len2 )
  \
  \ Return the left part _ca2 len2_ of string _ca1 len1_, before the
  \ first apperance of character _c_; if character _c_ is not found,
  \ string _ca1 len1_ is returned.
  \
  \ See: `+/string`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-11-11 Written.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2018-07-24: Improve documentation.
