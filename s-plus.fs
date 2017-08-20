\ galope/s-plus.fs
\ `s+`
\ String concatenation.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Credit: Code from Gforth 0.7.3.

\ ==============================================================

[undefined] s+ [if]

: s+ {: ca1 len1 ca2 len2 -- ca3 len3 :}
  len1 len2 + allocate throw {: ca3 :}
  ca1 ca3 len1 move
  ca2 ca3 len1 + len2 move
  ca3 len1 len2 + ;

[then]

  \ doc{
  \
  \ s+ {: ca1 len1 ca2 len2 -- ca3 len3 :}
  \
  \ Create a new string _ca3 len3_ in the heap, containing the
  \ concatenation of string _ca1 len1_ (first) and string _ca2 len2_
  \ (second).
  \
  \ NOTE: ``s+`` is already included in Gforth.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-07-15: Copy from Gforth 0.7.3. This word was removed from
\ Gforth 0.7.9.
\
\ 2017-08-20: Note: `s+` has been included back in Gforth 0.7.9, which
\ is under development. Improve documentation.
