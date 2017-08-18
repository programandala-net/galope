\ galope/xy.fs
\ Current cursor coordinates

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ ==============================================================

\ Extracted and modified from:

\ --------------------------------------------------------------
\ ansi.4th
\ ANSI Terminal words for kForth
\ Copyright (c) 1999--2004 Krishna Myneni
\ Creative Consulting for Research and Education
\ This software is provided under the terms of the GNU
\ General Public License.
\ --------------------------------------------------------------

\ Modifications:

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2017.

\ ==============================================================

require ./package.fs

package galope-xy

base @ decimal

: number<c>  ( c -- n )
  \ Read a decimal numeric entry delimited by character c.
  \ xxx todo move this word to its own file:
  \ xxx todo choose a better name:
  \ number/c
  \ keys/c>decimal
  \ keys>#
  \ keys>number
  \ keys>#number
  \ xxx todo no final char: finish at the first non-digit instead
  >r 0
  begin   key dup r@ <>
  while   swap 10 * swap '0' - +
  repeat  r> 2drop
  ;

public

: xy  ( -- u1 u2 )
  \ u1 = current column
  \ u2 = current line
  esc[ ." 6n"
  key key 2drop  \ erase: <esc> [
  ';' number<c>  'R' number<c>
  1- swap 1-
  ;

base !

end-package

\ ==============================================================
\ Change log

\ 2012-04: Extracted from a program of mine.
\
\ 2012-04-29: Added 'at-x' and 'at-y'.
\
\ 2012-05-08: 'at-x' and 'at-y' moved to their own files.
\
\ 2013-06-26: Fixed some comments.
\
\ 2013-06-26: Gforth's 'esc[' used instead of 'ansi_escape'.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-08-18: Use `package` instead of `module:`.
