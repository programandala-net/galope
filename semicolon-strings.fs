\ galope/semicolon-strings.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-11-30 Written.

\ This in an optional ending for definition of constant string arrays,
\ provided by <galope/constant_string_arrays_1.fs>  and
\ <galope/constant_string_arrays_2.fs>.

: ;strings  ( n -- )
  \ End the definition of a constant string array.
  \ n = number of strings compiled in the array
  /strings drop
  ;
