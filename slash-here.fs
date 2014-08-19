\ galope/slash-here.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-13 Adapted from a similar word '<here', written by the same
\ author in 2013 for a text adventure game.

: /here  ( a -- n )
  \ Number of memory units from a previous dictionary address.
  here swap - cell - 
  ; 

