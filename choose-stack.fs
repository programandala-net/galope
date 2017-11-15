\ galope/choose-stack.fs
\ A stack used by `choose{` and `2choose`.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2011, 2012, 2013, 2014,
\ 2016, 2017.

\ ==============================================================

require ./module.fs
require ./one-minus-store.fs
require ./one-plus-store.fs
require ./two-choose.fs

\ ==============================================================

8 constant /choose-stack
  \ Maximum size of the choose stack in cells. This is the maximum
  \ number of nestings for `choose{ }choose` and `2choose{ }2choose`.

variable choose-stack-used
  \ Cells used in the choose stack.

create choose-stack /choose-stack cells allot

: init-choose-stack  ( -- )  0 choose-stack-used !  ;

init-choose-stack

: choose-stack-tos ( -- a )
  choose-stack-used @ 1- cells choose-stack +  ;
  \ Address of the top of choose stack.

: choose-stack-full? ( -- f )
  choose-stack-used @ /choose-stack =  ;
  \ Is the choose stack full?

: choose-stack-empty? ( -- f )
  choose-stack-used @ 0=  ;
  \ Is the choose stack empty?

: ?choose-stack-full  ( -- )
  choose-stack-full? abort" The choose stack is full."  ;
  \ Abort if the choose stack is full.

: >choose-stack ( n -- )
  ?choose-stack-full
  choose-stack-used 1+! choose-stack-tos !  ;
  \ Store _n_ in the choose stack.

: ?choose-stack-empty  ( -- )
  choose-stack-empty? abort" The choose stack is empty."  ;
  \ Abort if the choose stack is empty.

: <choose-stack ( -- n )
  ?choose-stack-empty
  choose-stack-tos @ choose-stack-used 1-!  ;
  \ Fetch the top of the choose stack.

\ ==============================================================
\ Change log

\ 2016-07-22: Move from the old module <random_strings.fs>, improve
\ and rename the words, in order to reuse them for the new `2choose{
\ }2choose` and `choose{ }choose`.
\
\ 2017-11-15: Update `++` to `1+!`, and `--` to `1-!`.
