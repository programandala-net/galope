\ galope/l-dot-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require ./l-type.fs

: l." \ Compilation: ( "ccc<quote>" -- )
      \ Run-time:    ( -- )
  postpone s"
  ['] ltype compile, ; immediate compile-only

  \ doc{
  \
  \ l." \ Compilation: ( "ccc<quote>" -- )
  \     \ Run-time:    ( -- )

  \ Compilation: Parse _ccc_ delimited by a double quote.
  \ Append the run-time semantics below to the current
  \ definition.
  \
  \ Run-time: Display the string _ccc_ left justified with
  \ `ltype`.
  \
  \ See: `/l."`.
  \
  \ }doc

: /l." \ Compilation: ( "ccc<quote>" -- )
       \ Run-time:    ( -- )
  postpone s"
  ['] /ltype compile,  ; immediate compile-only

  \ doc{
  \
  \ /l." \ Compilation: ( "ccc<quote>" -- )
  \      \ Run-time:    ( -- )
  \
  \ Compilation: Parse _ccc_ delimited by a double quote.
  \ Append the run-time semantics below to the current
  \ definition.
  \
  \ Run-time: Display _ccc_ left justified in a new paragraph
  \ with `/ltype`.
  \
  \ See: `l."`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-06-22: Start.
\
\ 2017-08-17: Update to the changes in the <l-type.fs> module.
\ Rename `pl."` to `/l."`. Document.
\
\ 2017-11-12: Improve documentation.
