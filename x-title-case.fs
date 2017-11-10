\ galope/x-title-case.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require ./package.fs
require ./xbounds.fs
require ./x-c-store.fs
require ./x-to-upper.fs

package galope-xtitlecase

variable apart?

: ?word-separation ( xc -- ) dup bl = swap '-' = or apart? ! ;
  \ Update the word separation flag: is _xc_ a word separator?

: first-of-word? ( n -- f ) 0= apart? @ or ;
  \ Is the extendend character at position _n_ the first character of
  \ a word?

public

: xtitlecase ( xca len -- )
  \ XXX TODO
  \ XXX FIXME
  apart? off
  xbounds ( xca n 0 ) ?do
    dup xc@+ ( xca xca' xc ) i first-of-word?
    over ?word-separation \ update for the **next** loop
    if xtoupper rot xc! else drop nip then
  loop drop ;

  \ doc{
  \
  \ xtitlecase ( xca len -- )
  \
  \ Convert the UTF-8 character string _xca len_ to title-case, ie.
  \ convert to uppercase the first letter of every word.
  \
  \ See: `xcapitalize`, `xtoupper`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2013-08-27: Written, based on 'xuppercase'.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout.  Update stack notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-11-08: Update requirements and source layout.
\
\ 2017-11-09: Rename the module after current convention.  Improve
\ documentation.
\
\ 2017-11-08: Improve documentation.
