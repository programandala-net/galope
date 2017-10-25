\ galope/instr.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: instr ( c ca len -- n true | false )
  {: character address lenght :}
  address lenght bounds ?do
    [ false ] [if]  \ XXX OLD -- first version
      character i c@ = ?dup if i address - swap unloop exit then
    [else]  \ XXX NEW -- faster
      character i c@ = if i address - true unloop exit then
    [then]
  loop false ;

  \ doc{
  \
  \ instr ( c ca len -- n true | false )
  \
  \ Is char _c_ in string _ca len_? If so, return its position _n_ and
  \ _true_. Otherwise return _false_
  \
  \ See: `instr?`, `contains?`, `hunt`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-08-27 Written, based on 'instr?'.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-10-25: Improve documentation.
