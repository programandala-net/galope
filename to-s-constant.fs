\ galope/to-s-constant.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2020

\ ==============================================================

require ./nup.fs

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

\ 2012-05-01: Extracted from and application of the author.
\
\ 2014-11-02: Change: Stack comments.
\
\ 2017-08-17: Update change log layout. Update source style and stack
\ notation.
\
\ 2017-11-04: Rename module after the general convention, ie.
\ <s-constant.fs>.
\
\ 2017-11-19: Improve documentation.
