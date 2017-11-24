\ galope/e-key-to.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ ==============================================================

: ekey> ( x -- x false | u|c|xc true )
  dup ekey>char  if nip true exit else drop then
  dup ekey>fkey  if nip true exit else drop then
      ekey>xchar ;

  \ doc{
  \
  \ ekey> ( x -- x false | u|c|xc true )
  \
  \ If keyboard event _x_ i a valid one (a keypress _u_, a character
  \ _c_ or an extended character _xc_), convert it and return the
  \ result and _true_; otherwise return _x false_.
  \
  \ See: `-ekeys`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-24: Move from project _Serpentino_
\ (http://programandala.net/en.program.serpentino.html). Improve stack
\ comment and document.
