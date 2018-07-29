\ galope/menu.fs

\ XXX UNDER DEVELOPMENT

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807281638
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
  field:  ~menu-rounding \ flag
  field:  ~menu-option   \ number (0 index)

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

: blank-menu-options {: menu -- :}
  menu options-last-row 1+ menu options-first-row ?do
    menu ~menu-column @ 1+ i at-xy
    menu ~menu-width @ 2 - spaces
  loop ;

: blank-menu {: menu -- :}
  menu ~menu-row @ menu ~menu-height @ bounds ?do
    menu ~menu-column @ i at-xy
    menu ~menu-width @ spaces
  loop ;

: .menu-border {: menu -- :}
  menu ~menu-column @ menu ~menu-row    @
  menu ~menu-width  @ menu ~menu-height @ blank-rectangle ;

: .menu-title {: menu -- :}
  menu ~menu-title 2@ nip 0= ?exit
  menu ~menu-title 2@ in-spaces dup
  menu ~menu-width @ min menu ~menu-width @ swap - 2/
  menu ~menu-column @ +
  menu ~menu-row @ at-xy type ;

: option>xy ( option menu -- col row )
  dup ~menu-column @ 2 + swap ~menu-row @ 2 + rot + ;

: option>margins-xy ( option menu -- col1 row1 col2 row2 )
   dup >r ~menu-option @ r@ option>xy
  2dup -1 under+
       r> options-width 1- under+ ;

: option>left-margin-xy ( option menu -- col row )
  option>xy -1 under+ ;

: option>right-margin-xy ( option menu -- col row )
  dup >r option>xy r> options-width under+ ;

: -option ( option menu -- )
  2dup option>left-margin-xy  at-xy space
       option>right-margin-xy at-xy space ;
  \ Remove the highlighting of the current option.

: +option ( option menu -- )
  2dup option>left-margin-xy at-xy ." >"
       option>right-margin-xy at-xy ." <" ;
  \ Highlight the current option of _menu_.

: current-option? ( n menu -- f ) ~menu-option @ = ;

: .option
  \ over 0 swap at-xy .s key drop \ XXX INFORMER
  {: option menu -- :}
  option menu option>xy at-xy
  option menu ~menu-options 2@ drop array> @ count
         menu options-width type-left-field
  option menu current-option? if option menu +option then ;

: .menu-options ( menu -- )
  dup #visible-options 0 ?do i over .option loop drop ;

: .menu ( menu -- ) dup .menu-border
                    dup .menu-title
                        .menu-options ;

false [if]

: round-option ( n -- n' )
  dup 0 menu-options c@ within ?exit
      polarity ( -1|1) 0< ( -1|0) menu-options c@ 1- and ;
  \ XXX TODO -- Adapt from Solo Forth.

: limit-option ( n -- n' ) 0 max menu-options c@ 1- min ;
  \ XXX TODO -- Adapt from Solo Forth.

: adjust-option ( n -- n' )
  menu-rounding @ if   round-option exit
                  then limit-option ;
  \ XXX TODO -- Adapt from Solo Forth.

: option+ ( n -- ) current-option c@ + adjust-option +option ;
  \ Add _n_ to the current option, make the result fit the
  \ valid range and make it the current option.
  \
  \ XXX TODO -- Adapt from Solo Forth.

: previous-option ( -- ) -option -1 option+ ;

: next-option     ( -- ) -option  1 option+ ;

: choose-option ( n1 -- )
  current-option c@ actions-table @ array> perform ;
  \ XXX TODO -- Adapt from Solo Forth.

: menu ( menu -- )
  dup ~menu-option off +option
  begin key case
          menu-key-up     @ of previous-option endof
          menu-key-down   @ of next-option     endof
          menu-key-choose @ of choose-option   endof
        endcase again ;

[then]

end-package

\ ==============================================================
\ Change log

\ 2018-07-25: Start: define the size, clear the box, draw the
\ border...
\
\ 2018-07-27: Simplify, rewrite using `blank-rectangle`. Implement
\ `.menu-options`.
\
\ 2018-07-28: Implement current option and its highlighting.
