\ galope/colon-svariable.fs
\ String variable

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

require ./svariable.fs

: :svariable  ( ca len -- )
  \ Create a string variable with the given name.
  \ ca len = name of the new variable
  nextname svariable
  ;

