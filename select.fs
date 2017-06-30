\ galope/select.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

require ./between.fs
\ require ./thens.fs  \ xxx todo

\ **************************************************************
\ Origin of this code

\ This control structure has been taken from:

\     http://dxforth.netbay.com.au/miser.html
\     Miser's CASE - A general purpose Forth CASE statement
\     Revision 3  2008-11-30
\     Public domain

\ **************************************************************
\ Change history

0 [if]


2013-08-16: First changes to the original code:

- Change words to lowercase.
- Rename 'case' and 'endcase' to 'select' and 'endselect' (from SuperBASiC)
- Remove 'of' and 'endof'.
- Remove the code for other Forth systems than Gforth.
- Add stack and purpouse comments.
- Format the source after my house style.
- Use 'between' in '(range)'.

2013-08-17: Corrected the title of the test.  Note: 'thens' is not
immediate; Wil Baden's 'thens' is equivalent but immediate.

2015-10-25: Fixed the usage example.

[then]

\ **************************************************************
\ Syntax

0 [if]

  select  ( x0 )
     cond  <tests>  when    ... else
           <test>   if drop ... else
     ...   ( default )
  endselect

All clauses are optional.

<tests> may consist of one or more of the following:

   x1    equal  ( test if x0 and x1 are equal )
   x1 x2 range  ( test if x0 is in the range x1..x2 )

<test> can be any code that leaves x0 and a flag (0|<>0).
'if drop ... else' is for expansion, allowing user-defined tests.

'continue' may be placed anywhere within:

  when ... else
  if ( drop ) ... else

'continue' redirects program flow from previously matched
clauses that would otherwise pass to 'endselect'. It provides
"fall-through" capability akin to C's switch statement.

[then]

\ **************************************************************
\ Code

0 constant select  immediate
0 constant cond  immediate

: thens  ( 0 a'1 ... a'n -- )
  \ Compile the pending 'then'.
  begin  ?dup while  postpone then  repeat
  ;
: endselect  ( compile-time: 0 a'1 ... a'n -- ) ( run-time: x0 -- )
  postpone drop  thens
  ;  immediate
: when  ( compile-time: xxx ) ( run-time: xxx )  \ xxx todo stack
  postpone else  >r >r >r  thens  r> r> r>  postpone drop
  ;  immediate
: continue  ( compile-time: xxx ) ( run-time: xxx )  \ xxx todo stack
  >r >r >r thens  0  r> r> r>
  ;  immediate
: equal  ( compile-time:  -- ) ( run-time: x0 x1 -- )
  postpone over  postpone -  postpone if
  ;  immediate
: (range)  ( x0 x1 x2 -- x0 wf )
  2>r dup 2r> over - -rot - u<
  \ 2>r dup 2r> between
  ;
: range  ( -- )
  postpone (range)  postpone if
  ;  immediate

\ **************************************************************
\ Usage example

false [if]

hex

: select-test ( n -- )
  space
  select
    cond  00 1F range
          7F    equal  when  ." Control char "       else
    cond  20 2F range
          3A 40 range
          5B 60 range
          7B 7E range  when  ." Punctuation "        else
    cond  30 39 range  when  ." Digit "              else
    cond  41 5A range  when  ." Upper case letter "  else
    cond  61 7A range  when  ." Lower case letter "  else
    ." Not a character "
  endselect ;

decimal

cr cr .( Running 'select' test...)

cr  char a  .(   ) dup emit  select_test
cr  char ,  .(   ) dup emit  select_test
cr  char 8  .(   ) dup emit  select_test
cr  char ?  .(   ) dup emit  select_test
cr  char K  .(   ) dup emit  select_test
cr  0              dup 3 .r  select_test
cr  127            dup 3 .r  select_test
cr  128            dup 3 .r  select_test

[then]
