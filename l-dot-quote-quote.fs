\ galope/l-dot-quote-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

require ./l-type.fs
require ./s-quote-quote.fs

: l."" \ Compilation: ( "ccc<space><quote><quote><space>" -- )
       \ Run-time:    ( -- )
  postpone s"" \ parse until ""
  ['] ltype compile, ; immediate compile-only

  \ doc{
  \
  \ l."" \ Compilation: ( "ccc<space><quote><quote><space>" -- )
  \      \ Run-time:    ( -- )

  \ Compilation: Parse _ccc_ delimited by a name formed by two
  \ double quotes.  Append the run-time semantics below to the
  \ current definition.
  \
  \ Run-time: Display the string _ccc_ left justified with
  \ `ltype`.
  \
  \ See: `/l.""`, `l."`.
  \
  \ }doc

: /l."" \ Compilation: ( "ccc<space><quote><quote><space>" -- )
        \ Run-time:    ( -- )
  postpone s"" \ parse until ""
  ['] /ltype compile, ; immediate compile-only

  \ doc{
  \
  \ /l."" \ Compilation: ( "ccc<space><quote><quote><space>" -- )
  \       \ Run-time:    ( -- )

  \ Compilation: Parse _ccc_ delimited by a name formed by two
  \ double quotes.  Append the run-time semantics below to the
  \ current definition.
  \
  \ Run-time: Display _ccc_ left justified in a new paragraph
  \ with `/ltype`.
  \
  \ See: `l.""`, `/l."`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-13: Start.
