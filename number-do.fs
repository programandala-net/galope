\ galope/number-do.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-19 Added.
\ 2012-09-14 Code reformated.

\ '#do' is common use.

: #do  ( n|u -- )
  s" 0 ?do" evaluate
  ;  immediate
