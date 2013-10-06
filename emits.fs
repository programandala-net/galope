\ galope/emits.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ History

\ 2013-09-02 Written.

: emits  ( c n -- )
  \ Emit the char c n times.
  0 ?do  dup emit  loop  drop
  ;
