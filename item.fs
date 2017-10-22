\ galope/item.fs
\ Display a left justified item of a list.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017.

\ Last modified 201710221646
\ See change log at the end of the file.

\ ==============================================================

require ./l-type.fs

: (item-bullet) ( -- ca len ) s" -" ;

  \ doc{
  \
  \ (item-bullet) ( -- ca len )
  \
  \ Return the default bullet string used by `item`, which is "-".
  \ ``(item-bullet)`` is the default action of `item-bullet`.
  \
  \ }doc

defer item-bullet ( -- ca len )
' (item-bullet) is item-bullet

  \ doc{
  \
  \ item-bullet ( -- ca len )
  \
  \ Return the bullet string used by `item`. ``item-bullet`` is a
  \ deferred word. Its default action is `(item-bullet)`, which
  \ returns "-".
  \
  \ }doc

: (item) ( ca len -- )
  item-bullet tuck /ltype
  indentation1 >r 0  to indentation1
  indentation2 >r 1+ to indentation2 ltype
               r>    to indentation2
               r>    to indentation1 ;
  \ Display _ca len_ as a list item.

: item ( ca len -- )
  /paragraph >r 0 to /paragraph
  (item)     r>   to /paragraph ;

  \ doc{
  \
  \ item ( ca len -- )
  \
  \ Display _ca len_ as a list item, using `item-bullet`.  ``item``
  \ displays _ca len_ with `ltype` and related words, preserving the
  \ current values of `indentation1`, `indentation2` and `/paragraph`.
  \
  \ }doc

\ ==============================================================
\ Debug

false [if]

: titem ( -- )
  s" En un lugar de La Mancha de cuyo nombre no quiero acordarme... "
  s" En un lugar de La Mancha de cuyo nombre no quiero acordarme... "
  s" En un lugar de La Mancha de cuyo nombre no quiero acordarme... "
  s" En un lugar de La Mancha de cuyo nombre no quiero acordarme... "
  s+ s+ s+ item ;
  \ Test ìtem

[then]

\ ==============================================================
\ Change log

\ 2017-10-22: Move from project _La pistola de agua_
\ (http://programandala.net/es.programa.la_pistola_de_agua.html) and
\ improve with a configurable bullet.
