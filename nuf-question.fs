\ galope/nuf-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018

\ ==============================================================

require ./aborted-question.fs
require ./tick-c-r-tick.fs

: nuf? ( -- f ) 'cr' aborted? ;

  \ Credit:
  \
  \ Code from Solo Forth
  \ (http://programandala.net/en.program.solo_forth.html), which
  \ adapted it from lpForth and Forth Dimensions (volume 10, number 1,
  \ page 29, 1988-05).

  \ doc{
  \
  \ nuf? ( -- f ) "nuf-question"
  \
  \ If no key is pressed return _false_.  If a key is pressed,
  \ discard it and wait for a second key. Then return _true_ if
  \ it's a carriage return, else return _false_.
  \
  \ Usage example:
  \
  \ ----
  \ : listing ( -- ) begin ." bla " nuf? until ." Aborted" ;
  \ ----
  \
  \ See: `aborted?`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-05-13: Adapt from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
