\ galope/menu.demo.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807301610
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./menu.fs

allocate-menu my-menu

 4 my-menu ~menu-column !
15 my-menu ~menu-row !
20 my-menu ~menu-width !
 9 my-menu ~menu-height !

:noname ( -- ca len ) s" My title" ;

my-menu ~menu-title-maker !

4 my-menu ~menu-options !

:noname ( n -- ca len )
  case
    0 of s" Option 0" endof
    1 of s" Option 1" endof
    2 of s" Option 2" endof
    3 of s" Option 3" endof
  endcase ;

my-menu ~menu-option-maker !

: menu.demo ( -- option | -1 )
  my-menu .menu
  my-menu ceasing-menu
  \ my-menu free throw
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
