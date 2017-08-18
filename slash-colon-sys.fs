\ galope/slash-colon-sys.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

depth value /colon-sys ( -- n )

  \ doc{
  \
  \ /colon-sys ( -- n )
  \
  \ _n_ is the size of _colon-sys_ in cells.
  \
  \ }doc

:noname [ depth /colon-sys - 1- to /colon-sys ] ; drop
  \ Calculate `/colon-sys`.

\ ==============================================================
\ Change log

\ 2017-08-19: Move from Talanto
\ (http://programandala.net/en.program.talanto.html) and improve it:
\ make the calculation work also when the stack is not empty.
