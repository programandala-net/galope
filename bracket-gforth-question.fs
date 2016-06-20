\ galope/bracket-gforth-question.fs
\ [gforth?]

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016

\ Licence
\
\ You may do whatever you want with this work, so long as you
\ retain the copyright/authorship/acknowledgment/credit
\ notice(s) and this license in all redistributed copies and
\ derived works.  There is no warranty.

\ History
\
\ 2012-05-08: Added.
\ 2016-01-16: Updated header.

s" gforth" environment?
dup [if]  nip nip  [then]
constant [gforth?] immediate
