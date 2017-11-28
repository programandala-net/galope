\ galope/new-key.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017

\ ==============================================================

require ./minus-keys.fs

: new-key ( -- c ) -keys key ;

  \ doc{
  \
  \ new-key ( -- c )
  \
  \ Remove all keys from the keyboard buffer, then return
  \ character _c_ of the key struck, a member of the a member
  \ of the defined character set.
  \
  \ See also: `-keys`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-28: Start. Copied from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
