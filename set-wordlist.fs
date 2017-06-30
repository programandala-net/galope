\ galope/set-wordlist.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ 2014-02-18: Moved from <galope/module.fs>.

: set-wordlist ( wid -- )
  \ Replace the wordlist on the top of the search list.
  \ Code from Gforth's compat/vocabulary.fs (public domain).
  >r get-order
  dup 0= -50 and throw \ Search-order underflow?
  nip r> swap  set-order
  ;
