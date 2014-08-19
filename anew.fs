\ galope/anew.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-18 Added.

\ Taken from ToolBelt 2002 by Wil Baden.

require ./possibly.fs

\  anew  ( "name" -- ) ( run: -- )

\ Compiler directive used in the form: 'anew _name_'. If the
\ word '_name_' already exists, it and all subsequent words are
\ forgotten from the current dictionary, then a 'marker' word
\ '_name_' is created.  This is usually placed at the start of a
\ file. When the code is reloaded, any prior version is
\ automatically pruned from the dictionary. Executing '_name_'
\ will also cause it to be forgotten, since it is a 'marker'
\ word.

: anew  ( "name" -- ) ( run: -- )
  >in @ possibly >in ! marker
  ;

