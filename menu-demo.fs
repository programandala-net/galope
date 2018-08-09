\ galope/menu-demo.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201808091840
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================

require ./menu.fs

allocate-menu my-menu

:noname ( -- ca len ) s" My menu" ;

my-menu ~menu-title-maker !

4 my-menu ~menu-options !

: my-menu-simple-options ( n -- ca len )
  case
    0 of s" Option 0" endof
    1 of s" Option 1" endof
    2 of s" Option 2" endof
    3 of s" Option 3" endof
  endcase ;

: my-menu-complex-options ( n -- ca len )
  case
    0 of s" Option 0"   endof
    1 of s" Option 1 >" endof
    2 of s" Option 2"   endof
    3 of s" Option 3 >" endof
  endcase ;

' my-menu-simple-options my-menu ~menu-option-maker !

allocate-menu my-submenu

:noname ( -- ca len ) s" My submenu" ;

my-submenu ~menu-title-maker !

3 my-submenu ~menu-options !

:noname ( n -- ca len )
  case
    0 of s" Suboption 0" endof
    1 of s" Suboption 1" endof
    2 of s" Suboption 2" endof
  endcase ;

my-submenu ~menu-option-maker !

my-submenu resize-menu

: at-info ( -- ) 0 rows 2 - at-xy ;

: .menu-option ( option | -1 )
  at-info
  dup -1 = if   ." You escaped the menu"
           else ." You chose option "
                my-menu ~menu-option-maker perform type
           then 16 spaces ;

: .submenu-option ( option | -1 )
  at-info
  dup -1 = if   ." You escaped the submenu"
           else ." You chose suboption "
                my-submenu ~menu-option-maker perform type
           then 16 spaces ;

: press-any-key ( -- )
  cr ." Press any key to continue" key drop ;

: menu-demo-0 ( -- option | -1 )

   8 my-menu ~menu-column !
   4 my-menu ~menu-row !
  48 my-menu ~menu-width !
  16 my-menu ~menu-height !

  page ." Menu at column " my-menu ~menu-column @ .
                  ." row " my-menu ~menu-row @ .
  my-menu ceasing-menu .menu-option ;

: menu-demo-1 ( -- option | -1 )
  page ." Centered"
  my-menu center-menu
  my-menu ceasing-menu .menu-option ;

: menu-demo-2 ( -- option | -1 )
  page ." With larger margins"
  2 to menu-top-margin
  3 to menu-left-margin
  3 to menu-right-margin
  2 to menu-bottom-margin
  my-menu ceasing-menu .menu-option ;

: menu-demo-3 ( -- option | -1 )
  page ." Resized"
  my-menu resize-menu
  my-menu ceasing-menu .menu-option ;

: do-submenu ( -- )
  my-menu swap menu-option>submenu-xy
  my-submenu ~menu-row !
  my-submenu ~menu-column !
  my-submenu ceasing-menu .submenu-option ;

: menu-demo-4 ( -- option | -1 )
  page ." Shrinked and with 2 submenus"
  ['] my-menu-complex-options my-menu ~menu-option-maker !
  my-menu shrink-menu
  begin my-menu unceasing-menu dup .menu-option
                               dup -1 <>
  while
    dup case
          1 of do-submenu endof
          3 of do-submenu endof
          drop
        endcase
  repeat my-menu blank-menu ;

: menu-demo ( -- option | -1 )
  menu-demo-0 press-any-key
  menu-demo-1 press-any-key
  menu-demo-2 press-any-key
  menu-demo-3 press-any-key
  menu-demo-4
  cr ." The End"
  \ my-menu free throw
  ;

page menu-demo

\ ==============================================================
\ Change log

\ 2018-07-25: Start.
\
\ 2018-07-27: Add the menu options.
\
\ 2018-07-28: Rename the menu options (0 index).
\
\ 2018-07-30: Update.
\
\ 2018-07-31: Update with `resize-menu` and submenus. Factor the demo
\ into pieces. Rename the main word and the file.
\
\ 2018-08-09: Update.
