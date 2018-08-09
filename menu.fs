\ galope/menu.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Last modified: 201808091840
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

  \ doc{
  \
  \ ~menu-column ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing the left column of the menu identified by _menu_.
  \
  \ See: `~menu-row`, `center-menu`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-rouding`, `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-row

  \ doc{
  \
  \ ~menu-row ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing the top row of the menu identified by _menu_.
  \
  \ See: `~menu-column`, `center-menu`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-rouding`, `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-width

  \ doc{
  \
  \ ~menu-width ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing the width of the menu identified by _menu_, in
  \ characters.
  \
  \ See: `~menu-height`, `resize-menu`, `~menu-column`, `~menu-row`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-rouding`, `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-height

  \ doc{
  \
  \ ~menu-height ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing the height of the menu identified by _menu_, in
  \ characters.
  \
  \ See: `~menu-width`, `resize-menu`, `~menu-column`, `~menu-row`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-rouding`, `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-title-maker  \ xt ( -- ca len )

  \ doc{
  \
  \ ~menu-title-maker ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing an execution token, which, when executed, returns the
  \ title string of the menu identified by _menu_, as a string
  \ identified by its address and length: _ca len_.
  \
  \ See: `~menu-column`, `~menu-row`, `~menu-width`, `~menu-height`,
  \ `~menu-options`, `~menu-option-maker`, `~menu-rouding`,
  \ `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-options      \ number

  \ doc{
  \
  \ ~menu-options ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing the numbers of options of the menu identified by
  \ _menu_.
  \
  \ See: `~menu-column`, `~menu-row`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-option-maker`, `~menu-rouding`,
  \ `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-option-maker \ xt ( n -- ca len )

  \ doc{
  \
  \ ~menu-option-maker ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing an execution token, which, when executed, converts an
  \ option number _n_ of the menu identified by _menu_ into its
  \ corresponding string, identified by its string and length: _ca
  \ len_.
  \
  \ See: `~menu-column`, `~menu-row`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-rouding`,
  \ `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-rounding     \ flag

  \ doc{
  \
  \ ~menu-rounding ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing a flag. If the flag is false, the user can not navigate
  \ throw the first and last options of the menu identified by _menu_.
  \
  \ See: `~menu-column`, `~menu-row`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-option`, `/menu`, `ceasing-menu`.
  \
  \ }doc

  field: ~menu-option       \ number (0 index)

  \ doc{
  \
  \ ~menu-option ( menu -- a )
  \
  \ Field of a menu data structure. _a_ is the address of a cell
  \ containing the number of the current option of the menu identified
  \ by _menu_.
  \
  \ See: `~menu-column`, `~menu-row`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-rouding`, `/menu`, `ceasing-menu`.
  \
  \ }doc

constant /menu

  \ doc{
  \
  \ /menu ( -- len )
  \
  \ Size of a menu data structure, in address units.
  \
  \ See: `~menu-column`, `~menu-row`, `~menu-width`, `~menu-height`,
  \ `~menu-title-maker`, `~menu-options`, `~menu-option-maker`,
  \ `~menu-rouding`, `~menu-option`, `ceasing-menu`.
  \
  \ }doc

\ private

2 constant menu-borders

  \ doc{
  \
  \ menu-borders ( -- n )
  \
  \ A ``constant``. Width of two menu menu borders, in characters.
  \ Its value is two. ``menu-borders`` is used to make some
  \ calculation clearer.
  \
  \ }doc

1 value menu-top-margin ( -- n )

  \ doc{
  \
  \ menu-top-margin ( -- n )
  \
  \ A ``value``. _n_ is the number of empty rows between the top
  \ border of a menu (its title line) and the first visible option.
  \ Its default value is one.
  \
  \ See: `menu-bottom-margin`, `menu-left-margin`,
  \ `menu-right-margin`.
  \
  \ }doc

0 value menu-bottom-margin ( -- n )

  \ doc{
  \
  \ menu-bottom-margin ( -- n )
  \
  \ A ``value``. _n_ is the number of empty rows between the bottom
  \ border of a menu and the last visible option.  Its default value
  \ is zero.
  \
  \ See: `menu-top-margin`, `menu-left-margin`, `menu-right-margin`.
  \
  \ }doc

2 value menu-left-margin ( -- n )

  \ doc{
  \
  \ menu-left-margin ( -- n )
  \
  \ A ``value``. _n_ is the number of empty columns between the left
  \ border of a menu and the options.  Its default value is two.
  \
  \ See: `menu-right-margin`, `menu-top-margin`, `menu-bottom-margin`.
  \
  \ }doc

1 value menu-right-margin ( -- n )

  \ doc{
  \
  \ menu-right-margin ( -- n )
  \
  \ A ``value``. _n_ is the number of empty columns between the right
  \ border of a menu and the options.  Its default value is one.
  \
  \ See: `menu-left-margin`, `menu-top-margin`, `menu-bottom-margin`.
  \
  \ }doc

: menu-options-first-row ( menu -- row )
  ~menu-row @ 1+ menu-top-margin + ;

  \ doc{
  \
  \ menu-options-first-row ( menu -- row )
  \
  \ Return the first _row_ of the visible options of the menu
  \ identified by _menu_.
  \
  \ See: `menu-options-last-row`, `menu-options-width`.
  \
  \ }doc

: menu-options-last-row ( menu -- row )
  dup ~menu-row @ swap ~menu-height @ +
                  menu-borders -
                  menu-bottom-margin - ;

  \ doc{
  \
  \ menu-options-last-row ( menu -- row )
  \
  \ Return the last _row_ of the visible options of the menu
  \ identified by _menu_.
  \
  \ See: `menu-options-first-row`, `menu-options-width`.
  \
  \ }doc

: menu-options-width ( menu -- len )
  ~menu-width @ menu-borders -
                menu-left-margin -
                menu-right-margin - ;

  \ doc{
  \
  \ menu-options-width ( menu -- len )
  \
  \ Return the width of the visible options of the menu identified by
  \ _menu_, in characters.
  \
  \ See: `menu-options-first-row`, `menu-options-last-row`.
  \
  \ }doc

: #max-visible-menu-options ( menu -- n )
  dup menu-options-last-row swap menu-options-first-row 1- - ;

: #visible-menu-options ( menu -- n )
  dup #max-visible-menu-options swap ~menu-options @ min ;

: menu-option>string ( menu option -- ca len )
  swap ~menu-option-maker perform ;

  \ doc{
  \
  \ menu-option>string ( menu option -- ca len )
  \
  \ Return the menu option string _ca len_ of the menu identified by
  \ _menu_.
  \
  \ See: `~menu-option-maker`, `menu>title$`.
  \
  \ }doc

: menu>title$ ( menu -- ca len )
  ~menu-title-maker @ ?dup if execute else pad 0 then ;

  \ doc{
  \
  \ menu>title$ ( menu -- ca len )
  \
  \ Return the title string _ca len_ of the menu identified by _menu_.
  \ If no title has been specified, return an empty string in ``pad``.
  \
  \ See: `~menu-title-maker`, `menu-option>string`.
  \
  \ }doc

: init-menu ( menu -- ) /menu erase ;

  \ doc{
  \
  \ init-menu ( menu -- )
  \
  \ Init the menu identified by _menu_, by erasing its data.
  \ ``init-menu`` is executed by `create-menu` and `allocate-menu`.
  \
  \ See: `/menu`.
  \
  \ }doc

: create-menu ( "name" -- )
  here create /menu allot init-menu ;

  \ doc{
  \
  \ create-menu ( "name" -- )
  \
  \ Create a menu called _name_ in data space. When _name_ is later
  \ executed, it will return the menu identifier, which is the address
  \ of its data structure.
  \
  \ See: `/menu`, `allocate-menu`.
  \
  \ }doc

: allocate-menu ( "name" -- )
  /menu allocate throw dup constant init-menu ;

  \ doc{
  \
  \ allocate-menu ( "name" -- )
  \
  \ Create a menu called _name_ in the data space heap (therefore the
  \ data space can be freed by ``name free``).  When _name_ is later
  \ executed, it will return the menu identifier, which is the address
  \ of its data structure.
  \
  \ See: `/menu`, `free-menu`, `create-menu`.
  \
  \ }doc

: center-menu-horizontally ( menu -- )
  >r cols r@ ~menu-width @ - 2/ r> ~menu-column ! ;

  \ doc{
  \
  \ center-menu-horizontally ( menu -- )
  \
  \ Set the `~menu-column` field of the menu identified by _menu_ to
  \ make it horizontally centered on the screen.
  \
  \ See: `center-menu-vertically`, `center-menu`, `~menu-width`,
  \ `resize-menu-horizontally`.
  \
  \ }doc

: center-menu-vertically ( menu -- )
  >r rows r@ ~menu-height @ - 2/ r> ~menu-row ! ;

  \ doc{
  \
  \ center-menu-vertically ( menu -- )
  \
  \ Set the `~menu-row` field of the menu identified by _menu_ to make
  \ it vertically centered on the screen.
  \
  \ See: `center-menu-horizontally`, `center-menu`, `~menu-height`,
  \ `resize-menu-vertically`.
  \
  \ }doc

: center-menu ( menu -- )
  dup center-menu-horizontally center-menu-vertically ;

  \ doc{
  \
  \ center-menu ( menu -- )
  \
  \ Set the `~menu-column` and the `~menu-row` fields of the menu
  \ identified by _menu_ to make it centered on the screen.
  \
  \ See: `center-menu-horizontally`, `center-menu-vertically`,
  \ `resize-menu`.
  \
  \ }doc

: resize-menu-horizontally {: menu -- :}
  menu menu>title$ nip menu-borders -
  menu ~menu-options @ 0 ?do
    menu i menu-option>string nip max
  loop menu-left-margin +
       menu-right-margin +
       menu-borders +
       cols min menu ~menu-width ! ;

  \ doc{
  \
  \ resize-menu-horizontally ( menu -- )
  \
  \ Set the `~menu-width` field of the menu identified by _menu_ to
  \ make its title and options fit.
  \
  \ See: `resize-menu-vertically`, `resize-menu`,
  \ `center-menu-horizontally`, `menu-left-margin`,
  \ `menu-right-margin`, `menu-borders`.
  \
  \ }doc

: resize-menu-vertically ( menu -- )
  dup >r ~menu-options @ menu-top-margin +
                         menu-bottom-margin +
                         menu-borders +
         rows min
      r> ~menu-height ! ;

  \ doc{
  \
  \ resize-menu-vertically ( menu -- )
  \
  \ Set the `~menu-height` field of the menu identified by _menu_ to
  \ make its options fit.
  \
  \ See: `resize-menu-horizontally`, `resize-menu`,
  \ `center-menu-vertically`, `menu-top-margin`, `menu-bottom-margin`,
  \ `menu-borders`.
  \
  \ }doc

: resize-menu ( menu -- )
  dup resize-menu-horizontally resize-menu-vertically ;

  \ doc{
  \
  \ resize-menu ( menu -- )
  \
  \ Set the `~menu-width` and `~menu-height` fields of the menu
  \ identified by _menu_ to make its titles and options fit.
  \
  \ See: `resize-menu-horizontally`, `resize-menu-vertically`,
  \ `center-menu`.
  \
  \ }doc

: shrink-menu ( menu -- )
  1 to menu-top-margin
  2 to menu-left-margin
  1 to menu-right-margin
  1 to menu-bottom-margin
  resize-menu ;

  \ doc{
  \
  \ shrink-menu ( menu -- )
  \
  \ Set the generic menu margins (`menu-top-margin`,
  \ `menu-bottom-margin`, `menu-left-margin`, `menu-right-margin`) to
  \ their default values.  Then resize the menu identified by _menu_.
  \
  \ See: `resize-menu`, `center-menu`.
  \
  \ }doc

: blank-menu-options {: menu -- :}
  menu menu-options-last-row 1+ menu menu-options-first-row ?do
    menu ~menu-column @ 1+ i at-xy
    menu ~menu-width @ menu-borders - spaces
  loop ;

  \ doc{
  \
  \ blank-menu ( menu -- )
  \
  \ Blank the options of the menu identified by _menu_, by
  \ overwritting them with spaces. The border and the title are
  \ preserved.
  \
  \ See: `blank-menu`, `.menu`.
  \
  \ }doc

: blank-menu {: menu -- :}
  menu ~menu-row @ menu ~menu-height @ bounds ?do
    menu ~menu-column @ i at-xy
    menu ~menu-width @ spaces
  loop ;

  \ doc{
  \
  \ blank-menu ( menu -- )
  \
  \ Blank the menu identified by _menu_, by overwritting it with
  \ spaces.
  \
  \ See: `blank-menu-options`, `.menu`.
  \
  \ }doc

: .menu-border {: menu -- :}
  menu ~menu-column @ menu ~menu-row    @
  menu ~menu-width  @ menu ~menu-height @ blank-rectangle ;

  \ doc{
  \
  \ .menu-border ( menu -- )
  \
  \ Display the border of the menu identified by _menu_, using
  \ `blank-rectangle`.
  \
  \ See: `.menu`, `~menu-column`, `~menu-row`, `~menu-width`,
  \ `~menu-height`, `rectangle-style`.
  \
  \ }doc

private

: (.menu-title) ( menu ca len -- )
  rot >r in-spaces dup
      r@ ~menu-width @ tuck min - 2/
      r@ ~menu-column @ +
      r> ~menu-row @ at-xy type ;
  \ XXX TODO -- Use minimum left margin for titles.

public

: .menu-title ( menu -- )
  dup menu>title$ dup if (.menu-title) else 2drop drop then ;

  \ doc{
  \
  \ .menu-title ( menu -- )
  \
  \ Display the title of the menu identified by _menu_.
  \
  \ See: `.menu`, `.menu-border`.
  \
  \ }doc

: menu-option>x ( menu option -- col )
  drop ~menu-column @ 1+ menu-left-margin + ;

: menu-option>y ( menu option -- row )
  swap ~menu-row @ 1+ menu-top-margin + + ;

: menu-option>xy ( menu option -- col row )
  2dup menu-option>x -rot menu-option>y ;

: menu-option>submenu-xy ( menu option -- col row )
  over dup ~menu-column @ swap ~menu-width @ +
  -rot menu-option>y ;

: menu-option>left-margin-xy ( menu option -- col row )
  menu-option>xy menu-left-margin negate under+ ;

: (unhighlight-menu-option) ( menu option -- )
  menu-option>left-margin-xy at-xy menu-left-margin spaces ;

  \ doc{
  \
  \ (unhighlight-menu-option) ( menu option -- )
  \
  \ Default action of `unhighlight-menu-option`: Unhighlight option number
  \ _option_ of the menu identified by _menu_, by overwritting its
  \ left margin with spaces.
  \
  \ }doc

defer unhighlight-menu-option ( menu option -- )
  ' (unhighlight-menu-option) is unhighlight-menu-option

  \ doc{
  \
  \ unhighlight-menu-option ( menu option -- )
  \
  \ Unhighlight option number _option_ of the menu identified by
  \ _menu_.
  \
  \ ``unhighlight-menu-option`` is a deferred word whose default action is
  \ `(unhighlight-menu-option)`.
  \
  \ See: `highlight-menu-option`, `.menu`, `ceasing-menu`,
  \ `unceasing-menu`.
  \
  \ }doc

: (highlight-menu-option) ( menu option -- )
  menu-option>left-margin-xy menu-left-margin 2 - under+
  at-xy ." >" ;

  \ doc{
  \
  \ (highlight-menu-option) ( menu option -- )
  \
  \ Default action of `highlight-menu-option`: Highlight option number
  \ _option_ of the menu identified by _menu_, by writting a '>'
  \ character on its left margin.
  \
  \ }doc

defer highlight-menu-option ( menu option -- )
  ' (highlight-menu-option) is highlight-menu-option

  \ doc{
  \
  \ highlight-menu-option ( menu option -- )
  \
  \ Highlight option number _option_ of the menu identified by _menu_.
  \
  \ ``highlight-menu-option`` is a deferred word whose default action is
  \ `(highlight-menu-option)`.
  \
  \ See: `unhighlight-menu-option`, `.menu`, `ceasing-menu`,
  \ `unceasing-menu`.
  \
  \ }doc

: current-option? ( menu option -- f ) swap ~menu-option @ = ;

: .menu-option {: menu option -- :}
  menu option menu-option>xy at-xy
  menu option menu-option>string
  menu menu-options-width type-left-field
  menu option current-option?
  if menu option highlight-menu-option then ;

  \ doc{
  \
  \ .menu-option ( menu option -- )
  \
  \ Display option number _option_ of the menu identified by _menu_.
  \
  \ See: `.menu-options`, `.menu`.
  \
  \ }doc

: .menu-options ( menu -- ) dup #visible-menu-options 0
                            ?do dup i .menu-option loop drop ;

  \ doc{
  \
  \ .menu-options ( menu -- )
  \
  \ Display the visible options of the menu identified by _menu_.
  \
  \ See: `.menu`.
  \
  \ }doc

private

: fix-menu-height ( menu -- )
  dup >r ~menu-height  @
      r@ ~menu-options @ menu-top-margin + menu-bottom-margin +
                         menu-borders +
      max r> ~menu-height ! ;
  \ Make sure the _menu_ height is enough.
  \
  \ XXX TMP -- Until the rounding is implemented.

public

: .menu ( menu -- ) dup fix-menu-height
                    dup .menu-border
                    dup .menu-title
                        .menu-options ;

  \ doc{
  \
  \ .menu ( menu -- )
  \
  \ Display the menu identified by _menu_.
  \
  \ See: `.menu-border`, `.menu-title`, `.menu-options`,
  \ `center-menu`, `resize-menu`, `shrink-menu`, `ceasing-menu`,
  \ `unceasing-menu`.
  \
  \ }doc

private

: round-menu-option ( menu option -- option' )
  swap {: menu :}
  dup 0 menu ~menu-options @ within ?exit
      polarity ( -1|1) 0< ( -1|0) menu ~menu-options @ 1- and ;

: limit-menu-option ( menu option -- option' )
  0 max swap ~menu-options @ 1- min ;

: adjust-menu-option ( menu option -- option' )
  over ~menu-rounding @ if   round-menu-option
                        else limit-menu-option then ;

: update-menu-option ( menu n -- )
  over tuck ~menu-option @ +
            adjust-menu-option 2dup swap ~menu-option !
            highlight-menu-option ;
  \ Add _n_ to the current option, make the result fit the
  \ valid range and make it the current option.

: unhighlight-current-option ( menu -- )
  dup ~menu-option @ unhighlight-menu-option ;

: previous-menu-option ( menu -- )
  dup unhighlight-current-option -1 update-menu-option ;

: next-menu-option ( menu -- )
  dup unhighlight-current-option 1 update-menu-option ;

public

k-up value menu-fkey-up

  \ doc{
  \
  \ menu-fkey-up ( -- u )
  \
  \ A ``value``. _u_ is the function key used to navigate the menu up.
  \ Its default value is ``k-up``.
  \
  \ See: `menu-fkey-down`, `menu-key-choose`, `menu-key-exit`,
  \ `menu>option`.
  \
  \ }doc

k-down value menu-fkey-down

  \ doc{
  \
  \ menu-fkey-down ( -- u )
  \
  \ A ``value``. _u_ is the function key used to navigate the menu
  \ down.  Its default value is ``k-down``.
  \
  \ See: `menu-fkey-up`, `menu-key-choose`, `menu-key-exit`,
  \ `menu>option`.
  \
  \ }doc

13 value menu-key-choose \ enter key

  \ doc{
  \
  \ menu-key-choose ( -- c )
  \
  \ A ``value``. _c_ is the character used to choose a menu option.
  \ Its default value is 13, corresponding to the Enter key.
  \
  \ See: `menu-fkey-up`, `menu-fkey-down`, `menu-key-exit`,
  \ `menu>option`.
  \
  \ }doc

27 value menu-key-exit   \ escape key

  \ doc{
  \
  \ menu-key-exit ( -- c )
  \
  \ A ``value``. _c_ is the character used to exit from a menu.
  \ Its default value is 27, corresponding to the Escape key.
  \
  \ See: `menu-fkey-up`, `menu-fkey-down`, `menu-key-choose`,
  \ `menu>option`.
  \
  \ }doc

: menu>option {: menu -- option | -1 :}
  menu menu ~menu-option @ highlight-menu-option
  begin ekey
    ekey>fkey if
      case
        menu-fkey-up   of menu previous-menu-option endof
        menu-fkey-down of menu next-menu-option     endof
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


  \ doc{
  \
  \ menu>option ( menu -- option | -1 )
  \
  \ Activate the menu identified by _menu_, which is supposed to be
  \ already displayed by `.menu`.  If the user escapes the menu,
  \ return _-1_; otherwise return the chosen _option_ (0 index).
  \
  \ The keys used to navigate the menu can be configured by
  \ `menu-fkey-up`, `menu-fkey-down`, `menu-key-choose`, and
  \ `menu-key-exit`.
  \
  \ See: `ceasing-menu`, `unceasing-menu`.
  \
  \ }doc

: unceasing-menu ( menu -- option | -1 )
  dup .menu menu>option ;

  \ doc{
  \
  \ unceasing-menu ( menu -- option | -1 )
  \
  \ Display and activate _menu_ as an unceasing menu, i.e. the menu
  \ will remain on the screen when the user chooses an option or
  \ escapes. If the user escapes the menu, return _-1_; otherwise
  \ return the chosen _option_ (0 index).
  \
  \ See: `ceasing-menu`, `.menu`, `menu>option`, `create-menu`,
  \ `allocate-menu`.
  \
  \ }doc

: ceasing-menu ( menu -- option | -1 )
  dup unceasing-menu swap blank-menu ;

  \ doc{
  \
  \ ceasing-menu ( menu -- option | -1 )
  \
  \ Display and activate _menu_ as a ceasing menu, i.e. the menu will
  \ be removed from the screen when the user chooses an option or
  \ escapes. If the user escapes the menu, return _-1_; otherwise
  \ return the chosen _option_ (0 index).
  \
  \ See: `unceasing-menu`, `.menu`, `menu>option`, `blank-menu`,
  \ `create-menu`, `allocate-menu`.
  \
  \ }doc

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
\
\ 2018-07-31: Add `option>string`, `menu>title$`, `resize-menu`.  Add
\ `option>submenu-xy` and `shrink-menu`. Start documentation. Rename
\ many public words (make them longer, more explicit, to prevent name
\ clashes). Add constant `menu-borders` to make some calculations
\ clearer.
\
\ 2018-08-01: Advance documentation.
\
\ 2018-08-02: Advance documentation.
\
\ 2018-08-09: Advance documentation.
