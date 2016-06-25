\ immediate-aliases-colon.fs
\ `immediate-aliases:`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ By Marcos Cruz (programandala.net)

\ 2016-06-25: Extract from the project _Asalto y castigo_ and rename.

require ./aliases-colon.fs

galope-aliases-colon-module >order

: immediate-aliases:  (  xt "name#0" ... "name#n" ";aliases" -- )
  begin  dup another-alias? ( xt xt ca len f )
  while  :alias immediate
  repeat  2drop 2drop  ;
  \ Create any number of immediate aliases of _xt_, until
  \ ";aliases" is parsed.

previous
