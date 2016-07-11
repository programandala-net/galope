\ aliases-colon.fs
\ `aliases:`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016

\ ==============================================================

require ./colon-alias.fs
require ./module.fs

module: galope-aliases-colon-module

: parse-alias  ( -- ca len )
  begin   parse-name dup 0=
  while   2drop refill 0=
          abort" Error: `;aliases` missing"
  repeat  ;
  \ Parse and return the next alias of the list started by
  \ `aliases{`.

: another-alias?  ( -- ca len f )
  parse-alias 2dup s" ;aliases" compare  ;
  \ Parse and return the next alias _ca len_ of the list started by
  \ `aliases{`. If _f_ is false, _ca len_ is the word "}aliases",
  \ which marks the end of the list.

export

: aliases:  (  xt "name#0" ... "name#n" ";aliases" -- )
  begin  dup another-alias? ( xt xt ca len wf )
  while  :alias
  repeat  2drop 2drop  ;
  \ Create any number of aliases of _xt_, until ";aliases" is parsed.

;module

\ ==============================================================
\ History

\ 2016-06-25: Extract from "Asalto y castigo"
\ (http://programandala.net/en.program.asalto_y_castigo.forth.html)
\ and rename.
\
\ 2016-07-11: Update source layout and file header.
