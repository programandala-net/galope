\ galope/char-replaced.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================

: char-replaced ( ca len c1 c2 -- )
  { to-char from-char }
  bounds ?do
    i c@ from-char = if to-char i c! then
  loop ;
  \ Replaces all ocurrences of a char in a string.
  \ ca len = string to modify
  \ c1 = char to replace with
  \ c2 = char to be replaced

\ ==============================================================
\ Change log

\ 2014-05-10 Written.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style.
