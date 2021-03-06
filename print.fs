\ galope/print.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2015, 2017.

\ Based on:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License

\ ==============================================================
\ XXX TODO --

\ 2013:
\   Top left coordinates. Margins.
\   Real time 'print_width'.
\   UTF-8 support.
\ 2014-02-19: Rename all interface words homogeneously and with a simpler
\   convention than "print_".

\ ==============================================================

require ./package.fs
require ./column.fs
require ./home.fs
require ./last-row.fs
require ./question-question.fs
require ./warning-paren.fs
require ./xy.fs

require ffl/trm.fs

warnings @ [if]

  warning( `print` is deprecated, superseded by `ltype`)

[then]

package galope-print

public

variable #printed   \ Printed chars in the current line.
variable #indented   \ Indented chars in the current line.
: printed+  ( u -- )
  #printed +!
  ;
: indented+  ( u -- )
  #indented +!
  ;
: (.word) ( ca len -- )
  dup printed+ type
  ;
: .char  ( c -- )
  emit 1 printed+
  ;
: not_at_home?  ( -- f )
  xy +
  ;

public

: no_printed
  #printed off #indented off
  ;
: print_home
  home no_printed
  ;
: print_page
  page print_home
  ;

false [if]  \ First version, buggy

\ Bug: 'at-x' changed the cursor position in some cases because
\ of the way 'xy' works, though the actual reason is not clear
\ for me yet.

: print_start_of_line
  0 at-x no_printed
  ;

[else]  \ Safe alternative

  : print_start_of_line
  #printed @ trm+move-cursor-left no_printed
  ;

[then]

false [if]  \ First version

: print_cr
  not_at_home? if  cr  then  no_printed
  ;

[else]  \ Experimental

private

: at_last_start_of_line?  ( -- f )
  xy last-row = swap 0= and
  ;
: not_at_start_of_line?  ( -- f )
  column 0<>
  ;
: print_cr?  ( -- f )
  not_at_home? not_at_start_of_line? and
  \ xxx fixme 2012-09-30 what this was for?:
  \ at_last_start_of_line? 0= or
  ;

public

defer (print_cr) ' cr is (print_cr)

: print_cr
  print_cr? ?? (print_cr) no_printed
  ;

[then]

variable print_width

private

: previous_word?  ( -- f )
  #printed @ #indented @ >
  ;
: ?space  ( -- )
  previous_word? if  bl .char  then
  ;
: current_print_width  ( -- u )
  print_width @ ?dup 0= ?? cols
  ;
: too_long?  ( u -- f )
  1+ #printed @ + current_print_width >
  ;
: .word  ( ca len -- )
  dup too_long? if  print_cr  else  ?space  then  (.word)
  ;

: (print_indentation)  ( u -- )
  dup trm+move-cursor-right dup indented+ printed+
  ;

public

\ : print_x+  ( u -- )  \ xxx not used
\   dup column + at-x printed+
\   ;
: print_indentation  ( u -- )
  ?dup ?? (print_indentation)
  ;

private

: /word  ( ca1 len1 -- ca2 len2 ca3 len3 )
  \ ca1 len1 = Text.
  \ ca2 len2 = Same text, from the start of its first word.
  \ ca3 len3 = Same text, from the char after its first word.
  bl skip 2dup bl scan
  ;
: >word  ( ca1 len1 ca2 len2 -- ca2 len2 ca1 len4 )
  \ ca1 len1 = Text, from the start of its first word.
  \ ca2 len2 = Same text, from the char after its first word.
  \ ca1 len4 = First word of the text.
  tuck 2>r -  2r> 2swap ;
: first_word  ( ca1 len1 -- ca2 len2 ca3 len3 )
  /word >word
  ;
: (print)  ( ca1 len1 -- ca2 len2 )
  first_word .word
  ;

public

: print  ( ca len --)
  begin  dup   while  (print)  repeat  2drop
  ;

0 [if]

\ Suggested usage in the application:

4 value indentation
: paragraph  ( ca len -- )
  print_cr indentation print_indentation print
  ;

\ The Galope module "paragraph" implements it.

[then]

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
\ 2016-06-22: Fork to <l-type.fs>, in order to improve it
\ and replace it gradually, without breaking existing code.
\
\ 2017-08-17: Update change log layout. Update stack notation. Update
\ section rulers.
\
\ 2017-08-18: Use `package` instead of `module:`. Add missing
\ requirement of `xy`.
\
\ 2017-11-14: Add a warning about the deprecation.
