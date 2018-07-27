\ galope/type-left-field.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807271749
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2016, 2017, 2018.

\ ==============================================================

require padding-spaces.fs

: type-left-field ( ca1 len1 len2 -- )
  2dup 2>r min type 2r> padding-spaces ;

  \ doc{
  \
  \ type-left-field ( ca1 len1 len2 -- )
  \
  \ If _len1_ is greater than zero, display the character
  \ string _ca1 len1_ at the left of a field of _len2_
  \ characters.
  \
  \ See: `padding-spaces`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-25: Adapt from Solo Forth
\ (http://programandala.net/en.program.solo_forth.html).
