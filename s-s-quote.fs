\ galope/s-s-quote.fs
\ `ss"`
\ Stringer strings parser.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2020.

\ Description: A string parser that returns the result in the
\ stringer (a circular string buffer).

\ ==============================================================

require ./gforth-question.fs
require ./package.fs
require ./stringer.fs

package galope-s-s-quote

gforth? [if]

public

:noname ( <ccc"> -- ca len )
    '"' parse >stringer ;

:noname ( <ccc"> -- )
  '"' parse postpone SLiteral ;

interpret/compile: ss"
  ( compilation <ccc"> -- ; run-time -- ca len )

[else]

private

: (ss) \ Interpretation: ( ca1 len -- ca2 len )
       \ Compilation:    ( ca len -- )
  state @ if postpone sliteral else >stringer then ;
  \ Interpretation: Move the parsed string _ca1 len_ to the
  \ stringer (a circular string buffer) and return it as _ca2
  \ len_.
  \
  \ Compilation: compile the parsed string _ca len_, which will
  \ be returned at run-time.

public

: ss" \ Interpretation: ( "ccc<quote>" -- ca len )
      \ Compilation:    ( "ccc<quote>" -- )
      \ Run-time:       ( -- ca len )
  '"' parse (ss) ; immediate
  \ Interpretation: Parse _ccc_ delimited by _quote_ and return
  \ the resulting string _ca len_ in the stringer (a circular
  \ string buffer).
  \
  \ Compilation: Parse _ccc_ delimited by _quote_ and compile
  \ the resulting string _ca len_, which will be returned at
  \ run-time.
  \
  \ Run-time: Return the string _ca len_ that consists of the
  \ characters _ccc_.

[then]

  \ doc{
  \
  \ ss" ( compilation <ccc"> -- ; run-time -- ca len )
  \
  \ An variant of the standard word ``s"``, using the
  \ `stringer`.
  \
  \ Compilation: Parse a string _ccc_ delimited by a '"' (double
  \ quote) and compile it into the current definition. At
  \ run-time, return the length, _len_, and the start address,
  \ _ca_ of the string.
  \
  \ Interpretation: parse a string _ccc_ delimited by a '"'
  \ (double quote), copy it to the `stringer` and return its
  \ address and length _ca len_.
  \
  \ See: `ss+`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2016-07-19: Move from <stringer.fs>.
\
\ 2016-07-20: Improve comments.
\
\ 2017-08-17: Update change log layout.
\
\ 2020-01-05: Add a Gforth-specific version using
\ `interpret/compile:`. Update source style. Improve
\ documentation.
