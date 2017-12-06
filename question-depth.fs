\ galope/question-depth.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: ?depth ( -- )
  depth ?dup if decimal cr .s abort" Stack imbalance" then ;

  \ doc{
  \
  \ ?depth ( -- )
  \
  \ If the stack is not empty, set ``base`` to ``decimal``,
  \ display the contents of the stack on a new line and finally
  \ abort with message "Stack imbalance".
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-12-06: Start. Copy and adapt `?depth` from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
