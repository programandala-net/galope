\ galope/trim.fs/

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History
\ 2013-10-22 Added.

require ./minus-leading.fs

: trim ( ca1 len1 -- ca2 len2 )
  -leading -trailing
  ;

