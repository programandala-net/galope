\ galope/x-conversions.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2016, 2017.

\ Last modified 201711091702
\ See change log at the end of the file.

\ ==============================================================
\ Requirements

\ From Galope
require ./package.fs
require ./between.fs
require ./max-n.fs

\ From Forth Foundation Library
require ffl/bar.fs \ bit array

\ ==============================================================

package galope-xcase

\ ----------------------------------------------
\ Inner

variable xtable      \ conversion table address
variable caseness    \ bit array id
variable lowest      \ lower char in the conversion table
variable highest     \ higher char in the conversion table
variable xcase-depth \ depth before creating the table

: xchar># ( xc -- u ) lowest @ - ;
  \ Convert _xc_ to its index number _u_ in the conversion table.

: xchars ( -- u ) highest @ xchar># 1+ ;
  \ Return the number _u_ of characters the conversion table can hold.

: limit ( xc -- )
  dup lowest @ min lowest !
      highest @ max highest ! ;
  \ Update the limit characters with _xc_.

: limits ( xc#0 ... xc#n n -- xc#0 ... xc#n )
  0 ?do i pick limit loop ;
  \ Update the limit characters with _n_ characters.

: lowercase ( xc -- ) xchar># caseness @ bar-set-bit ;
  \ Mark _xc_ as lowercase.

: 'xchar ( xc -- xca ) xchar># cells xtable @ + ;
  \ Return the address _xca_ of _xc_ in the conversion table.

: counterpart ( xc1 -- xc2 ) 'xchar @ ;
  \ Return the conversion _xc2_ of _xc1_.

: (pair,) ( xc1 xc2 -- ) swap 'xchar ! ;
  \ Store a pair of chars in the conversion table, one direction
  \ only: _xc1_ is the index xchar; _xc2_ is the counterpart xchar.

: pair, ( xc1 xc2 -- )
  over lowercase 2dup swap (pair,) (pair,) ;
  \ Store a pair of chars in the conversion table, both directions.
  \ _xc1_ is the lowercase xchar; _xc2_ is the uppercase xchar.

: xtable, ( xc1 xc1' ... xcn xcn' n -- ) 0 ?do pair, loop ;
  \ Store all pairs of chars in the conversion table.

: :caseness ( n -- ) bar-new caseness ! ;
  \ Create the caseness bit array.

: :xtable ( n -- )
  cells dup allocate throw
  dup xtable ! swap erase ;
  \ Create the conversion table.

: circumscribed? ( xc -- f ) lowest @ highest @ between ;
  \ Is _xc_ in the range of the conversion table?

\ ----------------------------------------------
\ Interface

public

: (xlower?) ( xc -- f ) xchar># caseness @ bar-get-bit ;
  \ Is _xc_ lowercase?

: (xupper?) ( xc -- f ) (xlower?) 0= ;
  \ Is _xc_ uppercase?

: (xtolower) ( xc1 -- xc1 | xc2 )
  dup (xupper?) if counterpart then ;
  \ Convert _xc1_ to lowercase.

: (xtoupper) ( xc1 -- xc1 | xc2 )
  dup (xlower?) if counterpart then ;
  \ Convert _xc1_ to uppercase.

: xconversion? ( xc -- f )
  dup circumscribed? if counterpart 0<> else drop false then ;

  \ doc{
  \
  \ xconversion? ( xc -- f )
  \
  \ Is _xc_ in the conversion table defined by `xconversions`?
  \
  \ }doc

: xconversions ( -- ) max-n lowest ! depth xcase-depth ! ;

  \ doc{
  \
  \ xconversions ( -- )
  \
  \ Start a conversion table of extended characters, This table
  \ will be used by `xtolower`, `xtoupper`, `xcapitalized`,
  \ `xuncapitalized` and other words.
  \
  \ Usage example:
  \
  \ ----

  \ xconversions
  \   char ĉ char Ĉ
  \   char ĝ char Ĝ
  \   char ĥ char Ĥ
  \   char ĵ char Ĵ
  \   char ŝ char Ŝ
  \   char ŭ char Ŭ
  \ end-xconversions

  \ ----
  \
  \ Three conversion tables are provided as examples in modules
  \ <xcase_es.fs> (for Spanish), <xcase_eo.fs> (for Esperanto, the
  \ example above) and <xcase_ca.fs> (for Catalan).
  \
  \ Any character not defined in the table will be regarded as an
  \ ordinary ASCII character.
  \
  \ WARNING: The table can not be modified. Therefore it must include
  \ all extended characters used by the application.
  \
  \ }doc

: end-xconversions ( xc#1 xc#1' ... xc#n xc#n' -- )
  depth xcase-depth @ -
  dup >r limits
  xchars dup :caseness :xtable
  r> 2/ xtable, ;

  \ doc{
  \
  \ end-xconversions ( xc#1 xc#1' ... xc#n xc#n' -- )
  \
  \ End the conversion table of extended characters (used by
  \ `xtolower`, `xtoupper`, `xcapitalized`, `xuncapitalized` and other
  \ words) by compiling the pairs of characters. The first element of
  \ every pair is the lowercase character, eg. _xc#1_; the second
  \ element of every pair is the uppercase character, eg. _xc#1'_.
  \
  \ See: `xconversions`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2012-09-17: Start. Version A-00.
\
\ 2012-09-18: First working version. Char pairs are stored twice in
\ the translation table: lower-upper and upper-lower. The case is
\ changed using the char as table index, but there's no way to force
\ the direction of the change. It's not practical.
\
\ 2012-09-18: Start of version A-01. New method: a bit array stores
\ the caseness of every char.
\
\ 2012-09-19: Start of version A-02. Data is kept in independent files
\ and stored in the heap, not in the dictionary.
\
\ 2012-09-21: Some words are renamed. 'xlower?' and 'xupper?' are
\ moved to the interface, and work with ASCII chars if needed.
\ 'xace[' is fixed. The check done by 'tabled?' is fixed (only the
\ range was used).  The table is erased before using it.
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
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-08-17: Update source style.
\
\ 2017-11-08: Improve documentation, source layout and header.  Rename
\ `xcase[` `xconversions` and rename the module accordingly; rename
\ `]xcase` `end-xconversions`; rename `tabled?` `xconversion?` and
\ make it public.  Keep the words needed to define and manage the
\ conversion table, and extract the rest into independent modules.
\
\ 2017-11-09: Replace `largest` with `max-n`.
