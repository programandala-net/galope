\ galope/precedes-question.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

defer precedes? ( x1 x2 -- f )

' < ' precedes? defer!

  \ doc{
  \
  \ precedes? ( x1 x2 -- f )
  \
  \ A deferred word used by `insertion-sort` and
  \ `boosted-insertion-sort` in order to compare the pair of
  \ elements _x1_ and _x2_ currently being sorted.
  \
  \ Its default action is ``<``.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-24: Extract from <boosted-insertion-sort.fs>. Document.
