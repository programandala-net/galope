\ galope/colon-constant.fs
\ :constant

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-12-01 Added.

: :constant  ( x ca len -- )
  \ Create a 'constant' word with the given name.
  \ ca len = name of the new word
  nextname constant
  ;



