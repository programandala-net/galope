\ galope/char-replaced.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

: char-replaced ( ca len c1 c2 -- )
  {: to-char from-char :}
  bounds ?do
    i c@ from-char = if to-char i c! then
  loop ;

  \ doc{
  \
  \ char-replaced ( ca len c1 c2 -- )
  \
  \ Replaces all ocurrences of character _c2_ in string _ca len_
  \ with character _c1_.
  \
  \ See: `instr`, `instr?`, `char-count`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-05-10 Written.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
\
\ 2017-10-26: Improve documentation. Update locals notation.
