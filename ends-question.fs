\ galope/ends-question.fs
\ `ends?`
\ Check a suffix of a string.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.
\ Based on Wil Baden's `ends?` (from Charscan, 2002-2003).

\ Note: There's a similar word `string-suffix?` (provided by
\ <string-suffix-question.fs>) that consumes all parameters, what
\ makes it recommended.

\ ==============================================================

require ./fourth.fs

: ends? ( ca1 len1 ca2 len2 -- ca1 len1 f )
  2over  dup fourth - /string str=  ;
  \ Is _ca2 len2_ the end of _ca1 len1_?

\ ==============================================================
\ Change log

\ 2012-12-10: Copied and modified from Charscan by Wil Baden (2002-2003).
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2014-05-29: Changed the stack notation of strings. Note about
\ 'string-suffix?'.
\
\ 2016-07-05: Update source layout and header. Replace `compare 0=`
\ with `str=`.
\
\ 2017-08-17: Update change log layout.
