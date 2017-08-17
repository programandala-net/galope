\ galope/l-dot-quote.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require ./l-type.fs

: l."  ( "ccc<quote>" -- )
  postpone s"
  ['] ltype compile,  ; immediate compile-only
  \ Parse the input stream until a double quote is found,
  \ and print the parsed string left justified.

  \ doc{
  \
  \ l."  ( "ccc<quote>" -- )
  \
  \ A variant of ``."`` that displays texts left justifed.
  \
  \ See: `/l."`, `ltype`.
  \
  \ }doc

: /l."  ( "ccc<quote>" -- )
  postpone s"
  ['] /ltype compile,  ; immediate compile-only
  \ Parse the input stream until a double quote is found,
  \ and print the parsed string left justified, indented
  \ with the value returned by `l-indentation`.

  \ doc{
  \
  \ /l."  ( "ccc<quote>" -- )
  \
  \ A variant of `l."` that starts a new paragraph.
  \
  \ See: `l."`, `/ltype`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-06-22: Start.
\
\ 2017-08-17: Update to the changes in the <l-type.fs> module. Rename
\ `pl."` to `/l."`. Document.
