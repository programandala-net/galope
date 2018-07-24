\ galope/plus-slash-string.fs
\ +/string

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017, 2018.

\ ==============================================================

: +/string ( ca1 len1 -- ca2 len2 ) 1 /string ;

  \ doc{
  \
  \ +/string ( ca1 len1 -- ca2 len2 )
  \
  \ Step forward by one character in a buffer defined by address _ca1
  \ len1_. _ca2 len2_ is the remaining buffer after stepping over the
  \ first character in the buffer.
  \
  \ ``+/string`` is equivalent to ``1 /string``.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2018-07-24: Rewrite with `/string`. Improve documentation.
