\ galope/xstack.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2014.

\ ==============================================================
\ Creation and core manipulation of xstacks

\ Values of the current xstack
0 value xsize  \ in address units (works as a constant)
0 value xp     \ address of the xstack pointer (works as a variable)
0 value xp0    \ initial value of the xstack pointer (works as a constant)

: xstack  ( n "name" -- )
  \ Create a new xstack of n cells.
  create  cells dup allocate throw  cell - dup
    , \ xp0
    , \ xp
    , \ xsize
  does> ( -- )
    \ Make an xstack the current xstack.
    ( dfa ) dup @ to xp0  cell+ dup to xp  cell+ @ to xsize
  ;
: xp@  ( -- a )
  xp @
  ;
: xp!  ( a -- )
  xp !
  ;
: xp+!  ( n -- )
  xp +!
  ;
: xclear  ( -- )
  xp0 xp!
  ;
: xfree  ( -- )
  xp0 free throw
  ;

\ ==============================================================
\ Manipulation of the current xstack (without checks)

defer >x
: (>x)  ( x -- ) ( X: -- x )
  cell xp+!  xp@ !
  ;
' (>x) is >x

defer x@
: (x@)  ( -- x ) ( X: x -- x )
  xp@ @
  ;
' (x@) is x@

defer xdrop
: (xdrop)  ( X: x -- )
  [ cell negate ] literal xp+!
  ;
' (xdrop) is xdrop

defer x>
: (x>)  ( -- x ) ( X: x -- )
  (x@) (xdrop)
  ;
' (x>) is x>

defer xdup
: (xdup)  ( X: x -- x x )
  (x@) (>x)
  ;
' (xdup) is xdup

defer xpick
: (xpick)  ( n -- x'n ) ( X: x'n ... x'0 -- x'n ... x'0 )
  xp@ swap cells - @
  ;
' (xpick) is xpick

defer xover
: (xover)  ( X: x1 x2 -- x1 x2 x1 )
  1 (xpick) (>x)
  ;
' (xover) is xover

\ ----------------------------------------------
\ Double numbers

defer x2@
: (x2@)  ( -- x1 x2 ) ( X: x1 x2 -- x1 x2 )
  (x@) 1 (xpick) swap
  ;
' (x2@) is x2@

defer 2>x
: (2>x)  ( x1 x2 -- ) ( X: -- x1 x2 )
  swap (>x) (>x)
  ;
' (2>x) is 2>x

defer 2x>
: (2x>)  ( -- x1 x2 ) ( X: x1 x2 -- )
  (x>) (x>) swap
  ;
' (2x>) is 2x>

defer x2drop
: (x2drop)  ( X: x1 x2 -- )
  [ -2 cells ] literal xp+!
  ;
' (x2drop) is x2drop

defer x2dup
: (x2dup)  ( X: x1 x2 -- x1 x2 x1 x2 )
  (xover) (xover)
  ;
' (x2dup) is x2dup

\ ==============================================================
\ Information on the current xstack

: xlen  ( -- n )
  \ Length of the current xstack, in address units.
  xp@ xp0 -
  ;
: xdepth  ( -- n )
  \ Depth of the current xstack.
  xlen cell /
  ;
: xempty?  ( -- wf )
  \ Is the current xstack empty?
  xp@ xp0 =
  ;
: (xdepth.)  ( -- )
  ." <"  s>d <# #s #> type  ." > "
  ;
: (.x)  ( -- )
  \ Display a list of the items in the xstack; TOS is the right-most item.
  xp0 cell+ xlen bounds ?do  i @ . cell +loop
  ;
: .x  ( -- )
  \ Display the number of items on the current xstack,
  \ followed by a list of the items; TOS is the right-most item.
  xdepth dup (xdepth.) if  (.x)  then
  ;

\ ==============================================================
\ Manipulation of the current xstack (with checks)

\ XXX TODO

0 [if]

: x?  ( lower higher -- )
  \ XXX TODO
  u< 0= abort" xstack limits"
  ;
: ((>x))
  \ Secure version of '(>x)'.
  xp@ xp0 xsize cells + x?  \ check max addr
  (>x)
  ;
: ((x>))
  \ Secure version of '(x>)'.
  xp@ xp0 over x?  \ check against min addr
  @  -2 xstack +!  \ XXX TODO factor -- used in '(x>)' too
  ;
: ((x@))
  \ Secure version of '(x@)'.
  xp@ xp0 over x?  \ check against min addr
  @
  ;
: ((xpick))
  \ Secure version of '(xpick)'.
  xp@ swap cells -
  dup xp@ 2 + x?  \ check agains stack top
  xp0 over x?  \ check agains min addr
  @
  ;

[then]

\ ==============================================================
\ Change log

\ 2014-11-08: Start. Based on:
\   XSTACK
\   Author: Victor H. Yngve (Chicago, Illinois), 1987
\   Published in Forth Dimensions
\   (Volume 10, Number 3, September/October 1988, pages 5 and 10):
\   http://www.forth.org/fd/contents.html
\   http://www.forth.org/fd/FD-V10N3.pdf
\ Improvements on the original Yngve's code:
\ - Any number of stacks can be created, with any size;
\   the stack's name makes the stack the current one.
\ - Comus-like low-level interface: 'xp0', 'xp@' and 'xp!'.
\ - More words to manipulate the stacks.
\ - '.x' behaves like Gforth's '.s'.
\
\ 2015-10-14: Improved usage of `literal` in `(xdrop)` and `(x2drop)`.
\ Fixed comments.
\
\ 2017-08-17: Update change log layout. Update section rulers.
