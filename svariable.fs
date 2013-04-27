\ galope/svariable.fs
\ String variable

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

: svariable  ( "name" -- )
  \ Create a string variable.
  create 0 c,
  [
    s" /COUNTED-STRING" environment? 0=
    [if] 255 [then] chars
  ] literal allot align
  ;
