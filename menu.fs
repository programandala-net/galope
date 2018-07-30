\ galope/menu.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201807301713
\ See change log at the end of the file.

\ Author: Marcos Cruz (programandala.net), 2018.

\ ==============================================================
\ Requirements

require ./in-spaces.fs       \ `in-spaces`
require ./package.fs         \ `package`
require ./polarity.fs        \ `polarity`
require ./rectangle.fs       \ `rectangle`
require ./type-left-field.fs \ `type-left-field`

\ ==============================================================

package galope-menu

public

0
  field: ~menu-column
  field: ~menu-row
  field: ~menu-width
  field: ~menu-height
  field: ~menu-title-maker  \ xt ( -- ca len )
  field: ~menu-options      \ number
  field: ~menu-option-maker \ xt ( n -- ca len )
  field: ~menu-rounding     \ flag
  field: ~menu-option       \ number (0 index)
constant /menu

  \
  \ /menu ( -- len )
  \
  \ Size of a `menu` data structure, in address units.
  \

\ private

1 value menu-top-margin ( -- +n )
  \ A ``value``. _+n_ is the number of empty rows between the top
  \ border of a menu (its title line) and the first visible option.
  \ Its default value is one.

0 value menu-bottom-margin ( -- +n )
  \ A ``value``. _+n_ is the number of empty rows between the bottom
  \ border of a menu and the last visible option.  Its default value
  \ is zero.

2 value menu-left-margin ( -- +n )
  \ A ``value``. _+n_ is the number of empty columns between the left
  \ border of a menu and the options.  Its default value is two.

1 value menu-right-margin ( -- +n )
  \ A ``value``. _+n_ is the number of empty columns between the right
  \ border of a menu and the options.  Its default value is one.

: options-first-row ( a -- row )
  ~menu-row @ 1+ menu-top-margin + ;

: options-last-row ( a -- row )
  dup ~menu-row @ swap ~menu-height @ +
  2 - menu-bottom-margin - ;

: options-width ( a -- len )
  ~menu-width @ 2 - menu-left-margin - menu-right-margin - ;

: #max-visible-options ( a -- n )
  dup options-last-row swap options-first-row 1- - ;

: #visible-options ( a -- n )
  dup #max-visible-options swap ~menu-options @ min ;

public

: init-menu ( menu -- ) /menu erase ;

: create-menu ( "name" -- )
  here create /menu allot init-menu ;

: allocate-menu ( "name" -- )
  /menu allocate throw dup constant init-menu ;

: center-menu-horizontally ( menu -- )
  >r cols r@ ~menu-width @ - 2/ r> ~menu-column ! ;

: center-menu-vertically ( menu -- )
  >r rows r@ ~menu-height @ - 2/ r> ~menu-row ! ;

: center-menu ( menu -- )
  dup center-menu-horizontally center-menu-vertically ;

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
  menu ~menu-title-maker @ ?dup 0= ?exit execute ( ca len )
  in-spaces dup
  menu ~menu-width @ min menu ~menu-width @ swap - 2/
  menu ~menu-column @ +
  menu ~menu-row @ at-xy type ;

: option>xy ( menu option -- col row )
  over ~menu-row @ 1+ menu-top-margin + +
  swap ~menu-column @ 1+ menu-left-margin + swap ;

: option>left-margin-xy ( menu option -- col row )
  option>xy menu-left-margin negate under+ ;

: (unhighlight-option) ( menu option -- )
  option>left-margin-xy at-xy menu-left-margin spaces ;
  \ Unhighlight _option_ of _menu_ with the default method.

defer unhighlight-option ( menu option -- )
  ' (unhighlight-option) is unhighlight-option
  \ Unhighlight _option_ of _menu_.

: (highlight-option) ( menu option -- )
  option>left-margin-xy menu-left-margin 2 - under+
  at-xy ." >" ;
  \ Highlight _option_ of _menu_ with the default method.

defer highlight-option ( menu option -- )
  ' (highlight-option) is highlight-option
  \ Highlight _option_ of _menu_.

: current-option? ( menu option -- f ) swap ~menu-option @ = ;

: .option {: menu option -- :}
  menu option option>xy at-xy
  option menu ~menu-option-maker perform
  menu options-width type-left-field
  menu option current-option?
  if menu option highlight-option then ;
  \ Display _option_ of _menu_.

: .menu-options ( menu -- )
  dup #visible-options 0 ?do dup i .option loop drop ;
  \ Display the options of _menu_.

: fix-menu-height ( menu -- )
  dup >r ~menu-height  @
      r@ ~menu-options @ menu-top-margin + menu-bottom-margin +
                         2 + \ borders
      max r> ~menu-height ! ;
  \ Make sure the _menu_ height is enough.
  \
  \ XXX TMP -- Until the rounding is implemented.

: .menu ( menu -- ) dup fix-menu-height
                    dup .menu-border
                    dup .menu-title
                        .menu-options ;
  \ Display _menu_.

: round-option ( menu option -- option' )
  swap {: menu :}
  dup 0 menu ~menu-options @ within ?exit
      polarity ( -1|1) 0< ( -1|0) menu ~menu-options @ 1- and ;

: limit-option ( menu option -- option' )
  0 max swap ~menu-options @ 1- min ;

: adjust-option ( menu option -- option' )
  over ~menu-rounding @ if   round-option
                        else limit-option then ;

: option+ ( menu n -- )
  over tuck ~menu-option @ +
            adjust-option 2dup swap ~menu-option !
            highlight-option ;
  \ Add _n_ to the current option, make the result fit the
  \ valid range and make it the current option.

: unhighlight-current-option ( menu -- )
  dup ~menu-option @ unhighlight-option ;

: previous-option ( menu -- )
  dup unhighlight-current-option -1 option+ ;

: next-option ( menu -- )
  dup unhighlight-current-option 1 option+ ;

k-up   value menu-fkey-up
k-down value menu-fkey-down
13     value menu-key-choose \ enter key
27     value menu-key-exit   \ escape key

: menu>option {: menu -- option | -1 :}
  menu menu ~menu-option @ highlight-option
  begin ekey
    ekey>fkey if
      case
        menu-fkey-up   of menu previous-option endof
        menu-fkey-down of menu next-option     endof
      endcase
    else
      ekey>char if
        case
          menu-key-choose of menu ~menu-option @ exit endof
          menu-key-exit   of                  -1 exit endof
        endcase
      else drop
      then
    then
  again ;

: unceasing-menu ( menu -- option | -1 )
  dup .menu menu>option ;

: ceasing-menu ( menu -- option | -1 )
  dup unceasing-menu swap blank-menu ;

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
\
\ 2018-07-29: Change the order of parameters "option menu" to "menu
\ option".
\
\ 2018-07-30: Finish the option selection. First working version.
\ Replace title string and options string array with execution tokens.
\ Support a escape key. Add `ceasing-menu` and `unceasing-menu` as
\ top-level interface. Add words to center the menu on the screen.
\ Make inner margins configurable. Simplify the highlighting and make
\ it configurable.
