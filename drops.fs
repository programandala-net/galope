\ galope/drops.fs
\ Multiple drop

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)


\ History
\
\ 2012-04-19: 'mdrop' extracted from "Asalto y castigo"
\ [http://programandala.net/es.programa.asalto_y_castigo.forth].
\
\ 2012-04-30: Removed '?mdrop' and '?2mdrop'; now the check is done in
\ 'mdrop' with '?do'. '2mdrop' is moved to its own file.
\
\ 2012-09-14: Renamed to 'drops'.

: drops ( x1 ... xn n -- )
  0 ?do  drop  loop
  ;

