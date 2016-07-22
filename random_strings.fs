\ galope/random_strings.fs
\ Random strings

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2013, 2014,
\ 2016.

\ Description: Tools to compile and manipulate strings that will be
\ chosen randomly at run-time.

\ ==============================================================

require random.fs

require ./module.fs
require ./two-choose.fs
require ./plus-plus.fs
require ./minus-minus.fs

module: galope-random_strings-module

\ ==============================================================
\ Depth stack

8 constant /dstack
  \ Size of the depth stack in cells. This is the maximum number of
  \ nestings.

create dstack-pointer /dstack 1+ cells allot
  \ Depth stack.  The first cell holds the pointer to the top of depth
  \ stack (or zero if the depth stack is empty).

: 'dstack-tos ( -- a )
  dstack-pointer dup @ cells +  ;
  \ Address of the top of depth stack.

: dstack-full? ( -- f )
  dstack-pointer @ /dstack =  ;
  \ Is the depth stack full?

: dstack-empty? ( -- f )
  dstack-pointer @ 0=  ;
  \ Is the depth stack empty?

: ?abort-full  ( -- )
  dstack-full? abort" Too many nesting levels with `S{` and `}S`."  ;
  \ Abort if the depth stack is full.

: dstack! ( n -- )
  ?abort-full dstack-pointer ++ 'dstack-tos !  ;
  \ Store _n_ in the depth stack.

: ?abort-empty  ( -- )
  dstack-empty? abort" `S{` and `}S` badly nested."  ;
  \ Abort if the depth stack is empty.

: dstack@ ( -- n )
  ?abort-empty 'dstack-tos @ dstack-pointer --  ;
  \ Fetch the top of the depth stack.

\ ==============================================================
\ Operators

export

: s{ ( -- )
  depth dstack!  ;
  \ Start a set of random strings.

: }s ( ca1 len1 ... ca#n len#n -- ca' len' )
  depth dstack@ - 2 / 2choose  ;
  \ Chose a random string _ca' len'_ from the strings _ca1 len ... ca#n
  \ len#n_ stacked since the last unresolved `s{`.

: s? ( ca len -- ca len | ca 0 )
  2 random *  ;
  \ Empty a string randomly (50% choices).

;module

\ ==============================================================
\ History

\ 2012-04-07: In order to reuse this code, it was extracted from the
\ project it was developed for
\ (http://programandala.net/es.programa.asalto_y_castigo.forth.html).
\ The abort messages are translated to English.
\
\ 2012-04-22: The original Spanish comments are moved to the end of
\ the file.  More compact source layout.
\
\ 2012-04-30: Added 's?{' and '}s{'.
\
\ 2012-05-02: Fixed some stack comments.
\
\ 2012-05-05: Added the new files galope/increment.fs and
\ galope/decrement.fs, instead of defining '++' and '--'.  Added
\ '}s&?'.
\
\ 2012-05-08: galope/increment.fs and galope/decrement.fs changed
\ their names to galope/plus-plus.fs and galope/minus-minus.fs.
\
\ 2012-09-14: Code reformated.
\
\ 2013-11-06: Changed the stack notation of flag.
\
\ 2014-11-17: Module name updated.
\
\ 2016-07-11: Update source layout, file header, stack notation.
\
\ 2016-07-19: Update and fix some stack comments. Replace underscores
\ with dashes (this change does not break backwards compatibility,
\ because the all of the renamed words are private).
\
\ 2016-07-20: Comment out the shortcuts to combined actions. This way
\ this module does not depend on a specific implementation of a string
\ buffer, like <sb.fs>.
\
\ 2016-07-22: Remove the shortcuts to combined actions. Remove the
\ Spanish documentation.
