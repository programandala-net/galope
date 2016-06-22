\ galope/l-dot-quote.fs
\ Left justified version of `."`

\ This file is part of Galope

\ Copyright (C) 2016 Marcos Cruz (programandala.net)

\ 2016-06-22

require ./l-type.fs

: l."  ( "ccc<quote>" -- )
  postpone s"
  ['] l-type compile,  ; immediate compile-only
  \ Parse the input stream until a double quote is found,
  \ and print the parsed string left justified.

: pl."  ( "ccc<quote>" -- )
  postpone s"
  ['] pl-type compile,  ; immediate compile-only
  \ Parse the input stream until a double quote is found,
  \ and print the parsed string left justified, indented
  \ with the value returned by `l-indentation`.

