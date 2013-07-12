\ galope/parse-name-question.fs

\ This file is part of Galope

\ Copyright (C) 2012,2013 Marcos Cruz (programandala.net)

\ History
\ 2013-07-09 Added. 

: parse-name?  ( "name" -- ca len ff )
  \ Parse the next name in the source.
  \ ca len = parsed name 
  \ ff = empty name?
  \ Typical usage:
  \   parse-name? abort" Missing name"
  parse-name dup 0=
  ;

