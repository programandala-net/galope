\ galope/system_color.fs
\ Set the system default colors.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ 2012-12-02: Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth.html>).
\
\ 2016-06-26: Change underscores to hyphens; update source style and
\ header.

require ./sgr.fs

: system-background-color  ( -- )
  trm.background-default 1 sgr  ;
  \ Set the system default background color.

: system-foreground-color  ( -- )
  trm.foreground-default 1 sgr  ;
  \ Set the system default foreground color.

: system-colors  ( -- )
  system-background-color system-foreground-color
  trm.reset 1 sgr  ;
  \ Set the system default colors.
