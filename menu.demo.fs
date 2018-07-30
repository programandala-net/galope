\ galope/menu.demo.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807301712
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./menu.fs

allocate-menu my-menu

:noname ( -- ca len ) s" My menu" ;

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

: .menu-option ( option | -1 )
  cr dup -1 = if    ." You escaped the menu"
              else  ." Your chose option "
                    my-menu ~menu-option-maker perform type
              then ;

: press-any-key ( -- )
  cr ." Press any key to continue" key drop ;

: menu.demo ( -- option | -1 )

   4 my-menu ~menu-column !
  16 my-menu ~menu-row !
  24 my-menu ~menu-width !
   8 my-menu ~menu-height !

  page ." Ceasing menu at column " my-menu ~menu-column @ .
                          ." row " my-menu ~menu-row @ . ." :"
  my-menu .menu
  my-menu ceasing-menu .menu-option
  press-any-key

  page ." Same ceasing menu, but automatically centered:"
  my-menu center-menu
  my-menu ceasing-menu .menu-option
  press-any-key

  page ." Again, but with larger margins:"
  2 to menu-top-margin
  3 to menu-left-margin
  3 to menu-right-margin
  2 to menu-bottom-margin
  my-menu ceasing-menu .menu-option
  press-any-key

  page ." The End"
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
