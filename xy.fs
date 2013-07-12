\ galope/xy.fs
\ Current cursor coordinates

\ This file is part of Galope

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
\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-04 Extracted from a program of mine.
\ 2012-04-29 Added 'at-x' and 'at-y'.
\ 2012-05-08 'at-x' and 'at-y' moved to their own files.
\ 2013-06-26 Fixed some comments. 
\ 2013-06-26 Gforth's 'esc[' used instead of 'ansi_escape'.

require ./module.fs

module: galope_xy

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

export

: xy  ( -- u1 u2 )
  \ u1 = current column
  \ u2 = current line
  esc[ ." 6n"
  key key 2drop  \ erase: <esc> [
  ';' number<c>  'R' number<c>
  1- swap 1-
  ;

base !

;module
