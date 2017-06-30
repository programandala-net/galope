\ galope/less-than-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-13 Modifed from the word '<"', written by the same author in
\ 2013 for a text game.

require ./heredoc.fs

: <"  ( "text <double-quote><greater>" -- ca len )
  \ Read text from the input stream until '">' is found.
  s\" \">" (heredoc) save-mem
  ;
