\ galope/yyyymmdd-to-iso.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2006, 2013, 2014,
\ 2017, 2018.

\ ==============================================================

require ./iso-date-to-extended.fs
require ./warning-paren.fs

warnings @ [if]

  warning( `yyyymmdd>iso` is the deprecated name of `iso-date>extended`)

[then]

synonym yyyymmdd>iso iso-date>extended

  \ doc{
  \
  \ yyyymmdd>iso ( ca1 len1 -- ca2 len2 )
  \
  \ A deprecated synonym of `iso-date>extended`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2013-05-18: Taken from fhp
\ (http://programandala.net/en.program.fhp).  Rewritten in a
\ much simpler way.
\
\ 2014-07-14: code common to 'day>iso' and 'month>iso' is
\ factored out.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-11-13: Update source style and stack comments. Improve
\ documentation.
\
\ 2017-11-14: Deprecate. Move to <iso-date-to-extended.fs>.
\ Keep `yyyymmdd>iso` as a synonym, with a warning.
\
\ 2018-07-24: Improve documentation.
