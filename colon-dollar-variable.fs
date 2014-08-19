\ galope/colon-dollar-variable.fs
\ String variable

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-12-01 Added.

require ./dollar-variable.fs

: :$variable  ( ca len -- )
  \ Create a dynamic string '$variable' with the given name.
  \ ca len = name of the new variable
  nextname $variable
  ;


