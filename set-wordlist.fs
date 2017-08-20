\ galope/set-wordlist.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

: set-wordlist ( wid -- )
  >r get-order
  dup 0= -50 and throw \ Search-order underflow?
  nip r> swap set-order ;
  \ Replace the wordlist on the top of the search list.
  \ Code from Gforth's compat/vocabulary.fs (public domain).

\ ==============================================================
\ Change log

\ 2014-02-18: Moved from <galope/module.fs>.
\
\ 2017-08-17: Update change log layout and source style.
