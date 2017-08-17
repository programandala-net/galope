\ galope/sarray.fs
\ String array

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

(

This library is free software; you
can redistribute it and/or modify it
under the terms of the GNU Lesser
General Public License as published by
the Free Software Foundation; either
version 2.1 of the License, or at your
option any later version.

This library is distributed in the
hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the
implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE. See
the GNU Lesser General Public License
for more details.

You should have received a copy of the
GNU Lesser General Public License
along with this library; if not, see
<http://gnu.org/licenses/>.

)

\ This library is a modifed,
\ simplified and Gforth-only version
\ of:

\ "String Arrays"
\ (version 0.1.1, 2004, revised 2007-03-30),
\ by David N. Williams.

\ Gforth allocates the strings created
\ with 's"' in interpretation mode.
\ That makes it possible to create the
\ array strings with ordinary words or
\ expressions.

\ ==============================================================

require ./module.fs

module: galope-sarray-module

variable start_depth

export

: s[
  \ Start the array definition.
  depth start_depth !
  ;
: []s!  ( a1 u1 ... an un n -- )
  \ Store the array strings.
  \ a1 u1 ... an un = strings
  \ n = number of strings
  0 do  , ,  loop
  ;
: ]s  ( a1 u1 ... an n -- a n )
  \ Finish the array definition.
  \ a1 u1 ... an un = strings
  \ a = array address
  \ n = number of strings
  depth start_depth @ - 2 /
  dup align here >r >r []s! 2r>
  ;
: '{}s  ( a1 u -- a2 )
  \ Return an array string address.
  \ a1 = array address
  \ u = string number
  \ a2 = string address
  2* cells +
  ;
: }s@  ( a1 u -- a2 u2 )
  \ Fetch a string from an array.
  \ a1 = array address
  \ u = string number
  \ a2 u2 = string
  '{}s 2@
  ;
: }s!  ( a1 u1 a2 u -- )
  \ Store a string into an array.
  \ a1 u1 = string
  \ a2 = array string
  \ u = string number
  '{}s 2!
  ;

;module

0 [if]

.( Usage example)

s[  \ Esperanto numbers
  s" dek"   \ 10
  s" naŭ"   \ 9
  s" ok"    \ 8
  s" sep"   \ 7
  s" ses"   \ 6
  s" kvin"  \ 5
  s" kvar"  \ 4
  s" tri"   \ 3
  s" du"    \ 2
  s" unu"   \ 1
  s" nul"   \ 0
]s  constant #numbers
    constant number{

require random.fs

number{ 1 }s@ cr type
number{ 2 }s@ cr type
number{ 4 }s@ cr type
s" 2" number{ 2 }s!
number{ 2 }s@ cr type
number{ #numbers random }s@ cr type

[then]

\ ==============================================================
\ Change log

\ 2012-09-07: First version.
\
\ 2012-09-08: Comments revised and completed.
\
\ 2014-11-17: Module name updated.
\
\ 2015-01-25: Typo.
\
\ 2017-08-17: Update change log layout. Update header.
