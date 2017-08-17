\ galope/uncodepaged.fs
\ Tool to transform a string,
\ converting certain of its 8-bit chars to strings.

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ ==============================================================
\ Requirements

require ./module.fs
require ffl/str.fs

\ ==============================================================
\ Core

module: galope-uncodepaged-module

str-create uncodepaged-str
variable depth0
3 constant stack/translation
2 cells constant /translation
256 constant chars/table
chars/table /translation * constant /table
variable 'table  \ address of the translation table just defined
: erase_table  ( a -- )
  \ Erase a translation table.
  /table erase
  ;
: new_table  ( -- a )
  \ Create a new translation table.
  /table allocate throw  dup erase_table
  ;
: #translations  ( c1 ca1 len1 ... c'n ca'n len'n -- c1 ca1 len1 ... c'n ca'n len'n n )
  \ Calculate the number of translations defined in the translation table.
  depth depth0 @ - stack/translation /
  ;
: 'translation  ( a1 c -- a2 )
  \ Return the address of a translation in a translation table.
  \ a1 = address of the translation table
  \ c = character of the translation table
  \ a2 = addres of the translation
\  ." 'translation " cr .s cr key drop  \ xxx informer
\  ." 'table " 'table ? cr key drop  \ xxx informer
  /translation * +
  ;
: translation!  ( ca len a c -- )
  \ Store a string into a translation table.
  \ ca len = string
  \ a = address of the translation table
  \ c = character to store into
  'translation 2!
  ;
: translation,  ( c ca len -- )
  \ Compile a translation into the translation table.
  rot 'table @ swap translation!
  ;
: translations,  ( c'1 ca'1 len'1 ... c'n ca'n len'n n -- )
  \ Compile the translations into the translation table.
  \ n = number of translations
\  .s cr key drop  \ xxx informer
  0 ?do  translation,  loop
  ;
: translation@  ( a c -- ca len | 0 0 )
  \ Fetch a translation from a translation table
  \ (or two zeros if no translation has been defined for the character).
  \ a = address of the translation table
  \ c = character to translate
  \ ca len = translation
  'translation 2@
  ;
: translation@?  ( a c -- ca len f )
  \ Fetch a translation from a translation table.
  \ a = address of the translation table
  \ c = character to translate
  \ ca len = translation
  \ f = valid translation?
  translation@ 2dup +
  ;
: string>uncodepaged  ( ca len -- )
  \ Append a string to the uncodepaged string.
\  ." string>uncodepaged START" cr .s cr key drop  \ xxx informer
  uncodepaged-str str-append-string
  ;
: char>uncodepaged  ( c -- )
  \ Append a character to the uncodepaged string.
\  ." char>uncodepaged START" cr .s cr key drop  \ xxx informer
  1 uncodepaged-str str-append-chars
  ;
: >uncodepaged  ( a c -- )
  \ Append a translation to the uncodepaged string.
  \ a = address of the translation table
  \ c = character whose translation to add
\  ." >uncodepaged START" cr .s cr key drop  \ xxx informer
  dup >r translation@? r> swap
\  ." >uncodepaged BEFORE IF" cr .s cr key drop  \ xxx informer
  if    drop string>uncodepaged
  else  char>uncodepaged 2drop  then
  ;

\ ==============================================================
\ User interface

export

: uncodepage:  ( "name" -- )
  \ Start the definition of a translation table.
  \ "name" = name of the translation table; it will return its address
  new_table  dup 'table !  constant  depth depth0 !
  ;
: ;uncodepage  ( c'1 ca'1 len'1 ... c'n ca'n len'n -- )
  \ End the definition of a translation table.
  #translations translations,
  ;
: uncodepaged  ( ca len a  -- ca' len' )
  \ Translate a string with a translation table.
  \ ca len = string to translate
  \ a = address of the translation table
  \ ca' len' = translated string
  uncodepaged-str str-clear
  rot rot bounds ?do  dup i c@ >uncodepaged loop  drop
  uncodepaged-str str-get
  ;

;module

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
\ (<http://programandala.net/es.program.ftrac.html>).
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
