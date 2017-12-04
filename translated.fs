\ galope/translated.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Description: Tool to translate substrings of a string.

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require ./package.fs

require ffl/str.fs \ str module of Forth Foundation Library

package galope-translated

str-create translated-str

variable depth0

4 constant cells/translation

cells/translation cells constant /translation

: init-translations ( -- a )
  here 0 , depth depth0 ! ;
  \ Init a translation table before being defined, returning
  \ its address _a_, which will hold the number of translations
  \ that will be stored in the table.

: #translations ( -- n )
  depth depth0 @ - cells/translation / ;
  \ Return number _n_ of translations defined in the current
  \ translation table.

: translations, ( ca#1 len#1 .. ca#n len#n n -- )
  0 ?do 2, 2, loop ;
  \ Compile the _n_ translations _ca#1 len#1 .. ca#n len#n_ into the
  \ current translation table.

false [if]  \ XXX -- Not used

: translation@+ ( a -- a' ca1 len1 ca2 len2 )
  dup 2@ 2>r [ 2 cells ] literal +
  dup 2@ 2>r /translation +
         2r> 2r> ;
  \ a = address of the current translation
  \ a' = address of the next translation
  \ ca1 len1 = original string
  \ ca2 len2 = translated string

[then]

: translation@ ( a n -- ca1 len1 ca2 len2 )
  /translation * + dup 2@ rot 2 cells + 2@ ;
  \ Fetch a translation _n_ from a translation table _a_, returning
  \ the translated string _ca1 len1_ and its corresponding original
  \ string _ca2 len2_.

public

: translations ( "name" -- a1 )
  create init-translations
  does> ( -- a2 n ) ( dfa ) dup @ swap cell+ swap ;

  \ doc{
  \
  \ translations ( "name" -- a )
  \
  \ Start the definition of a translation table, to be used by
  \ `translated`, leaving address _a_ of the translation table, which
  \ will hold the number of translations.
  \
  \ Later execution of _name_ will leave the translation identifier
  \ _a2 n_ on the stack, being _a2_ the address of the first
  \ translation and _n_ the number of translations.
  \
  \ See: `end-translations`, `/translations`.
  \
  \ }doc

: end-translations ( a ca#1 len#1 .. ca#n len#n -- )
  #translations dup >r translations, r@ swap ! r> ;

  \ doc{
  \
  \ end-translations ( a ca#1 len#1 .. ca#n len#n -- n )
  \
  \ End the definition of a translation table _a_ started by
  \ `translations`, compiling translations _ca#1 len#1 .. ca#n
  \ len#n_. Return the number _n_ of compiled translations.
  \
  \ See: `translated`.
  \
  \ }doc

: translated ( ca len a n -- ca' len' )
  2swap translated-str str-set
  0 ?do dup i translation@ translated-str str-replace loop drop
  translated-str str-get ;

  \ doc{
  \
  \ translated ( ca1 len1 a n -- ca2 len2 )
  \
  \ Translate a string _ca1 len2_ using a translation table identified
  \ by _a n_ and previously defined by `translations`, resulting the
  \ translated string _ca2 len2_.
  \
  \ Usage example:
  \
  \ ----

  \ translations table0
  \   s" from3" s" to3"  \ last translation to be done
  \   s" from2" s" to2"
  \   s" from1" s" to1"  \ first translation to be done
  \ end-translations drop

  \ s" bla from2 bla from3 bla from1" table0 translated

  \ ----
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2013-12-10: Written.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout. Update header.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-10-26: Update source style. Reorganize public and private
\ words. Improve documentation.
\
\ 2017-11-21: Fix stack comment. Improve header.
\
\ 2017-12-04: Rename `translations:` `translations`; rename
\ `/translations` `end-translations`; remove `;translations`.
