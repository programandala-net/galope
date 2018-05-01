\ galope/sarray.fs
\ String array

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2017.

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

require ./n-two-comma.fs    \ `n2,`
require ./two-array-from.fs \ `2array<`

: s[ ( -- ) depth start-depth ! ;
  \ Start a string array definition.

: ]s ( ca#1 len#1 .. ca#n len#n -- a n )
  depth start-depth @ - 2/
  dup align here >r >r n2, 2r> ;
  \ Finish the array definition started by `s[` by storing the
  \ character string identifiers _ca#1 len#1 .. ca#n len#n_ into data
  \ space; return the address _a_ of the array string and the number
  \ _n_ of strings.

: }s@ ( a n -- ca len ) 2array< 2@ ;
  \ Fetch the character string identifier _ca len_ from element number
  \ _n_ of string array _a_

: }s! ( ca len a n -- ) 2array< 2! ;
  \ Store the character string identifier _ca len_ into element number
  \ _n_ of string array _a_

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
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-12-02: Update source style, including comments and stack
\ comments. Make two inner words private.
\
\ 2017-12-04: Rename `[]s!` `n2,` and move it to its own module.
\
\ 2018-05-01: Replace `'{}s` with `2array<`.
