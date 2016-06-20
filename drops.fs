\ galope/drops.fs
\ Multiple drop

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012,2016

\ Licence
\
\ You may do whatever you want with this work, so long as you
\ retain the copyright/authorship/acknowledgment/credit
\ notice(s) and this license in all redistributed copies and
\ derived works.  There is no warranty.

\ History
\
\ 2012-04-19: 'mdrop' extracted from "Asalto y castigo"
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\
\ 2012-04-30: Removed '?mdrop' and '?2mdrop'; now the check is
\ done in 'mdrop' with '?do'. '2mdrop' is moved to its own file.
\
\ 2012-09-14: Renamed: 'drops'.
\
\ 2016-01-16: Updated header and layout.

: drops ( x1 ... xn n -- )
  0 ?do  drop  loop  ;

