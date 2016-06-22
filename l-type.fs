\ galope/l-type.fs
\ Left justified version of `type`.

\ This file is part of Galope

\ Copyright (C) 2012,2013,2014,2015 Marcos Cruz (programandala.net)

\ Based on:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License

\ ==============================================================
\ Development history

\ At the end of this file.

\ ==============================================================
\ XXX TODO

\ - Top left coordinates.
\ - Margins.
\ - Real time `l-width`.
\ - UTF-8 support.

\ ==============================================================

require ./module.fs
require ./column.fs
require ./home.fs
require ./last-row.fs

require ffl/trm.fs

module: galope-l-type-module

export

variable #typed    \ Printed chars in the current line.

variable #indented   \ Indented chars in the current line.

: typed+  ( u -- )  #typed +!  ;

: indented+  ( u -- )  #indented +!  ;

: (.word) ( ca len -- )  dup typed+ type  ;

: l-emit  ( c -- )  emit 1 typed+  ;

: l-space  ( -- )  bl l-emit  ;

: not-at-home?  ( -- wf )  xy + 0<>  ;

: no-typed  ( -- )  #typed off  #indented off  ;

: l-home  ( -- )  home no-typed  ;

: l-page  ( -- )  page l-home  ;

false [if]

\ XXX OLD -- Buggy first version: 'at-x' changed the cursor position
\ in some cases because of the way 'xy' works, though the actual
\ reason is not clear yet.

: l-start-of-line  ( -- )
  0 at-x no-typed  ;

[else]

\ XXX NEW -- safe alternative

: l-start-of-line  ( -- )
  #typed @ trm+move-cursor-left no-typed  ;

[then]

false [if]

\ XXX OLD -- first version

: l-cr  ( -- )
  not-at-home? if  cr  then  no-typed  ;

[else]

\ XXX NEW -- experimental

hide

: at-last-start-of-line?  ( -- wf )
  xy last-row = swap 0= and  ;

: not-at-start-of-line?  ( -- wf )
  column 0<>  ;

: l-cr?  ( -- wf )
  not-at-home? not-at-start-of-line? and
  \ XXX FIXME -- 2012-09-30 what this was for?:
  \ at-last-start-of-line? 0= or
  ;
  \ XXX OLD

export

defer (l-cr)  ( -- )
' cr is (l-cr)

: unconditional-l-cr  ( -- )  (l-cr)  no-typed  ;

: l-cr  ( -- )  l-cr? if  unconditional-l-cr  then  ;

[then]

variable l-width

hide

: previous-word?  ( -- wf )
  #typed @ #indented @ >  ;

: ?space  ( -- )
  previous-word? if  l-space  then  ;

: current-print-width  ( -- u )
  l-width @ ?dup 0= if  cols  then  ;

: too-long?  ( u -- wf )
  1+ #typed @ + current-print-width >  ;

: .word  ( ca len -- )
  dup too-long? if  l-cr  else  ?space  then  (.word)  ;

: (indent)  ( u -- )
  dup trm+move-cursor-right dup indented+ typed+  ;

export

: indent  ( u -- )
  ?dup if  (indent)  then  ;
  \ Indent _u_ spaces.

hide

: /word  ( ca1 len1 -- ca2 len2 ca3 len3 )
  bl skip 2dup bl scan  ;
  \ ca1 len1 = Text.
  \ ca2 len2 = Same text, from the start of its first word.
  \ ca3 len3 = Same text, from the char after its first word.

: >word  ( ca1 len1 ca2 len2 -- ca2 len2 ca1 len4 )
  tuck 2>r -  2r> 2swap ;
  \ ca1 len1 = Text, from the start of its first word.
  \ ca2 len2 = Same text, from the char after its first word.
  \ ca1 len4 = First word of the text.

: first-word  ( ca1 len1 -- ca2 len2 ca3 len3 )
  /word >word  ;

: (l-type)  ( ca1 len1 -- ca2 len2 )
  first-word .word  ;

export

: l-type  ( ca len -- )
  begin  dup   while  (l-type)  repeat  2drop  ;
  \ Type _ca len_ left justified.

2 value indentation
  \ Spaces at the left of the first line of a new paragraph.

1 value rows-between-paragraphs
  \ Blanks rows between paragraphs.

hide

: separate-paragraph  ( -- )
  rows-between-paragraphs 1+ 0 ?do  unconditional-l-cr  loop  ;

export

: paragraph  ( -- )
  separate-paragraph indentation indent  ;
  \ Start a new paragraph.

: pl-type  ( ca len -- )
  paragraph l-type  ;
  \ Start a new paragraph and type _ca len_ left justified.

;module

\ ==============================================================
\ Development history

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
