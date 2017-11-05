\ galope/dolar-fetch.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2015, 2017.

\ ==============================================================

s" gforth" environment? drop s" 0.7.9" str< [if]

  \ Gforth < 0.7.9

  require string.fs  \ Gforth's dynamic strings

  warnings @  warnings off

  : $@ ( a -- ca len )
    @ dup if dup cell+ swap @ else 0 then ;

  \ doc{
  \
  \ $@ ( a -- ca len )
  \
  \ Return the character string _ca len_ stored at Gforth's dynamic
  \ string variable _a_. If the variable has not been initialized,
  \ return an empty string.
  \
  \ NOTE: ``$@`` was added to replace the homonymous definition
  \ provided by Gforth.  Since this feature (returning an empty string
  \ when the variable is not initialized) was added to Gforth 0.7.9's
  \ ``$@``, this alternative definition is obsolete.  Therefore
  \ loading the Galope library module where ``$@`` is defined has no
  \ effect on older versions of Gforth.
  \
  \ See: `$@len`.
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
\ 2017-10-30: Check Gforth 0.7.9, which works this way. Don't use
\ `pad`.
