\ immediate-aliases.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ By Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require ./aliases.fs

galope-aliases >order

: immediate-aliases (  xt "name#0" .. "name#n" "end-aliases" -- )
  begin  dup another-alias? ( xt xt ca len f )
  while  :alias immediate
  repeat 2drop 2drop ;

  \ doc{
  \
  \ immediate-aliases ( xt "name#0" .. "name#n" "end-aliases" -- )
  \
  \ Create any number of immediate `aliases` of _xt_, until
  \ "end-aliases" is parsed.
  \
  \ See: `:alias`.
  \
  \ }doc

previous

\ ==============================================================
\ Change log

\ 2016-06-25: Extract from "Asalto y castigo"
\ (http://programandala.net/en.program.asalto_y_castigo.forth.html)
\ and rename.
\
\ 2016-07-11: Update source layout and file header.
\
\ 2017-12-04: Rename `immediate-aliases:` `immediate-aliases`; rename
\ `;aliases` `end-aliases`. Fix `aliases`'s package name. Improve
\ documentation.
