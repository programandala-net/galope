\ galope/slash-here.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ ==============================================================

: /here  ( a -- n )
  \ Number of memory units from a previous dictionary address.
  here swap - cell - ;

\ ==============================================================
\ Change log

\ 2014-02-13 Adapted from a similar word '<here', written by the same
\ author in 2013 for a text adventure game.
\
\ 2017-08-17: Update change log layout.
