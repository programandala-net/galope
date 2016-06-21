\ galope/system_color.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-12-02 Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).

require ./sgr.fs

: system_background_color  ( -- )
  \ Set the system default background color.
  trm.background-default 1 sgr
  ;
: system_foreground_color  ( -- )
  \ Set the system default foreground color.
  trm.foreground-default 1 sgr
  ;
: system_colors  ( -- )
  \ Set the system default colors.
  system_background_color system_foreground_color
  trm.reset 1 sgr
  ;
