\ galope/parse-name-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012,2013 Marcos Cruz (programandala.net)

\ History
\ 2013-07-09 Added.
\ 2013-11-06 Changed the stack notation of flag.

: parse-name?  ( "name" -- ca len wf )
  \ Parse the next name in the source.
  \ ca len = parsed name
  \ wf = empty name?
  \ Typical usage:
  \   parse-name? abort" Missing name"
  parse-name dup 0=
  ;

