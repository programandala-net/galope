\ galope/menu.demo.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807300103
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./menu.fs

allocate-menu my-menu

 4 my-menu ~menu-column !
15 my-menu ~menu-row !
20 my-menu ~menu-width !
 9 my-menu ~menu-height !

s" My title" my-menu ~menu-title 2!

here s" Option 3" s,
here s" Option 2" s,
here s" Option 1" s,
here s" Option 0" s,

create my-menu-options , , , ,

my-menu-options 4 my-menu ~menu-options 2!

: menu.demo ( -- )
  my-menu .menu
  my-menu menu
  my-menu free throw
  ;

page menu.demo

\ ==============================================================
\ Change log

\ 2018-07-25: Start.
\
\ 2018-07-27: Add the menu options.
\
\ 2018-07-28: Rename the menu options (0 index).
\
\ 2018-07-30: Update.
