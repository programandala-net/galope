\ galope/less-than-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./heredoc.fs

: <" ( "text <double-quote><greater>" -- ca len )
  s\" \">" (heredoc) save-mem ;

  \ doc{
  \
  \ <" \ Compilation: ( "ccc<space><quote><closing-bracket><space>" -- )
  \    \ Run-time:    ( -- ca len )

  \
  \ Compilation:
  \
  \ Parse _ccc_ delimited by the word ``">``.  Append the run-time
  \ semantics given below to the current definition.
  \
  \ Run-time:
  \
  \ Return a string _ca len_ that describes the string consisting of
  \ the characters _ccc_.
  \
  \ See: `heredoc`, `"`, `["`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2014-02-13 Modifed from the word '<"', written by the same author in
\ 2013 for a text game.
\
\ 2017-08-17: Update change log layout. Update header. Update source
\ style. Document.
