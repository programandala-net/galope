\ galope/rgx-wcmatch-question.fs
\ rgx-wcmatch?

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-12-10 Written for an addon of Fendo
\ (http://programandala.net/en.program.fendo.html), as a complement of
\ Forth Foundation Library's rgx module.

require ffl/rgx.fs

: rgx-wcmatch?  ( ca len rgx -- wf )
  \ Match case-sensitive a whole string with the given regular
  \ expression; return match result.
  \ rgx = regex id
  2dup 2>r rgx-cmatch?  \ match?
  2r> 0 swap rgx-result 0=  \ start=0?
  rot rot =  \ end=len?
  and and
  ;
