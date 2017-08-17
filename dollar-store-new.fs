\ galope/dollar-store-new.fs
\ $!new

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ 2014-11-18: Factored out from Fendo's file
\ <fendo.markup.html.attributes.fs>
\ (http://programandala.net/en.program.fendo.html).

require string.fs  \ Gforth's dynamic strings

: $!new  ( ca len a -- )
  \ Re-create a dynamic string with the given content.
  dup $off $!
  ;

