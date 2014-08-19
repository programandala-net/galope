\ galope/rdepth.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-02-20 Written.

: rdepth  ( -- +n )
  \ Number of values on the return stack.
  rp0 @ rp@ - cell /
  ;
