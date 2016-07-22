\ galope/s-s-quote.fs
\ `ss"`
\ Stringer strings parser.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016.

\ Description: A string parser that returns the result in the stringer
\ (a circular string buffer).

\ ==============================================================

require ./stringer.fs

: (ss)  \ Interpretation:  ( ca1 len -- ca2 len )
        \ Compilation:     ( ca len -- )
  state @ if  postpone sliteral  else  >stringer  then  ;
  \ Interpretation: Move the parsed string _ca1 len_ to the stringer
  \ (a circular string buffer) and return it as _ca2 len_.
  \ Compilation: compile the parsed string _ca len_, which will be
  \ returned at run-time.

: ss"  \ Interpretation:  ( "ccc<quote>" -- ca len )
       \ Compilation:     ( "ccc<quote>" -- )
       \ Run-time:        ( -- ca len )
  '"' parse (ss)  ; immediate
  \ Interpretation: Parse _ccc_ delimited by _quote_ and return the
  \ resulting string _ca len_ in the stringer (a circular string
  \ buffer).  Compilation: Parse _ccc_ delimited by _quote_ and
  \ compile the resulting string _ca len_, which will be returned at
  \ run-time.  Run-time: Return the string _ca len_ that consists of
  \ the characters _ccc_.

\ ==============================================================
\ History

\ 2016-07-19: Move from <stringer.fs>.
\ 2016-07-20: Improve comments.
