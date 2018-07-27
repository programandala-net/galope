\ galope/menu.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807271830
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================
\ Requirements

require ./array-to.fs        \ `array>`
require ./in-spaces.fs       \ `in-spaces`
require ./package.fs         \ `package`
require ./rectangle.fs       \ `rectangle`
require ./type-left-field.fs \ `type-left-field`

\ ==============================================================

package galope-menu

public

0
  field:  ~menu-column
  field:  ~menu-row
  field:  ~menu-width
  field:  ~menu-height
  2field: ~menu-title    \ address and length of a string
  2field: ~menu-options  \ address and cells of an array of counted strings
  field:  ~menu-actions  \ address of array of execution tokens, or zero
  field:  ~menu-rounding \ flag
constant /menu

  \
  \ /menu ( -- len )
  \
  \ Size of a `menu` data structure, in address units.
  \

\ private

: options-first-row ( a -- row ) ~menu-row @ 2 + ;

: options-last-row ( a -- row )
  dup ~menu-row @ swap ~menu-height @ 2 - + ;

: options-width ( a -- len ) ~menu-width @ 4 - ;

: #options ( a -- n ) ~menu-options 2@ nip ;

: #max-visible-options ( a -- n )
  dup options-last-row swap options-first-row 1- - ;

: #visible-options ( a -- n )
  dup #max-visible-options swap #options min ;

public

: init-menu ( menu -- ) /menu erase ;

: create-menu ( "name" -- )
  here create /menu allot init-menu ;

: allocate-menu ( "name" -- )
  /menu allocate throw dup constant init-menu ;

: blank-menu {: menu -- :}
  menu options-last-row 1+ menu options-first-row ?do
    menu ~menu-column @ 1+ i at-xy
    menu ~menu-width @ 2 - spaces
  loop ;
  \ Blank the options of _menu_.

: .menu-border {: menu -- :}
  menu ~menu-column @ menu ~menu-row    @
  menu ~menu-width  @ menu ~menu-height @ blank-rectangle ;

: .menu-title {: menu -- :}
  menu ~menu-title 2@ nip 0= ?exit
  menu ~menu-title 2@ in-spaces dup
  menu ~menu-width @ min menu ~menu-width @ swap - 2/
  menu ~menu-column @ +
  menu ~menu-row @ at-xy type ;

: option>xy ( n menu -- col row )
  dup ~menu-column @ 2 + swap ~menu-row @ 2 + rot + ;

: .option ( n menu -- )
  dup >r 2dup option>xy at-xy
         ~menu-options 2@ drop array> @ count
      r> options-width type-left-field ;

: .menu-options ( menu -- )
  dup #visible-options 0 ?do i over cr .option loop drop ;

: .menu ( menu -- ) dup .menu-border
                    dup .menu-title
                        .menu-options ;

end-package

\ ==============================================================
\ Change log

\ 2018-07-25: Start: define the size, clear the box, draw the
\ border...
\
\ 2018-07-27: Rewrite using `blank-rectangle`. Implement
\ `.menu-options`.
