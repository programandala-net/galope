\ galope/print.fs
\ Left justified print
 
\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ Based on:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Development history

\ At the end of this file.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ xxx todo

\ Top left coordinates. Margins.
\ Real time 'print_width'.
\ UTF-8 support.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require ./module.fs
require ./column.fs 
require ./home.fs 
require ./last_row.fs 
require ./question-question.fs 

require ffl/trm.fs

module: galope_print

export

variable #printed   \ Printed chars in the current line.
variable #indented   \ Indented chars in the current line.
: printed+  ( u -- )
  #printed +!
  ;
: indented+  ( u -- )
  #indented +!
  ;
: (.word) ( a u -- )
  dup printed+ type
  ;
: .char  ( c -- )
  emit 1 printed+
  ;
: not_at_home?  ( -- f )
  xy +
  ;

export

: no_printed
  #printed off #indented off
  ;
: print_home
  home no_printed
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
  
hide

: at_last_start_of_line?
  xy last_row = swap 0= and
  ;
: not_at_start_of_line?
  column 0<>
  ;
: print_cr?  ( -- ff )
  not_at_home? not_at_start_of_line? and
  \ xxx fixme 2012-09-30 what this was for?:
  \ at_last_start_of_line? 0= or
  ;

export

defer (print_cr) ' cr is (print_cr)

: print_cr
  print_cr? ?? (print_cr) no_printed
  ;

[then]

variable print_width

hide

: previous_word?  ( -- ff )
  #printed @ #indented @ >
  ;
: ?space
  previous_word? if  bl .char  then
  ;
: current_print_width  ( -- u )
  print_width @ ?dup 0= ?? cols
  ;
: too_long?  ( u -- ff )
  1+ #printed @ + current_print_width >
  ;
: .word  ( a u -- )
  dup too_long? if  print_cr  else  ?space  then  (.word)
  ;

: (print_indentation)  ( u -- )
  dup trm+move-cursor-right dup indented+ printed+
  ;

export

\ : print_x+  ( u -- )  \ xxx not used
\   dup column + at-x printed+
\   ;
: print_indentation  ( u -- )
  ?dup ?? (print_indentation)
  ;

hide

: /word  ( a1 u1 -- a2 u2 a3 u3 )
  \ a1 u1 = Text.
  \ a2 u2 = Same text, from the start of its first word.
  \ a3 u3 = Same text, from the char after its first word.
  bl skip 2dup bl scan
  ;
: >word  ( a1 u1 a2 u2 -- a2 u2 a1 u4 )
  \ a1 u1 = Text, from the start of its first word.
  \ a2 u2 = Same text, from the char after its first word.
  \ a1 u4 = First word of the text.
  tuck 2>r -  2r> 2swap ; 
: first_word  ( a1 u1 -- a2 u2 a3 u3 )
  /word >word
  ;
: (print)  ( a1 u1 -- a2 u2 )
  first_word .word
  ;

export

: print  ( a u --)
  begin   dup
  while   (print)
  repeat  2drop
  ;

0 [if]

\ Suggested usage in the application:

4 value indentation
: paragraph  ( a u -- )
  print_cr indentation print_indentation print
  ;

\ The Galope module "paragraph" implements it.

[then]

;module

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Development history

\ 2012-04-17 Words renamed and factorized. Adapted to Gforth.

\ 2012-04-18 Added 'module.fs'. Name fixed. Added 'xy.fs'.
\ First working version.

\ 2012-05-01 Fix: '?cr' now checks not only the row, but the
\ column.  Second, experimental version with 'column'.

\ 2012-05-02 '?cr' removed; 'print_cr' and 'unhome?' used
\ instead.  New words 'print_x+' and 'print_indentation' provide
\ the low level interface for indentation.

\ 2012-05-07 'print_indentation' moves the cursor instead of
\ printing spaces (that changed the background color); the trm
\ module from the Free Foundation Library is used.

\ 2012-05-08 Exported 'no_printed'; added 'print_home' (a proper
\ 'home').  'unhome?' renamed 'not_at_home?'.  New version of
\ 'print_start_of_line', based on Forth Foundation Library's trm
\ module.

\ 2012-05-17 Removed the deprecated alternative slow version.
\ Now 'cr' is defered by '(print_cr)', what makes it possible to
\ achive some special effects in the application, e.g. coloring
\ the new lines at the bottom of the screen.

\ 2012-09-29 Fixed: a 'hide' was missing. A check was missing in
\ 'print_indentation' because the FFL's 'trm+move-cursor-right'
\ moves the cursor one column when the parameter is 1! The same
\ happens with 'trm+move-cursor-left'. The author of FFL has
\ been contacted.

\ 2012-09-30 Fixed: 'at_last_start_of_line?' used the
\ coordinates in the wrong order.

\ 2012-11-30 Fixed: 'print_cr?'.

