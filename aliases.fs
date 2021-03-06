\ aliases.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require ./colon-alias.fs
require ./package.fs

package galope-aliases

: parse-alias  ( -- ca len )
  begin  parse-name dup 0=
  while  2drop refill 0=
         abort" Error: `end-aliases` is missing"
  repeat ;
  \ Parse and return the next alias of the list started by
  \ `aliases`.

: another-alias? ( -- ca len f )
  parse-alias 2dup s" end-aliases" compare ;
  \ Parse and return the next alias _ca len_ of the list started by
  \ `aliases`. If _f_ is false, _ca len_ is the word "end-aliases",
  \ which marks the end of the list.

public

: aliases ( xt "name#0" .. "name#n" "end-aliases" -- )
  begin  dup another-alias? ( xt xt ca len f )
  while  :alias
  repeat 2drop 2drop ;

  \ doc{
  \
  \ aliases ( xt "name#0" .. "name#n" "end-aliases" -- )
  \
  \ Create any number of aliases of _xt_, until "end-aliases" is
  \ parsed.
  \
  \ See: `immediate-aliases`, `:alias`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2016-06-25: Extract from "Asalto y castigo"
\ (http://programandala.net/en.program.asalto_y_castigo.forth.html)
\ and rename.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-08-17: Update stack notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-12-04: Rename `aliases:` `aliases`; rename `;aliases`
\ `end-aliases`. Improve documentation.
