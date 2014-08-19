\ galope/execute-latest.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-02-18: Moved from <galope/module.fs> and renamed.

: execute-latest  ( -- )
  \ Execute the interpretation semantics of the latest word created.
  latest name>int execute 
  ;
