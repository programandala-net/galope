\ galope/bracket-gforth-question.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-08 Added.

s" gforth" environment?
dup [if]  nip nip  [then]
constant [gforth?] immediate

