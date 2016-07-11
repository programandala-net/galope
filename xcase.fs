\ galope/xcase.fs
\ Tools to convert xchars to lowercase or uppercase.

\ Version 0.3.0+201606272139

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2016.

\ ==============================================================
\ History

\ See at the end of the file.

\ ==============================================================
\ TODO

\ The translation table could be updated with more chars; both the
\ table and the bit array would be resized transparently; the limits
\ would be updated.
\
\ The caseness bit array could be created at compile time.

\ ==============================================================
\ Usage

\ First, a char translation table must be created with all chars used
\ by the program; it can not be updated later.  Examples can be found
\ in the following files:

\   galope/xcase_ca.fs ( Catalan letters )
\   galope/xcase_eo.fs ( Esperanto letters )
\   galope/xcase_es.fs ( Spanish letters )

\ Then the interface words can be used to check or change any char. If
\ the xchar is not in the table, the usual ASCII chars words will be
\ tried.

\ ==============================================================
\ Requirements

\ From Galope
require ./module.fs
require ./between.fs

\ From Forth Foundation Library
require ffl/chr.fs  \ char data type
require ffl/bar.fs  \ bit array

\ ==============================================================
\ Inner words

module: galope-xcase-module

variable xtable       \ translation table address
variable caseness     \ bit array id
variable lowest       \ lower char in the translation table
variable highest      \ higher char in the translation table
variable xcase_depth  \ depth before creating the table

: xchar>#  ( xc -- u )  lowest @ -  ;
  \ Convert an xchar to its index number in the translation table.

: xchars  ( -- u )  highest @ xchar># 1+  ;
  \ Return the number of chars the translation table can hold.

: limit  ( xc -- )
  dup lowest @ min lowest !
      highest @ max highest !   ;
  \ Update the limit chars with an xchar.

: limits  ( xc0 ... xcn n -- xc0 ... xcn )
  0 ?do  i pick limit  loop  ;
  \ Update the limit chars with n chars.

: lowercase  ( xc -- )
  xchar># caseness @ bar-set-bit  ;
  \ Mark an xchar as lowercase.

: (xlower?)  ( xc -- f )
  xchar># caseness @ bar-get-bit  ;
  \ Is an xchar lowercase?

: (xupper?)  ( xc -- f )  (xlower?) 0=  ;
  \ Is an xchar uppercase?

: 'xchar  ( xc -- xca )
  xchar># cells xtable @ +  ;
  \ Return the address of an xchar in the translation table.

: counterpart  ( xc1 -- xc2 )  'xchar @  ;
  \ Return the counterpart of an xchar.

: (pair,)  ( xc1 xc2 -- )
  swap 'xchar !  ;
  \ Store a pair of chars in the translation table, one direction
  \ only: _xc1_ is the index xchar; _xc2_ is the counterpart xchar.

: pair,  ( xc1 xc2 -- )
  over lowercase  2dup swap (pair,) (pair,)  ;
  \ Store a pair of chars in the translation table, both directions.
  \ _xc1_ is the lowercase xchar; _xc2_ is the uppercase xchar.

: xtable!  ( xc1 xc1' ... xcn xcn' n -- )
  0 ?do  pair,  loop  ;
  \ Store all pairs of chars in the translation table.

: (xtoupper)  ( xc -- xc' | xc )
  dup (xlower?) if  counterpart  then  ;
  \ Convert an xchar to uppercase.

: (xtolower)  ( xc -- xc' | xc )
  dup (xupper?) if  counterpart  then  ;
  \ Convert an xchar to lowercase.

: :caseness  ( n -- )
  bar-new caseness !  ;
  \ Create the caseness bit array.

: :xtable  ( n -- )
  cells dup allocate throw
  dup xtable !  swap erase  ;
  \ Create the translation table.

: largest  ( -- n )
  s" MAX-N" environment? drop  ;
  \ Return the largest usable signed integer.
  \ XXX TODO -- rename to `max-n` and move to Galope.

: circumscribed?  ( xc -- f )
  lowest @ highest @ between  ;
  \ Is an xchar in the range of the translation table?

: tabled?  ( xc -- f )
  dup circumscribed?
  if  counterpart 0<>  else  drop false  then  ;
  \ Is an xchar in the translation table?

\ ==============================================================
\ Interface words

export

: xcase[  ( -- )
  largest lowest !  depth xcase_depth !  ;
  \ Start the xchar translation table.

: ]xcase  ( xc1 xc1' ... xcn xcn' -- )
  depth xcase_depth @ -
  dup >r limits
  xchars dup :caseness :xtable
  r> 2/ xtable!  ;
  \ End the xchar translation table.
  \ _xcn_ is the lowercase xchar;
  \ _xcn'_ = uppercase xchar.
  \ XXX TODO -- improve documentation

: xtoupper  ( xc -- xc | xc' )
  dup tabled? if  (xtoupper) else  toupper  then  ;
  \ Convert an xchar to uppercase.

: xtolower  ( xc -- xc | xc' )
  dup tabled? if  (xtolower)  else  chr-lower  then  ;
  \ Convert an xchar to lowercase.  There's no 'tolower' in Gforth, so
  \ FFL's 'chr-lower' is used instead.

: xlower?  ( xc -- f )
  dup tabled? if  (xlower?)  else  chr-lower? then  ;
  \ Is an xchar lowercase?

: xupper?  ( xc -- f )
  dup tabled? if  (xupper?)  else  chr-upper?  then  ;
  \ Is an xchar uppercase?

;module

\ ==============================================================
\ History

\ 2012-09-17: Start. Version A-00.
\
\ 2012-09-18: First working version. Char pairs are stored twice in the
\ translation table: lower-upper and upper-lower. The case is changed
\ using the char as table index, but there's no way to force the
\ direction of the change. It's not practical.
\
\ 2012-09-18: Start of version A-01. New method: a bit array stores the
\ caseness of every char.
\
\ 2012-09-19: Start of version A-02. Data is kept in independent files
\ and stored in the heap, not in the dictionary.
\
\ 2012-09-21: Some words are renamed. 'xlower?' and 'xupper?' are moved
\ to the interface, and work with ASCII chars if needed.  'xace[' is
\ fixed. The check done by 'tabled?' is fixed (only the range was
\ used).  The table is erased before using it.
\
\ 2012-09-21: Start of version A-03. There was no need to store every
\ pair of chars in the table. Now only the counterpart char is stored
\ in the table, at the position of the index char.
\
\ 2013-08-27: Some changes in comments, stack and source format.
\
\ 2013-12-08: Fix: stack comment of 'pair,' and '(pair,)'.
\
\ 2014-11-17: Module name updated.
\
\ 2016-06-27: Update the file header, the source style and the stack
\ notation. Change the version numbering to Semantic Versioning.
