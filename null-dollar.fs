\ galope/null-dollar.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2016, 2017.

\ ==============================================================

0 0 2constant null$ ( -- ca len )

  \ doc{
  \
  \ null$ ( -- ca len )
  \
  \ Return an empty (zero-length) character string, with a fake start
  \ address, which is zero.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2016-07-11: Move from "Asalto y castigo"
\ (http://programandala.net/en.program.asalto_y_castigo.forth.html).
\
\ 2017-08-17: Fix change log title.
\
\ 2017-11-05: Use zero as fake address instead of `pad`. Improve
\ documentation.
