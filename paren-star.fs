\ galope/paren-star.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-11-26 First version.
\ 2013-11-27 New: '*)'.
\ 2013-11-27 Second version, block comment can be nested.
\ 2014-01-29 Fix: "./" path for 'require'.
\ 2014-02-13 Note: Just found an alternative implementation:
\   <http://www.forth200x.org/paren-star.txt>,
\   <https://groups.google.com/forum/#!topic/comp.lang.forth/K4d7f4CN7YU%5B126-150-false%5D>.
\ 2014-07-24 Included the implementation found in
\ <http://www.forth200x.org/paren-star.txt>, for reference.

: *)  ( -- )
  \ can be nested Close a block comment.
  true abort" '*)' without '(*'"
  ;  immediate

false [if]

\ First version, block comments can not be nested

: (*  ( -- )
  \ Start a block comment; blocks can not be nested.
  begin   parse-name dup 
    if    s" *)" str= 
    else  2drop refill 0= dup abort" Missing closing '*)'"  then
  until
  ;  immediate

[else]

\ Second version, block comments can be nested

require ./plus-plus.fs  \ '++'
require ./minus-minus.fs  \ '--'

variable (*_count
: ((*)  { D: parsed_name -- wf }
  \ wf = end of the comment block?
  parsed_name s" (*" str= if  (*_count ++ false exit  then
  parsed_name s" *)" str= if  (*_count dup -- @ 0< exit  then
  false
  ;
: (*  ( -- )
  \ Start a block comment; blocks can be nested.
  (*_count off
  begin  parse-name dup 
    if  ((*)  else  2drop refill 0= dup abort" Missing closing '*)'"  then
  until
  ;  immediate

[then]

0 [if]

Extract from <http://www.forth200x.org/paren-star.txt>:

Reference Implementation
------------------------

: MAYBE-REFILL ( S: -- flag )    \ refill if at end of line, 0 if
can't
   SOURCE NIP >IN @ > DUP 0= IF DROP REFILL THEN ;

: (* ( S: -- )                   \ multi-line comment, ended by *)
   BEGIN
     BL WORD COUNT 2DUP S" *)" COMPARE WHILE
       S" (*" COMPARE 0= IF RECURSE THEN
       MAYBE-REFILL WHILE
     REPEAT
     0 0 CR ." Your system can do anything at this point and still be
a standard system."
   THEN 2DROP ; IMMEDIATE

BL WORD COUNT can be replaced by PARSE-NAME when the time comes.

It would not be difficult to make a CREATE DOES> word which defines
new words like (* with new ending strings different from *) . I may do
that.

Remarks
-------

I don't care what name we use provided we can agree on one.
I dislike using /* because there might be some use for files where
Forth code is in C comments and vice versa. Also */ is a Forth word.

(( has been in use for many years by MPE and by Win32Forth as a non-
nestable multiline comment. A nestable version should have a different
name. Also, (( is used in iForth for something completely different.

Other suggestions for names:  \\  --- ( in both cases, the next
instance toggles rather than nests)

[then]
