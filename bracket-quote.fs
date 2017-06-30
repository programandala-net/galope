\ galope/bracket-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-13 Copied from the word '<"', written by the same author in
\ 2013 for a text game.

require ./heredoc.fs

: ["  ( "text <double-quote><closing-bracket>" -- )
  \ Read text from the input stream until '"]' is found,
  \ and compile the string.
  s\" \"]" (heredoc)  postpone sliteral
  ;  immediate compile-only

