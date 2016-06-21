\ galope/xcase.fs
\ Tools to convert xchars to lowercase or uppercase.
\ Version A-03-20131208

\ This file is part of Galope

\ Copyright (C) 2012,2013 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

\ See at the end of the file.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ TODO

\ The translation table could be updated with more chars; both the
\ table and the bit array would be resized transparently; the limits
\ would be updated.
\
\ The caseness bit array could be created at compile time.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Requirements

\ From Galope
require ./module.fs
require ./between.fs

\ From Forth Foundation Library
require ffl/chr.fs  \ char data type
require ffl/bar.fs  \ bit array

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Inner words

module: galope-xcase-module

variable xtable  \ translation table address
variable caseness  \ bit array id
variable lowest  \ lower char in the translation table
variable highest  \ higher char in the translation table
variable xcase_depth  \ depth before creating the table

: xchar>#  ( xc -- u )
  \ Convert an xchar to its index number in the translation table.
  lowest @ - 
  ;
: xchars  ( -- u )
  \ Return the number of chars the translation table can hold.
  highest @ xchar># 1+ 
  ;

: limit  ( xc -- )
  \ Update the limit chars with an xchar.
  dup lowest @ min lowest !
      highest @ max highest !
  ;
: limits  ( xc0 ... xcn n -- xc0 ... xcn )
  \ Update the limit chars with n chars.
  0 ?do  i pick limit  loop
  ;

: lowercase  ( xc -- )
  \ Mark an xchar as lowercase.
  xchar># caseness @ bar-set-bit
  ;
: (xlower?)  ( xc -- wf )
  \ Is an xchar lowercase?
  xchar># caseness @ bar-get-bit
  ;
: (xupper?)  ( xc -- wf )
  \ Is an xchar uppercase?
  (xlower?) 0=
  ;

: 'xchar  ( xc -- xca )
  \ Return the address of an xchar in the translation table.
  xchar># cells xtable @ +
  ;
: counterpart  ( xc1 -- xc2 )
  \ Return the counterpart of an xchar.
  'xchar @
  ;
: (pair,)  ( xc1 xc2 -- )
  \ Store a pair of chars in the translation table,
  \ one direction only.
  \ xc1 = index xchar
  \ xc2 = counterpart xchar
  swap 'xchar !
  ;
: pair,  ( xc1 xc2 -- )
  \ Store a pair of chars in the translation table,
  \ both directions.
  \ xc1 = lowercase xchar
  \ xc2 = uppercase xchar
  over lowercase  2dup swap (pair,) (pair,)
  ;
: xtable!  ( xc1 xc1' ... xcn xcn' n -- )
  \ Store all pairs of chars in the translation table.
  0 ?do  pair,  loop
  ;

: (xtoupper)  ( xc -- xc' | xc )
  \ Convert an xchar to uppercase.
  dup (xlower?) if  counterpart  then
  ;
: (xtolower)  ( xc -- xc' | xc )
  \ Convert an xchar to lowercase.
  dup (xupper?) if  counterpart  then
  ;

: :caseness  ( n -- )
  \ Create the caseness bit array.
  bar-new caseness !
  ;
: :xtable  ( n -- )
  \ Create the translation table.
  cells dup allocate throw  
  dup xtable !  swap erase
  ;

: largest  ( -- n )
  \ Return the largest usable signed integer.
  s" MAX-N" environment? drop
  ;
: circumscribed?  ( xc -- wf )
  \ Is an xchar in the range of the translation table?
  lowest @ highest @ between
  ;
: tabled?  ( xc -- wf )
  \ Is an xchar in the translation table?
  dup circumscribed?
  if    counterpart 0<>
  else  drop false
  then
  ;

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ Interface words

export

: xcase[
  \ Start the xchar translation table.
  largest lowest !  depth xcase_depth !
  ;
: ]xcase  ( xc1 xc1' ... xcn xcn' -- )
  \ End the xchar translation table.
  \ xcn = lowercase xchar
  \ xcn' = uppercase xchar
  depth xcase_depth @ -
  dup >r limits
  xchars dup :caseness :xtable
  r> 2/ xtable!
  ;
: xtoupper  ( xc -- xc | xc' )
  \ Convert an xchar to uppercase.
  dup tabled? if  (xtoupper) else  toupper  then
  ;
: xtolower  ( xc -- xc | xc' )
  \ Convert an xchar to lowercase.
  \ There's no 'tolower' in Gforth, so FFL's 'chr-lower' is used
  \ instead.
  dup tabled? if  (xtolower)  else  chr-lower  then
  ;
: xlower?  ( xc -- wf )
  \ Is an xchar lowercase?
  dup tabled? if  (xlower?)  else  chr-lower? then
  ;
: xupper?  ( xc -- wf )
  \ Is an xchar uppercase?
  dup tabled? if  (xupper?)  else  chr-upper?  then
  ;

;module

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

\ 2012-09-17 Start. Version A-00.
\ 
\ 2012-09-18 First working version. Char pairs are stored twice in the
\ translation table: lower-upper and upper-lower. The case is changed
\ using the char as table index, but there's no way to force the
\ direction of the change. It's not practical.
\ 
\ 2012-09-18 Start of version A-01. New method: a bit array stores the
\ caseness of every char.
\ 
\ 2012-09-19 Start of version A-02. Data is kept in independent files
\ and stored in the heap, not in the dictionary.
\ 
\ 2012-09-21 Some words are renamed. 'xlower?' and 'xupper?' are moved
\ to the interface, and work with ASCII chars if needed.  'xace[' is
\ fixed. The check done by 'tabled?' is fixed (only the range was
\ used).  The table is erased before using it.
\ 
\ 2012-09-21 Start of version A-03. There was no need to store every
\ pair of chars in the table. Now only the counterpart char is stored
\ in the table, at the position of the index char.
\ 
\ 2013-08-27 Some changes in comments, stack and source format.
\ 
\ 2013-12-08 Fix: stack comment of 'pair,' and '(pair,)'.
\
\ 2014-11-17: Module name updated.
