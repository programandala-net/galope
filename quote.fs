\ galope/less-than-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./heredoc.fs

:noname s\" \"" (heredoc) save-mem ;
:noname s\" \"" (heredoc) postpone sliteral ;
interpret/compile: " \ "

  \ doc{
  \
  \ " \ Interpretation: ( "ccc<space><quote><space>" -- ca len )
  \   \ Compilation:    ( "ccc<space><quote><space>" -- )
  \   \ Run-time:       ( -- ca len )

  \ Interpretation:
  \
  \ Parse _ccc_ delimited by a word that is a double quote. Store the
  \ resulting string in the heap and return it as _ca len_.
  \
  \ Compilation:
  \
  \ Parse _ccc_ delimited by a word that is a double quote. Append the
  \ run-time semantics given below to the current definition.
  \
  \ Run-time:
  \
  \ Return a string _ca len_ that describes the string consisting of
  \ the characters _ccc_.
  \
  \ See: `heredoc`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-13 Adapted from the word '<"', written by the same author in
\ 2013 for a text game.
\
\ 2017-08-17: Update change log layout. Update source style and
\ header. Document.
\
\ 2017-08-19: Update documentation.
