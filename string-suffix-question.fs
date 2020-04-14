\ galope/string-suffix-question.fs
\ `string-suffix?`
\ Check a suffix of a string.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2020.
\
\ Based on Wil Baden's `ends?` (from Charscan, 2002-2003).

\ Note: The word `ends?` (provided by <ends-question.fs>) does the
\ same but doesn't consume the first string. 'string-suffix?' is
\ recommended.

\ ==============================================================

[undefined] string-suffix? [if]

require ./fourth.fs

: string-suffix? ( ca1 len1 ca2 len2 -- f )
  2swap dup fourth - /string  str= ;
  \ Is _ca2 len2_ the end of _ca1 len1_?

[then]

\ ==============================================================
\ Change log

\ 2012-12-10: Word inspired by Gforth's 'string-prefix?'; it's a
\ modified version of Wil Baden's 'ends?' (from Charscan, 2002-2003).
\
\ 2013-05-18: Fix typo.
\
\ 2013-11-06: Change the stack notation of flag.
\
\ 2014-03-23: Change the stack notation of strings.
\
\ 2014-05-29: Update the stack notation of strings.
\
\ 2015-10-14: Replace `compare 0=` with `str=`.
\
\ 2016-07-05: Update source layout and header.
\
\ 2017-08-17: Update change log layout.
\
\ 2020-04-14: Check whether the word is already defined. It has been
\ included in recent versions of Gforth.
