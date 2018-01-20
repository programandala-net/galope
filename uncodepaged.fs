\ galope/uncodepaged.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Description: Tool to transform a string, replacing 8-bit
\ characters with strings.

\ Author: Marcos Cruz (programandala.net), 2013, 2017.

\ ==============================================================
\ Requirements

require ./package.fs

require ffl/str.fs

\ ==============================================================
\ Core

package galope-uncodepaged

str-create uncodepaged-str

variable depth0

3 constant stack/translation

2 cells constant /translation

256 constant chars/table

chars/table /translation * constant /table

variable 'table  \ address of the translation table just defined

: erase_table  ( a -- ) /table erase ;
  \ Erase a translation table.

: new_table  ( -- a ) /table allocate throw  dup erase_table ;
  \ Create a new translation table.

: #translations \ ( c#1 ca#1 len#1 .. c#n ca#n len#n --
                \   c#1 ca#1 len#1 .. c#n ca#n len#n n )
  depth depth0 @ - stack/translation / ;
  \ Calculate the number of translations defined in the
  \ translation table.

: 'translation  ( a1 c -- a2 ) /translation * + ;
  \ Return the address of a translation in a translation table.
  \ a1 = address of the translation table
  \ c = character of the translation table
  \ a2 = addres of the translation

: translation!  ( ca len a c -- ) 'translation 2! ;
  \ Store a string into a translation table.
  \ ca len = string
  \ a = address of the translation table
  \ c = character to store into

: translation,  ( c ca len -- )
  rot 'table @ swap translation! ;
  \ Compile a translation into the translation table.

: translations,  ( c'1 ca'1 len'1 ... c'n ca'n len'n n -- )
  0 ?do translation, loop ;
  \ Compile the translations into the translation table.
  \ n = number of translations

: translation@  ( a c -- ca len | 0 0 ) 'translation 2@ ;
  \ Fetch a translation from a translation table
  \ (or two zeros if no translation has been defined for the character).
  \ a = address of the translation table
  \ c = character to translate
  \ ca len = translation

: translation@?  ( a c -- ca len f ) translation@ 2dup + ;
  \ Fetch a translation from a translation table.
  \ a = address of the translation table
  \ c = character to translate
  \ ca len = translation
  \ f = valid translation?

: string>uncodepaged  ( ca len -- )
  uncodepaged-str str-append-string ;
  \ Append a string to the uncodepaged string.

: char>uncodepaged  ( c -- )
  1 uncodepaged-str str-append-chars ;
  \ Append a character to the uncodepaged string.

: >uncodepaged  ( a c -- )
  dup >r translation@? r> swap
  if   drop string>uncodepaged
  else char>uncodepaged 2drop then ;
  \ Append a translation to the uncodepaged string.
  \ a = address of the translation table
  \ c = character whose translation to add

\ ==============================================================
\ User interface

public

: uncodepage:  ( "name" -- )
  new_table  dup 'table !  constant  depth depth0 !  ;
  \ Start the definition of a translation table.
  \ "name" = name of the translation table; it will return its address

: ;uncodepage  ( c'1 ca'1 len'1 ... c'n ca'n len'n -- )
  #translations translations, ;
  \ End the definition of a translation table.

: uncodepaged  ( ca len a  -- ca' len' )
  uncodepaged-str str-clear
  rot rot bounds ?do  dup i c@ >uncodepaged loop  drop
  uncodepaged-str str-get ;
  \ Translate a string with a translation table.
  \ ca len = string to translate
  \ a = address of the translation table
  \ ca' len' = translated string

end-package

\ ==============================================================
\ Usage example

false [if]

uncodepage: table0
  \ The order of the chars in the table is irrelevant:
  48      s" [ZERO]"
  0x20    s" &nbsp;"
  '1'     s" 2"
  char a  s" (OLD-LOWERCASE-A)"
;uncodepage

.( Original string:) cr
s" 101 blabla" 2dup type cr
.( Translated string:) cr
table0 uncodepaged  type cr

[then]

\ ==============================================================
\ Change log

\ 2013-12-12 Written, based on <galope/translated.fs>, as a better
\ alternative to ftrac
\ (<http://programandala.net/en.program.ftrac.html>).
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-12-04: Update source style.
