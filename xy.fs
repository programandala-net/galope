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
\ 2012-04 Extracted from a app of mine.
\ 2012-04-29 Added 'at-x' and 'at-y'.

require galope/module.fs

module: galope_xy

base @ decimal

: number<c>  ( c -- n )
  \ Read a numeric entry delimited by character c.
  >r 0
  begin   key dup r@ <>
  while   swap 10 * swap [char] 0 - +
  repeat  r> 2drop
  ;
: ansi_escape  ( -- )
  27 emit [char] [ emit
  ;

export

: xy  ( -- u1 u2 )
  \ u1 = Current column.
  \ u2 = Current line.
  ansi_escape ." 6n"
  key key 2drop  \ Erase: <esc> [
  [char] ; number<c>  [char] R number<c>
  1- swap 1-
  ;

base !

;module
