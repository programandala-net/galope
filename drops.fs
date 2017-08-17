\ galope/drops.fs
\ `drops`
\ Multiple drop

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ ==============================================================

: drops ( x1 ... xn n -- )
  0 ?do  drop  loop  ;

\ ==============================================================
\ Change log

\ 2012-04-19: Extract 'mdrop' from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2012-04-30: Remove '?mdrop' and '?2mdrop'; now the check is done in
\ 'mdrop' with '?do'. Move '2mdrop' to its own file.
\
\ 2012-09-14: Rename to 'drops'.
\
\ 2016-01-16: Update header and layout.
\
\ 2016-07-11: Update header and layout.
