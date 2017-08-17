\ galope/rgx-wcmatch-question.fs
\ rgx-wcmatch?

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ ==============================================================

require ffl/rgx.fs

: rgx-wcmatch? ( ca len rgx -- f )
  2dup 2>r rgx-cmatch?      \ match?
  2r> 0 swap rgx-result 0=  \ start=0?
  rot rot =                 \ end=len?
  and and ;
  \ Match case-sensitive a whole string _ca len_ with the given
  \ regular expression _rgx_; return match result _f_.

\ ==============================================================
\ Change log

\ 2013-12-10 Written for an addon of Fendo
\ (http://programandala.net/en.program.fendo.html), as a complement of
\ Forth Foundation Library's rgx module.
\
\ 2017-08-17: Update change log layout. Update stack notation. Update
\ source style. Improve documentation.
