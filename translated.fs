\ galope/translated.fs
\ Tool to translate substrings of a string.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013.

\ ==============================================================

require ./paren-star.fs  \ '(*'
require ./module.fs

require ffl/str.fs

module: galope-translated-module

str-create translated-str
variable depth0
4 constant cells/translation
cells/translation cells constant /translation
: translations_init  ( -- a )
  \ Init tasks before the definition of the translation table.
  here 0 ,  depth depth0 !
  ;
: #translations  ( -- n )
  \ Number of translations defined in the table.
  depth depth0 @ - cells/translation /
  ;
: translations,  ( ca'1 len'1 ... ca'n len'n n -- )
  \ Compile the translations into the table.
  \ n = number of translations
  0 ?do  2, 2,  loop
  ;

export

: translations:  ( "name" -- a1 )
  \ Start the definition of a translation table.
  \ a1 = data field address of the translation table,
  \   that will hold the number of translations.
  \ a2 = address of the first translation in the table.
  \ n = number of translations.
  create  translations_init
  does>  ( -- a2 n ) ( dfa ) dup @ swap cell+ swap
  ;
: /translations  ( dfa ca'1 len'1 ... ca'n len'n -- n )
  \ End the definition of a translation table.
  \ n = number of translations compiled
  #translations dup >r translations,  r@ swap ! r>
  ;
: ;translations  ( dfa ca'1 len'1 ... ca'n len'n -- )
  \ End the definition of a translation table.
  /translations drop
  ;
false [if]  \ xxx not used
: translation@+  ( a -- a' ca1 len1 ca2 len2 )
  \ a = address of the current translation
  \ a' = address of the next translation
  \ ca1 len1 = original string
  \ ca2 len2 = translated string
  dup 2@ 2>r  2 cells + dup 2@ 2>r  /translation +  2r> 2r>
  ;
[then]
: translation@  ( a n -- ca1 len1 ca2 len2 )
  \ Fetch a translation from a translation table.
  \ a = address of the translation table
  \ n = number of the required translation
  \ ca1 len1 = translated string
  \ ca2 len2 = original string
  /translation * + dup 2@ rot 2 cells + 2@
  ;
: translated  ( ca len a n -- ca' len' )
  \ Translate a string with a translation table.
  \ ca len = string to translate
  \ a = address of the translation table
  \ n = number of the required translation
  \ ca' len' = translated string
  2swap translated-str str-set
  0 ?do  dup i translation@ translated-str str-replace  loop  drop
  translated-str str-get
  ;

;module

false [if]

\ Usage example:

translations: table0
  s" from3" s" to3"  \ last translation to be done
  s" from2" s" to2"
  s" from1" s" to1"  \ first translation to be done
;translations

s" bla blafrom2! bla bla from3 bla bla from1" table0 translated

[then]

\ ==============================================================
\ Change log

\ 2013-12-10: Written.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
