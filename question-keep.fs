\ galope/question-keep.fs
\ `?keep`
\ Keep a string depending on a flag

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012

\ ==============================================================

require paren-question-keep.fs  \ '(?keep)'

: ?keep  ( ca len f -- ca len | ca 0 )
  0<> (?keep)  ;
  \ Keep a string if a flag is not zero,  otherwise empty it.

\ ==============================================================
\ History

\ 2012-05-06: Refactor from an application of the author.
\ 2012-05-07: Refactor from 'question-empty.fs'.
\ 2016-07-08: Update source layout and header.
