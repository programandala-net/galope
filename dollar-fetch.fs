\ galope/dolar-fetch.fs
\ Alternative definiton for Gforth's '$@'

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2015, 2017.

\ ==============================================================

s" gforth" environment? drop s" 0.8" str< [if]

  \ Gforth < 0.8

  require string.fs  \ Gforth's dynamic strings

  warnings @  warnings off

  : $@ ( a -- ca len )
    @ dup if dup cell+ swap @ else pad swap then ;
    \ Return the content of a dynamic string variable,
    \ even if it's not initialized.

  warnings !

[then]

\ ==============================================================
\ Change log

\ 2013-08-30: Extracted from Fungo, by the same author.
\
\ 2015-02-11: Gforth 0.8 will work this way, so a check is added.
\
\ 2017-08-17: Update change log layout and source style.
