\ galope/menu.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807262217
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================
\ Requirements

require ./emits.fs            \ `emits`
require ./package.fs          \ `package`
require ./question-perform.fs \ `?perform`

\ ==============================================================

package galope-menu

public

0
  field: ~menu-column
  field: ~menu-row
  field: ~menu-width
  field: ~menu-height
  2field: ~menu-title       \ address and length of a string
  field: ~menu-options      \ address of array of counted strings
  field: ~menu-actions      \ address of array of execution tokens, or zero
  field: ~menu-border-maker \ execution token
  field: ~menu-title-maker  \ execution token
  field: ~menu-rounding     \ flag
constant /menu

  \
  \ /menu ( -- len )
  \
  \ Size of a `menu` data structure, in address units.
  \

\ private

: last-column ( a -- n )
  dup ~menu-column @ swap ~menu-width @ + ;
  \ Last row _n_ of menu _a_.

: border-bottom-row ( a -- n )
  dup ~menu-row @ swap ~menu-height @ + ;

: last-row ( a -- n ) border-bottom-row 1- ;
  \ Last row _n_ of menu _a_.

: border-right-column ( a -- n )
  dup ~menu-column @ swap ~menu-width @ + ;

: border-left-column ( a -- n ) ~menu-column @ 1- ;

: border-top-row ( a -- n ) ~menu-row @ 1- ;

: horizontal-border ( a -- )
  '+' emit '-' swap ~menu-width @ emits '+' emit ;

: default-border-maker {: menu -- :}
  menu border-left-column menu border-top-row at-xy
  menu horizontal-border
  menu last-row 1+ menu ~menu-row @ ?do
    menu border-left-column  i at-xy '|' emit
    menu border-right-column i at-xy '|' emit
  loop
  menu border-left-column menu border-bottom-row at-xy
  menu horizontal-border ;

: default-title-maker {: menu -- :}
  menu ~menu-title 2@ dup
  if   menu ~menu-column @ menu ~menu-row @ at-xy type
  else 2drop then ;

public

: init-menu {: menu -- :}
  menu /menu erase
  ['] default-border-maker menu ~menu-border-maker !
  ['] default-title-maker  menu ~menu-title-maker ! ;

: create-menu ( "name" -- )
  here create /menu allot init-menu ;

: allocate-menu ( "name" -- )
  /menu allocate throw dup constant init-menu ;

: clear-menu {: menu -- :}
  menu last-row menu ~menu-row @ ?do
    menu ~menu-column @ i at-xy menu ~menu-width @ spaces
  loop ;

: .menu {: menu -- :}
  menu clear-menu
  menu ~menu-border-maker @ ?dup if menu swap execute then
  menu ~menu-title-maker  @ ?dup if menu swap execute then  ;

end-package

\ ==============================================================
\ Change log

\ 2018-07-25: Start: define the size, clear the box, draw the border...
