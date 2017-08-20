\ galope/colon-dollar-variable.fs
\ String variable

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================

require ./dollar-variable.fs

: :$variable ( ca len -- ) nextname $variable ;
  \ Create a dynamic string '$variable' with the given name.
  \ ca len = name of the new variable

\ ==============================================================
\ Change log

\ 2013-12-01 Added.
\
\ 2017-08-17: Update change log layout and source style.
