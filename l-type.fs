\ galope/l-type.fs
\ Left justified version of `type`.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2015,
\ 2016, 2017.

\ Based on:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License

\ ==============================================================
\ XXX TODO

\ - Top left coordinates.
\ - Margins.
\ - Real time `l-width`.
\ - UTF-8 support.

\ ==============================================================

require ./column.fs
require ./home-question.fs
require ./home.fs
require ./last-row.fs
require ./package.fs
require ./slash-name.fs
require ./slash-first-name.fs

require ffl/trm.fs

package galope-l-type

public

variable #ltyped \ Printed chars in the current line.

variable #indented \ Indented chars in the current line.

: ltyped+ ( u -- ) #ltyped +! ;

: indented+ ( u -- ) #indented +! ;

: (.word) ( ca len -- ) dup ltyped+ type ;

: lemit ( c -- ) emit 1 ltyped+ ;

  \ doc{
  \
  \ lemit ( c -- )
  \
  \ Display character _c_ as part of the left-justified printing
  \ system.
  \
  \ See: `ltype`, `lspace`.
  \
  \ }doc

: lspace ( -- ) bl lemit ;

  \ doc{
  \
  \ lspace ( -- )
  \
  \ Display a space as part of the left-justified printing system.
  \
  \ See: `lemit`, `ltype`.
  \
  \ }doc

: no-ltyped ( -- ) #ltyped off #indented off ;

: lhome ( -- ) home no-ltyped ;

  \ doc{
  \
  \ lhome ( -- )
  \
  \ Move the cursor used by `ltype` and related words to its home
  \ position, at the top left (column 0, row 0).
  \
  \ }doc

: lpage ( -- ) page lhome ;

  \ doc{
  \
  \ lpage ( -- )
  \
  \ Clear the display and init the cursor used by `ltype` and related
  \ words.
  \
  \ }doc

private

: not-at-start-of-line? ( -- f )
  column 0<> ;

: lcr? ( -- f )
  home? 0= not-at-start-of-line? and ;

public

defer do-cr ( -- )
' cr is do-cr

  \ doc{
  \
  \ do-cr ( -- )
  \
  \ A deferred word whose default action is ``cr``.
  \ Used by `lcr`.
  \
  \ See: `lcr`.
  \
  \ }doc

: (lcr) ( -- ) do-cr no-ltyped ;

: lcr ( -- ) lcr? if (lcr) then ;

  \ doc{
  \
  \ lcr ( -- )
  \
  \ Move the cursor to the next row, if it's neither at the home
  \ position nor at the start of a line.
  \
  \ See: `ltype`.
  \
  \ }doc

variable l-width

private

: previous-word? ( -- f )
  #ltyped @ #indented @ > ;

: ?space ( -- )
  previous-word? if lspace then ;

: current-print-width ( -- u )
  l-width @ ?dup 0= if cols then ;

: too-long? ( u -- f )
  1+ #ltyped @ + current-print-width > ;

: .word ( ca len -- )
  dup too-long? if lcr else ?space then (.word) ;

: (indent) ( u -- )
  dup trm+move-cursor-right dup indented+ ltyped+ ;

public

: indent ( u -- )
  ?dup if (indent) then ;

  \ doc{
  \
  \ indent ( u -- )
  \
  \ Indent _u_ spaces.
  \
  \ See: `indentation`.
  \
  \ }doc

: ltype ( ca len -- )
  begin dup while /first-name .word repeat 2drop ;

  \ doc{
  \
  \ ltype ( ca len -- )
  \
  \ Type _ca len_ left justified.
  \
  \ See: `/ltype`, `l."`.
  \
  \ }doc

2 value indentation

  \ doc{
  \
  \ indentation ( -- n )
  \
  \ Return the number _n_ of spaces at the left of the first line of a
  \ new paragraph. ``indentation`` is a value.
  \
  \ See `/paragraph`.
  \
  \ }doc

1 value /paragraph

  \ doc{
  \
  \ /paragraph ( -- n )
  \
  \ Blank rows between paragraphs. ``/paragraph`` is a value.
  \
  \ See: `indentation`, `paragraph`.
  \
  \ }doc

private

: separate-paragraph ( -- )
  /paragraph 1+ 0 ?do (lcr) loop ;

public

: paragraph ( -- )
  separate-paragraph indentation indent ;

  \ doc{
  \
  \ paragraph ( -- )
  \
  \ Start a new paragraph. Used by `/ltype` and `/l."`.
  \
  \ }doc

: /ltype ( ca len -- )
  paragraph ltype ;

  \ doc{
  \
  \ /ltype ( ca len -- )
  \
  \ Start a new paragraph and type _ca len_ left justified.
  \
  \ See: `ltype`, `paragraph`, `/l."`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2012-04-17: Words renamed and factorized. Adapted to Gforth.
\
\ 2012-04-18: Added 'module.fs'. Name fixed. Added 'xy.fs'.  First
\ working version.
\
\ 2012-05-01: Fix: '?cr' now checks not only the row, but the column.
\ Second, experimental version with 'column'.
\
\ 2012-05-02: '?cr' removed; 'print_cr' and 'unhome?' used instead.
\ New words 'print_x+' and 'print_indentation' provide the low level
\ interface for indentation.
\
\ 2012-05-07: 'print_indentation' moves the cursor instead of printing
\ spaces (that changed the background color); the trm module from the
\ Free Foundation Library is used.
\
\ 2012-05-08: Exported 'no_printed'; added 'print_home' (a proper
\ 'home').  'unhome?' renamed 'not_at_home?'.  New version of
\ 'print_start_of_line', based on Forth Foundation Library's trm
\ module.
\
\ 2012-05-17: Removed the deprecated alternative slow version.  Now
\ 'cr' is defered by '(print_cr)', what makes it possible to achive
\ some special effects in the application, e.g. coloring the new lines
\ at the bottom of the screen.
\
\ 2012-09-29: Fixed: a 'hide' was missing. A check was missing in
\ 'print_indentation' because the FFL's 'trm+move-cursor-right' moves
\ the cursor one column when the parameter is 1! The same happens with
\ 'trm+move-cursor-left'. The author of FFL has been contacted.
\
\ 2012-09-30: Fixed: 'at_last_start_of_line?' used the coordinates in
\ the wrong order.
\
\ 2012-11-30: Fixed: 'print_cr?'.
\
\ 2013-08-30: Change: stack notation.
\
\ 2014-02-19: New: 'print_page'.
\
\ 2014-11-17: Module name updated.
\
\ 2015-10-13: Updated after the latest renamings in Galope.
\
\ 2015-10-16: Fixed some comments.
\
\ 2016-06-22: Forked from the `print` module, in order to improve it
\ and replace it gradually, without breaking existing code. Rename:
\ Replace underscores with hyphens. New main interface words: `l-type`
\ and `pl-type`. General renaming.
\
\ 2017-07-14: Fix typo.
\
\ 2017-08-17: Update stack notation.  Change "l-" prefix to "l". The
\ name of the module remains "l-type", because it reflects the
\ pronunciation of the word, after the convention used in the library.
\ Update source style. Remove `l-start-of-line` and
\ `at-last-start-of-line`, which were unnecessary. Rename `pl-type` to
\ `/ltype`. Rename `rows-between-paragraphs` to `/paragraph`. Document
\ the most importart public words of the module.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-09-08: Replace `/word` with `/name`, whose definition is
\ identical and is part of the library already. Simplify `ltype` with
\ `/first-name`. Rename all "typed" to "ltyped".
\
\ 2017-10-11: Add missing requirement `/first-name`.
