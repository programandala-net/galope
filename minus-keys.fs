\ galope/minus-keys.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History

\ 2012-09-30: Start.
\ 2014-11-17: Module name updated.

require ./module.fs

module: galope_minus-keys_module

export 

: -keys ( -- )
  \ Remove all keys in the keyboard buffer.
  begin  key?  while  key drop  repeat
  ;

;module

