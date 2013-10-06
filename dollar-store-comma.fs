\ galope/dollar-store-comma.fs
\ $!,

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-12 Added. Taken from Fendo's file
\ <fendo_markup_wiki.fs>
\ (http://programandala.net/en.program.fendo)

require string.fs  \ Gforth's dynamic strings

: $!,  ( ca len -- )
  \ Compile a dynamic string.
  here cell allot $!
  ;
