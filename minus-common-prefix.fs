\ galope/minus-common-prefix.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./both-lengths.fs

: -common-prefix ( ca1 len1 ca2 len2 -- ca3 len3 ca4 len4 )
  0 0 {: prefix-length char1 :}
  both-lengths min 0 ?do
    2swap over i chars + c@ to char1
    2swap over i chars + c@    char1 <> if leave then
    i 1+ to prefix-length
  loop prefix-length /string 2swap
       prefix-length /string 2swap ;

  \ doc{
  \
  \ -common-prefix ( ca1 len1 ca2 len2 -- ca3 len3 ca4 len4 )
  \
  \ Remove the prefix which is common to strings _ca1 len1_ and _ca2
  \ len2_, returning their corresponding endings _ca3 len3_ and _ca4
  \ len4_.
  \
  \ WARNING: This word does not work with multi-byte characters.
  \
  \ See: `-prefix`, `common-prefix`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-09-27: Start.
\
\ 2018-12-21: Improve documentation.
\
\ 2018-12-22: Update documentation.

