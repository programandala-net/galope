\ galope/to-s-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2020, 2021

\ ==============================================================

require ./nup.fs
require ./s-comma.fs

: >sconstant ( ca len "name" -- )
  nup create s, free throw
  does> ( -- ca len ) ( dfa ) count ;

  \ doc{
  \
  \ sconstant ( ca len "name" -- )
  \
  \ Copy string _ca len_ into data space and create a string constant
  \ _name_. When _name_ is later executed, it will return the address
  \ and length of the copy.
  \
  \ The original address _ca_ is supposed to had been obtained by
  \ ``allocate``. ``>sconstant`` frees region _ca len_ using ``free``.
  \
  \ See also: `sconstant`, `strings:`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2020-04-14: Start. A variant of `sconstant`.
\
\ 2021-04-29: Require `s,`, previously provided by Gforth.
