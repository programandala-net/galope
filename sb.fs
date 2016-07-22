\ galope/sb.fs
\ Circular string buffer

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2016.

\ Description: A configurable circular string buffer that can be used
\ in the heap or in data space. This implementation of a circular
\ string buffer is deprecated in favor of <stringer.fs>.

\ ==============================================================
\ History

\ See at the end of the file.

\ ==============================================================

cr .( XXX sb module) key drop

require ./module.fs
require ./question-question.fs
require ./smove.fs
require ./both-lengths.fs
require ./either-empty-question.fs

module: galope-sb-module

\ ==============================================================
\ Inner

export

variable sb#  \ Free chars in the buffer

hide

0 value 'sb  \ Buffer address
0 value /sb  \ Buffer length

: restart  ( -- )  /sb sb# !  ;

: full?  ( len -- f )  sb# @ >  ;

: ?restart  ( len -- )  full? ?? restart  ;

: used  ( len -- )  negate sb# +!  ;

: needed  ( len -- )  dup ?restart used  ;

: init  ( len a -- )  to 'sb to /sb restart  ;

: pointer  ( -- a )  'sb sb# @ +  ;

: release  ( -- )  0 to 'sb  ;

: active?  ( -- f )  'sb 0<>  ;

: bigger?  ( len -- f )  /sb >  ;

\ ==============================================================
\ Main

export

defer free_sb  ( -- )  ' noop is free_sb
  \ Remove the buffer and free its space.

defer resize_sb  ( len -- )  ' noop is resize_sb
  \ Resize the buffer.

hide

\ Common heap version

: (heap_free_sb)  ( -- )  'sb free throw release  ;
: heap_free_sb  ( -- )  active? ?? (heap_free_sb)  ;
: heap_allocate_sb  ( len -- )  chars dup allocate throw init  ;
: heap_resize_sb  ( len -- )  dup 'sb swap resize throw init  ;

\ Dictionary version

: dictionary_free_sb  ( -- )  release  ;
: dictionary_allocate_sb  ( len -- )  chars here over allot init  ;
: dictionary_resize_sb  ( len -- )
  dup bigger? if  dictionary_allocate_sb  else  drop  then  ;

\ Version selection

: are  ( xt1 xt2 -- )  is free_sb  is resize_sb  ;

: (heap_sb)
  ['] heap_resize_sb ['] heap_free_sb  are  ;

: (dictionary_sb)
  ['] dictionary_resize_sb ['] dictionary_free_sb are  ;

\ Creation of the buffer

export

: heap_sb  ( len -- )
  free_sb (heap_sb) heap_allocate_sb  ;
  \ Create a string buffer in the heap.

: dictionary_sb  ( len -- )
  free_sb (dictionary_sb) dictionary_allocate_sb  ;
  \ Create a string buffer in the data space, with less features. 

\ ==============================================================
\ Low level interface

\ hide

: (>sb)  ( ca1 len ca2 -- ca2 len )  2dup 2>r smove 2r> swap  ;

export

: sb_allocate  ( len -- ca )  needed pointer  ;

: >sb  ( ca1 len -- ca2 len )  dup sb_allocate (>sb)  ;

\ ==============================================================
\ Creation of buffered strings

hide

: (bs)  ( ca1 len1 -- | ca2 len1 )
  state @ if  postpone sliteral  else  >sb  then  ;

: >(bs)  ( c "ccc" -- ca len )  parse (bs)  ;

export

: bs|  ( "ccc<|>" -- ca len )  '|' >(bs)  ; immediate

: bs"  ( "ccc<quote>" -- ca len )  '"' >(bs)  ; immediate

: bs(  ( "ccc<paren>" -- ca len )  ')' >(bs)  ; immediate

\ ==============================================================
\ Concatenation of strings

export

: bs+  ( ca1 len1 ca2 len2 -- ca3 len3 )
  both-lengths + >r  ( ca1 len1 ca2 len2 ) ( R: len3 )
  r@ sb_allocate >r  ( R: len3 ca3 )
  2 pick r@ +  ( ca1 len1 ca2 len2 len1+ca3 )  \ Address of the second string in the result.
  smove  ( ca1 len1 )  \ Second string.
  r@ smove  \ First string.
  r> r>  ;
  \ Concatenate two strings.

hide

true [if]

  \ First version, faster but more complex.

  : (bs&)  ( ca1 len1 ca2 len2 -- ca3 len3 )
    both-lengths + 1+ >r  ( ca1 len2 ca2 len2 ) ( R: len3 )
    r@ sb_allocate >r  ( R: len3 ca3 )
    2 pick r@ +  ( ca1 len1 ca2 len2 u1+a3 )  \ Address of the second string in the result.
    bl over c! char+ smove  ( ca1 len1 )  \ Space and second string.
    r@ smove  \ First string.
    r> r>  ;
    \ Concatenate two strings with a space.

[else]

  \ Second version, simpler but slower.

  : (bs&)  ( ca1 len1 ca2 len2 -- ca3 len3 )
    2>r s"  " bs+ 2r> bs+  ;
    \ Concatenate two strings with a space.

[then]

export

: bs&  ( ca1 len1 ca2 len2 -- ca3 len3 )
  either-empty? if  bs+  else  (bs&)  then  ;
  \ Concatenate two strings, with a space if needed.

;module

\ ==============================================================
\ History

\ This program is based on csb2 by the same author:
\ <http://programandala.net/es.programa.csb2.html>.
\
\ 2012-04-16 First changes in csb2. Version A-00.
\
\ 2012-04-17 More changes.
\
\ 2012-04-18 More changes. Added the new 'module.fs'.
\
\ 2012-04-19 Simplified: '?free_sb' not needed.  Simpler alternative
\ version of 'sb&'.  The ''sb' and '/sb' variables are changed to
\ values.  Version A-01.
\
\ 2012-04-30 Added 'chars' where needed, for portability.
\
\ 2012-07-04 '??' used.
\
\ 2012-07-09 All 'hide' are temporary removed, for debugging.
\
\ 2012-09-14 The code was reformated.
\
\ 2013-05-23 Revision. First todos.
\
\ 2013-10-30 '(bs)' and '>(bs)' are hidden again. Besides, there's
\ word called '(bs)' in Gforth.
\
\ 2013-11-06 Changed the stack notation of flag.
\
\ 2014-11-17: Module name updated.
\
\ 2016-07-19: Update source layout, stack notation and file header.
\ Remove the GPL license and the version number. Move some words to
\ their own files and rename them. Deprecated in favor of
\ <stringer.fs>.
