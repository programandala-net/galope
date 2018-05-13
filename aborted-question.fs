\ galope/aborted-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018

\ ==============================================================

: aborted? ( c -- f )
  key? dup if key 2drop key = else nip then ;

  \ Credit:
  \
  \ Code from Solo Forth
  \ (http://programandala.net/en.program.solo_forth.html).

  \ doc{
  \
  \ aborted? ( c -- f ) "aborted-question"
  \
  \ If no key is pressed return _false_.  If a key is pressed,
  \ discard it and wait for a second key. Then return _true_ if
  \ it's _c_, else return _false_.
  \
  \ ``aborted?`` is a useful factor of `nuf?`.
  \
  \ Usage example:

  \ ----
  \ : listing ( -- )
  \   begin ." bla " bl aborted? until ." Aborted" ;
  \ ----

  \ }doc

\ ==============================================================
\ Change log

\ 2018-05-13: Adapt from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
