\ galope/sb.fs
\ String buffer

\ Version A-01-2012041923

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ This program is free software; you can redistribute it
\ and/or modify it under the terms of the GNU General Public
\ License as published by the Free Software Foundation;
\ either version 2 of the License, or (at your option) any
\ later version.

\ This program is distributed in the hope that it will be
\ useful, but WITHOUT ANY WARRANTY; without even the implied
\ warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
\ PURPOSE.  See the GNU General Public License for more
\ details.

\ You should have received a copy of the GNU General Public
\ License along with this program; if not, see
\ http://www.gnu.org/licenses .

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Usage

0 [if]

\ First, include this module into your program: 
s" galope/sb.fs" required

\ Then create a string buffer in the common heap,
\ for example with space for 1024 chars:
1024 heap_sb

\ It's possible to use the dictionary instead (with less features):
1024 dictionary_sb

\ The public words of the module are defined after every
\ 'export'.

[then]

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Todo

\ 2013-05-23:
\ Make a new version A-02, with better word names. Save the new
\ version as "sb_a-02.fs" to avoid compatibility problems.

\ Other specific todos are marked in the code.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

0 [if]

This program is based on csb2 by the same author:
<http://programandala.net/es.programa.csb2>.

2012-04-16 First changes in csb2. Version A-00.

2012-04-17 More changes.

2012-04-18 More changes. Added the new 'module.fs'.

2012-04-19 Simplified: '?free_sb' not needed.  Simpler
alternative version of 'sb&'.  The ''sb' and '/sb' variables are
changed to values.  Version A-01.

2012-04-30 Added 'chars' where needed, for portability.

2012-07-04 '??' used.

2012-07-09 All 'hide' are temporary removed, for debugging.

2012-09-14 The code was reformated.

2013-05-23 Revision. First todos.

[then]

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require ./module.fs
require ./question-question.fs

base @ decimal

module: galope_sb

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Inner

export

variable sb#  \ Free chars in the buffer

\ hide

0 value 'sb  \ Buffer address
0 value /sb  \ Buffer length

\ xxx todo remove or rename; these names are too general
\ and probably will clash with application words: 

: restart  ( -- )
  /sb sb# !
  ;
: full?  ( u -- ff )
  sb# @ >
  ;
: ?restart  ( u -- )
  full? ?? restart
  ;
: used  ( u -- )
  negate sb# +!
  ;
: needed  ( u -- )
  dup ?restart used
  ;
: init  ( u a -- )
  to 'sb to /sb restart
  ;
: pointer  ( -- a )
  'sb sb# @ +
  ;
: smove  ( a1 u1 a2 -- ) \ xxx todo make a galope file with this word
  swap chars move
  ;
: release  ( -- )
  0 to 'sb
  ;
: active?  ( -- ff )
  'sb 0<>
  ;
: bigger?  ( u -- ff )
  /sb >
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Main

export

defer free_sb  \ Remove the buffer and free its space.
' noop is free_sb

defer resize_sb  ( u -- )  \ Resize the buffer.
' noop is resize_sb

\ hide

\ Common heap version

: (heap_free_sb)
  'sb free throw release
  ;
: heap_free_sb
  active? ?? (heap_free_sb)
  ;
: heap_allocate_sb  ( u -- )
  chars dup allocate throw init
  ;
: heap_resize_sb  ( u -- )
  dup 'sb swap resize throw init
  ;

\ Dictionary version

: dictionary_free_sb
  release
  ;
: dictionary_allocate_sb  ( u -- )
  chars here over allot init
  ;
: dictionary_resize_sb  ( u -- )
  dup bigger? if  dictionary_allocate_sb  else  drop  then
  ;

\ Version selection

: are  ( xt1 xt2 -- )
  is free_sb is resize_sb
  ;
: (heap_sb)
  ['] heap_resize_sb ['] heap_free_sb  are
  ;
: (dictionary_sb)
  ['] dictionary_resize_sb ['] dictionary_free_sb are
  ;

\ Creation of the buffer

export

: heap_sb  ( u -- )
  free_sb (heap_sb) heap_allocate_sb
  ;
: dictionary_sb  ( u -- )
  free_sb (dictionary_sb) dictionary_allocate_sb
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Low level interface

\ hide

: (>sb)  ( a1 u a2 -- a2 u )
  2dup 2>r smove 2r> swap
  ;

export

: sb_allocate  ( u -- a )
  needed pointer
  ;
: >sb  ( a1 u -- a2 u )
  dup sb_allocate (>sb)
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Creation of buffered strings

\ hide \ xxx todo why removed the 'hide'?

: (bs)  ( a1 u -- | a2 u )
  state @ if  postpone sliteral  else  >sb  then
  ;
: >(bs)  ( c "text" -- a u )
  parse (bs)
  ;

export

: bs|  ( "ccc<|>" -- a u )
  [char] | >(bs)
  ;  immediate
: bs"  ( "ccc<double-quote>" -- a u )
  [char] " >(bs)
  ;  immediate
: bs(  ( "ccc<close-paren>" -- a u )
  [char] ) >(bs)
  ;  immediate

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Concatenation of strings 

\ hide \ xxx todo why removed the 'hide'?
\ xxx todo make these independent in galope:

: lengths  ( a1 u1 a2 u2 -- a1 u1 a2 u2 u1 u2 )
  2 pick over
  ;
: any_zero?  ( u1 u2 -- ff )
  0= swap 0= or
  ;
: any_empty?  ( a1 u1 a2 u2  -- a1 u1 a2 u2 ff )
  lengths any_zero?
  ;

export

: bs+  ( a1 u1 a2 u2 -- a3 u3 )
  \ Join two strings.
  lengths + >r  ( a1 u2 a2 u2 ) ( R: u3 )
  r@ sb_allocate >r  ( R: u3 a3 )
  2 pick r@ +  ( a1 u1 a2 u2 u1+a3 )  \ Address of the second string in the result.
  smove  ( a1 u1 )  \ Second string.
  r@ smove  \ First string.
  r> r>
  ;

\ hide \ xxx todo why removed the 'hide'?

true [if]

  \ First version, faster but more complex.
  
  : (bs&)  ( a1 u1 a2 u2 -- a3 u3 )
    \ Join two strings with a space.
    lengths + 1+ >r  ( a1 u2 a2 u2 ) ( R: u3 )
    r@ sb_allocate >r  ( R: u3 a3 )
    2 pick r@ +  ( a1 u1 a2 u2 u1+a3 )  \ Address of the second string in the result.
    bl over c! char+ smove  ( a1 u1 )  \ Space and second string.
    r@ smove  \ First string.
    r> r>
    ;

[else]

  \ Second version, simpler but slower.

  : (bs&)  ( a1 u1 a2 u2 -- a3 u3 )
    \ Join two strings with a space.
    2>r s"  " bs+ 2r> bs+
    ;

[then]

export

: bs&  ( a1 u1 a2 u2 -- a3 u3 )
  \ Join two strings, with a space if needed.
  any_empty? if  bs+  else  (bs&)  then
  ;

;module  base !

