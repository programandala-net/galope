\ galope/menu.demo.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807251834
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./menu.fs

allocate-menu my-menu

10 my-menu ~menu-column !
15 my-menu ~menu-row !
20 my-menu ~menu-width !
 8 my-menu ~menu-height !

s" My title" my-menu ~menu-title 2!

: menu.demo ( -- )
  my-menu .menu
  my-menu free throw
  ;

menu.demo

\ ==============================================================
\ Change log

\ 2018-07-25: Start.

