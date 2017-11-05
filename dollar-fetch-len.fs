\ galope/dollar-fetch-len.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2015, 2017.

\ ==============================================================

s" gforth" environment? drop s" 0.7.9" str< [if]

  \ Gforth < 0.7.9

  require string.fs  \ Gforth's dynamic strings

  warnings @  warnings off

  : $@len ( a -- len ) @ dup if @ then ;

  \ doc{
  \
  \ $@len ( a -- len )
  \
  \ Return the length of a Gforth's dynamic string variable _a_. If
  \ the variable has not been initialized, return zero.
  \
  \ NOTE: ``$@len`` was added to replace the homonymous definition
  \ provided by Gforth.  Since this feature (returning zero when the
  \ variable is not initialized) was added to Gforth 0.7.9's
  \ ``$@len``, this alternative definition is obsolete.  Therefore
  \ loading the Galope library module where ``$@len`` is defined has
  \ no effect on older versions of Gforth.
  \
  \ See: `$@`, `$empty`.
  \
  \ }doc

  warnings !

[then]

\ ==============================================================
\ Change log

\ 2013-08-30: Extracted from Fungo, by the same author.
\
\ 2015-02-11: Gforth 0.8 will work this way, so a check is added.
\
\ 2017-08-17: Update change log layout and source style.
\
\ 2017-11-05: Check Gforth 0.7.9 instead 0.8.0. Improve documentation.
