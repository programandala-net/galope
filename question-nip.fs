\ galope/question-nip.fs
\ ?nip

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

: ?nip ( false | x non-false -- f ) dup if nip then ;
  \ Discard the second element on the stack if top of stack is not
  \ false. Leave the top of stack unchanged.

\ ==============================================================
\ Change log

\ 2013-12-31 Added.
\
\ 2017-08-17: Update change log layout and source style.
