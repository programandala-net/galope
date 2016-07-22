\ galope/s-curly-bracket.fs
\ `s{`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2013, 2014,
\ 2016.

\ Description: Tools to choose one string from a set. Actually, it's
\ only a syntax compatibility layer for `2choose{`.

\ ==============================================================

require ./two-choose-curly-bracket.fs

' 2choose{ alias  s{ ( -- )
  \ Start a set of strings to choose from.

' }2choose alias }s ( ca1 len1 ... ca#n len#n -- ca' len' )
  \ Chose a string _ca' len'_ randomly from the strings _ca1 len ... ca#n
  \ len#n_ stacked since the last unresolved `s{`.

\ ==============================================================
\ History

\ 2012-04-07: In order to reuse this code, it was extracted from the
\ project it was developed for
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\ The abort messages are translated to English.
\
\ 2012-04-22: The original Spanish comments are moved to the end of
\ the file.  More compact source layout.
\
\ 2012-04-30: Added 's?{' and '}s{'.
\
\ 2012-05-02: Fixed some stack comments.
\
\ 2012-05-05: Added the new files galope/increment.fs and
\ galope/decrement.fs, instead of defining '++' and '--'.  Added
\ '}s&?'.
\
\ 2012-05-08: galope/increment.fs and galope/decrement.fs changed
\ their names to galope/plus-plus.fs and galope/minus-minus.fs.
\
\ 2012-09-14: Code reformated.
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2014-11-17: Module name updated.
\
\ 2016-07-11: Update source layout, file header, stack notation.
\
\ 2016-07-19: Update and fix some stack comments. Replace underscores
\ with dashes (this change does not break backwards compatibility,
\ because the all of the renamed words are private).
\
\ 2016-07-20: Comment out the shortcuts to combined actions. This way
\ this module does not depend on a specific implementation of a string
\ buffer, like <sb.fs>.
\
\ 2016-07-22: Remove the shortcuts to combined actions. Remove the
\ Spanish documentation. Move `s?` to its own module and rename it to
\ `50%nullify`. Write more general versions `%nullify` and `?nullify`.
\ Factor the code into three new modules: <choose-stack.fs>,
\ <choose-curly-bracket.fs> and <two-choose-curly-bracket.fs>.  Keep
\ this file as a compatibility layer, and rename it to
\ <s-curly-bracket.fs>.
