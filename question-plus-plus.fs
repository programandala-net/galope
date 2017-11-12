\ galope/question-plus-plus.fs
\ `?++`

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

require ./question-one-plus-store.fs

synonym ?++ ?1+! ( a -- )

  \ doc{
  \
  \ ?++ ( a -- )
  \
  \ Increment the single-cell number at _a_ to, but not beyond, the
  \ largest usable signed integer.
  \
  \ ``?++`` is a depreacted synonym of `?1+!`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-11: Move from "Asalto y castigo"
\ (http://programandala.net/en.program.asalto_y_castigo.forth.html)
\ and improve.
\
\ 2017-08-17: Fix change log title. Update source style.
\
\ 2017-11-12: Move its definition to `?1+!`, which was slower.
