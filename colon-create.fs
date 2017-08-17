\ galope/colon-create.fs
\ :create

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)

: :create  ( ca len -- )
  \ Create a 'create' word with the given name.
  \ ca len = name of the new word
  nextname create
  ;


