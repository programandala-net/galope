\ galope/s-quote-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014, 2017.

\ ==============================================================

require ./heredoc.fs

:noname s\" \"\"" (heredoc) save-mem ;
:noname s\" \"\"" (heredoc) postpone sliteral ;
interpret/compile: s"" \ ""

  \ doc{
  \
  \ s"" \ Interpretation: ( "ccc<space><quote><quote><space>" -- ca len )
  \     \ Compilation:    ( "ccc<space><quote><quote><space>" -- )
  \     \ Run-time:       ( -- ca len )

  \ Interpretation:
  \
  \ Parse _ccc_ delimited by a word that consists of two double
  \ quotes.  Store the resulting string in newly allocated space in
  \ the heap and return it as _ca len_.
  \
  \ Compilation:
  \
  \ Parse _ccc_ delimited by a word that consists of two double
  \ quotes. Append the run-time semantics given below to the current
  \ definition.
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
\ 2017-08-19: Rename `"` to `s""` and use two double quotes as
\ delimiter; rename the module.  Update documentation.
\
\ 2017-08-20: Improve documentation.
