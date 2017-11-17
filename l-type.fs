\ galope/l-type.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Description:
\
\ Left justified version of `type`.

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014,
\ 2015, 2016, 2017.

\ Credits:
\
\ This code was inspired by:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer

\ Last modified 201711172219
\ See change log at the end of the file.

\ ==============================================================
\ Requirements

require ./column.fs             \ `column`
require ./home-question.fs      \ `home?`
require ./home.fs               \ `home`
require ./package.fs            \ `package`
require ./row.fs                \ `row`
require ./slash-first-name.fs   \ `/first-name`

\ From Forth Foundation Library:

require ffl/trm.fs

\ ==============================================================

package galope-l-type

public

variable lrow#
  \ Current line of the paragraph (the first one is 0).

variable lrows# 0 lrows# !
  \ Lines displayed on the current page.

: next-lrow ( -- ) 1 lrow# +!  1 lrows# +! ;

variable ltyped#
  \ Characters typed in the current line.

: ltyped ( u -- ) ltyped# +! ;

private

variable #indented
  \ Indented chars in the current line.

: (indent) ( u -- )
  dup trm+move-cursor-right dup #indented +! ltyped ;

: (.word) ( ca len -- ) dup ltyped type ;

public

: no-ltyped ( -- ) ltyped# off #indented off ;

variable lmore lmore off

  \ doc{
  \
  \ lmore ( -- a )
  \
  \ _a_ is the address of a cell containing a flag, whose
  \ default value is _false_. When ``lmore`` is _true_, the
  \ left-justified diplaying system displays a prompt when the
  \ screen is full.
  \
  \ See: `lprompt`, `ltype`.
  \
  \ }doc

: (lprompt)$ ( -- ca len ) s" ..." ;

  \ doc{
  \
  \ (lprompt)$ ( -- ca len ) s" ..." ;
  \
  \ _ca len_ is the default prompt used by the `ltype`
  \ displaying system when the screen is full.  ``(lprompt)$``
  \ is the default action of `lprompt$`.
  \
  \ }doc

defer lprompt$ ( -- ca len )

  \ doc{
  \
  \ lprompt$ ( -- ca len )
  \
  \ _ca len_ is the prompt used by the `ltype` displaying
  \ system when the screen is full. ``lprompt$``is a deferred
  \ word whose default action is `(lprompt)$`.
  \
  \ }doc

' (lprompt)$ is lprompt$

: ?indent ( u -- ) ?dup if (indent) then ;

  \ doc{
  \
  \ ?indent ( u -- )
  \
  \ ?indent _u_ spaces.
  \
  \ See: `indent`.
  \
  \ }doc

2 value indentation1

  \ doc{
  \
  \ indentation1 ( -- n )
  \
  \ Return the number _n_ of spaces at the left of the first
  \ line of a new paragraph. ``indentation1`` is a ``value``.
  \ Its default value is 2.
  \
  \ See `indentation2`, `/paragraph`.
  \
  \ }doc

synonym indentation indentation1 \ XXX OLD -- for retrocompatibility

  \ doc{
  \
  \ indentation ( -- n )
  \
  \ Old name of `indentation1`, for retrocompatibility.
  \
  \ }doc

0 value indentation2

  \ doc{
  \
  \ indentation2 ( -- n )
  \
  \ Return the number _n_ of spaces at the left of the second
  \ and following lines of a new paragraph. ``indentation2`` is
  \ a ``value``.  Its default value is 0.
  \
  \ See `indentation1`, `/paragraph`.
  \
  \ }doc

variable indent-top

  \ doc{
  \
  \ indent-top ( -- a )
  \
  \ _a_ is the address of a cell containing a flag. If the flag
  \ is _true_, the first line of a paragraph is indented even
  \ at the top of the page, ie. at row zero. If the flag is
  \ _false_ (the default value), the first line of a paragraph
  \ is not indented at the top of the page.
  \
  \ See: `indent`, `indentation1`.
  \
  \ }doc

private

: (indentation1) ( -- n )
  indentation1 row 0= if indent-top @ and then ;
  \ Actual value of `indentation1`, depending on the flag
  \ `indent-top`.

public

: indent ( -- )
  lrow# @ if indentation2 else (indentation1) then ?indent ;

  \ doc{
  \
  \ indent ( -- )
  \
  \ Indent the proper number of spaces (`indentation1` or
  \ `indentation2`) depending on the current line of the
  \ paragraph.
  \
  \ See: `?indent`.
  \
  \ }doc

: lemit ( c -- ) emit 1 ltyped ;

  \ doc{
  \
  \ lemit ( c -- )
  \
  \ Display character _c_ as part of the left-justified displaying
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
  \ Display a space as part of the left-justified displaying
  \ system.
  \
  \ See: `lemit`, `ltype`.
  \
  \ }doc

: lhome ( -- ) home no-ltyped lrow# off lrows# off ;

  \ doc{
  \
  \ lhome ( -- )
  \
  \ Move the cursor used by `ltype` and related words to its
  \ home position, at the top left (column 0, row 0).
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

rows 2 - value lrows ( -- n )

  \ doc{
  \
  \ lrows ( -- n )
  \
  \ _n_ is the number of rows per page displayed by `ltype`.
  \ ``lrows`` is a ``value`` whose default content is ``rows 2
  \ -``.
  \
  \ }doc

: lcr? ( -- f ) home? 0= column 0<> and ;

  \ doc{
  \
  \ lcr? ( -- f )
  \
  \ Is the cursor to the next row neither at the home position
  \ nor at the start of a line?  ``lcr?`` is part of the
  \ left-justified displaying system.
  \
  \ See: `lcr`, `ltype`.
  \
  \ }doc

: lpage? ( -- ? ) lrows# @ lrows > ;

  \ doc{
  \
  \ lpage? ( -- f )
  \
  \ Is the page full?  ``lpage?`` is part of the left-justified
  \ displaying system.
  \
  \ See: `ltype`,  `lcr?`,
  \
  \ }doc

: (lprompt-pause) ( -- ) key drop ;

  \ doc{
  \
  \ (lprompt-pause) ( -- )
  \
  \ Default action of `lprompt-pause`: wait for a key press.
  \
  \ }doc

defer lprompt-pause ( -- ) ' (lprompt-pause) is lprompt-pause

  \ doc{
  \
  \ lprompt-pause ( i*x -- )
  \
  \ A deferred word used by `this-lprompt`, which is part of
  \ the `ltype` system; its default action is
  \ `(lprompt-pause)`.  _i*x_ is a possible optional parameter
  \ needed by alternative actions.
  \
  \ }doc

: this-lprompt ( i*x ca len -- )
  xy    2>r dup >r type lprompt-pause r>
        2r@ at-xy spaces
        2r> at-xy
  lrows# off ;

  \ doc{
  \
  \ this-lprompt ( i*x ca len -- )
  \
  \ Display prompt _ca len_, execute `lprompt-pause` with
  \ optional parameters _i*x_ and remove the prompt restoring
  \ the original position of the cursor.
  \
  \ ``this-lprompt`` is a factor of `lprompt`, which is part of
  \ the `ltype` displaying system.
  \
  \ }doc

: lprompt ( i*x -- ) lprompt$ this-lprompt ;

  \ doc{
  \
  \ lprompt ( i*x -- )
  \
  \ Manage the prompt of the `ltype` system: Execute `this-lprompt`
  \ with `lprompt$` as parameter. _i*x_ is an optional parameter for
  \ `lprompt-pause`.
  \
  \ }doc

defer ((lcr)) ( -- ) ' cr is ((lcr))

  \ doc{
  \
  \ ((lcr)) ( -- )
  \
  \ A deferred word whose default action is ``cr``.  This is
  \ the actual carriage return done by `(lcr)`, before updating
  \ the data of the left-justified displaying system.
  \ ``((lcr))`` is a hook for the application, for special
  \ cases.
  \
  \ }doc

: (lcr) ( -- )
  ((lcr)) next-lrow no-ltyped lpage? if lprompt then indent ;

  \ doc{
  \
  \ (lcr) ( -- )
  \
  \ Move the cursor to the next row, if it's neither at the home
  \ position nor at the start of a line. ``lcr`` is part of the
  \ left-justified displaying system.
  \
  \ See: `ltype`.
  \
  \ }doc

: lcr ( -- ) lcr? if (lcr) then ;

  \ doc{
  \
  \ lcr ( -- )
  \
  \ If needed, move the cursor to the next row, ``lcr`` is part
  \ of the left-justified displaying system.
  \
  \ See: `lcr?`, `(lcr)`, `ltype`.
  \
  \ }doc

variable lwidth cols lwidth !

  \ doc{
  \
  \ lwidth ( -- a )
  \
  \ A variable containing the text width in columns used by
  \ `ltype` and related words. Its default value is ``cols``,
  \ ie. the current width of the screen.
  \
  \ }doc

private

: previous-word? ( -- f ) ltyped# @ #indented @ > ;

: ?space ( -- ) previous-word? if lspace then ;

: unfit? ( u -- f ) 1+ ltyped# @ + lwidth @ > ;

: .word ( ca len -- )
  dup unfit? if lcr else ?space then (.word) ;

public

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

1 value /paragraph

  \ doc{
  \
  \ /paragraph ( -- n )
  \
  \ Blank rows between paragraphs. ``/paragraph`` is a
  \ ``value`` whose default value is 1.
  \
  \ See: `indentation1`, `indentation2`, `paragraph`.
  \
  \ }doc

private

: (paragraph) ( -- ) /paragraph 1+ 0 ?do (lcr) loop ;

public

: paragraph ( -- )
  home? 0= if (paragraph) then lrow# off indent ;

  \ doc{
  \
  \ paragraph ( -- )
  \
  \ Start a new paragraph. Used by `/ltype` and `/l."`.
  \
  \ }doc

: /ltype ( ca len -- ) paragraph ltype ;

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

require ./n-to-str.fs

: t ( n -- )
  0 ?do
    lrow#  @ n>str ltype
    lrows# @ n>str ltype
    s" En un lugar de La Mancha."
    ltype
  loop ;

\ ==============================================================
\ Change log

\ ----------------------------------------------
\ Old version, as <print.fs>

\ 2012-04-17: Words renamed and factorized. Adapted to Gforth.
\
\ 2012-04-18: Added 'module.fs'. Name fixed. Added 'xy.fs'.
\ First working version.
\
\ 2012-05-01: Fix: '?cr' now checks not only the row, but the
\ column.  Second, experimental version with 'column'.
\
\ 2012-05-02: '?cr' removed; 'print_cr' and 'unhome?' used
\ instead.  New words 'print_x+' and 'print_indentation'
\ provide the low level interface for indentation.
\
\ 2012-05-07: 'print_indentation' moves the cursor instead of
\ printing spaces (that changed the background color); the trm
\ module from the Free Foundation Library is used.
\
\ 2012-05-08: Exported 'no_printed'; added 'print_home' (a
\ proper 'home').  'unhome?' renamed 'not_at_home?'.  New
\ version of 'print_start_of_line', based on Forth Foundation
\ Library's trm module.
\
\ 2012-05-17: Removed the deprecated alternative slow version.
\ Now 'cr' is defered by '(print_cr)', what makes it possible
\ to achive some special effects in the application, e.g.
\ coloring the new lines at the bottom of the screen.
\
\ 2012-09-29: Fixed: a 'hide' was missing. A check was missing
\ in 'print_indentation' because the FFL's
\ 'trm+move-cursor-right' moves the cursor one column when the
\ parameter is 1! The same happens with 'trm+move-cursor-left'.
\ The author of FFL has been contacted.
\
\ 2012-09-30: Fixed: 'at_last_start_of_line?' used the
\ coordinates in the wrong order.
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

\ ----------------------------------------------
\ Current version, as <l-type.fs>

\ 2016-06-22: Forked from the `print` module, in order to
\ improve it and replace it gradually, without breaking
\ existing code. Rename: Replace underscores with hyphens. New
\ main interface words: `l-type` and `pl-type`. General
\ renaming.
\
\ 2017-07-14: Fix typo.
\
\ 2017-08-17: Update stack notation.  Change "l-" prefix to
\ "l". The name of the module remains "l-type", because it
\ reflects the pronunciation of the word, after the convention
\ used in the library.  Update source style. Remove
\ `l-start-of-line` and `at-last-start-of-line`, which were
\ unnecessary. Rename `pl-type` to `/ltype`. Rename
\ `rows-between-paragraphs` to `/paragraph`. Document the most
\ importart public words of the module.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-09-08: Replace `/word` with `/name`, whose definition is
\ identical and is part of the library already. Simplify
\ `ltype` with `/first-name`. Rename all "typed" to "ltyped".
\
\ 2017-10-11: Add missing requirement `/first-name`.
\
\ 2017-10-22: Add indentation for the second and following
\ lines.  Rename `l-width` `lwidth` and document it. Rename
\ `current-print-width` `width`. Rename `too-long?` `unfit?`.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-11-03: Improve change log.
\
\ 2017-11-16: Start implementation of a configurable "more?"
\ control.
\
\ 2017-11-17: Improve factoring, names and documentation.
\ Update requirements. Add flag `indent-top`, `lprompt-pause`,
\ and others.  Expand the public interface.  Fix `paragraph`:
\ do not separate the new paragraph if cursor is at the top
\ left corner of the screen.  Remove GPL license.
