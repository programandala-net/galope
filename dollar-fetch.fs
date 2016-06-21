\ galope/dolar-fetch.fs
\ Alternative definiton for Gforth's '$@'

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-08-30: Extracted from Fungo, by the same author.
\ 2015-02-11: Gforth 0.8 will work this way, so a check is added.

s" gforth" environment? drop s" 0.8" str< [if]

  \ Gforth < 0.8

  require string.fs  \ Gforth's dynamic strings

  warnings @  warnings off
  : $@  ( a -- ca len )
    \ Return the content of a dynamic string variable,
    \ even if it's not initialized.
    @ dup if  dup cell+ swap @  else  pad swap  then
    ;
  warnings !

[then]
