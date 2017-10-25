\ galope/heredoc.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

require ./package.fs
require ./s-plus.fs

package galope-heredoc

variable /heredoc  \ delimiter, a dynamic string

: /heredoc? ( ca len -- f ) /heredoc $@ str= ;

public

: (heredoc) ( ca1 len1 "text<name>" -- ca2 len2 )
  /heredoc $!  s" "
  begin  parse-name dup
    if   2dup /heredoc? dup >r
         if  2drop  else  s+ s"  " s+  then  r>
    else 2drop refill 0= dup abort" Missing final heredoc's delimiter"
    then
  until  -trailing ;

  \ doc{
  \
  \ (heredoc) ( ca1 len1 "ccc<name>" -- ca2 len2 )
  \
  \ Parse _ccc_ delimited by _ca1 len1_ that is _name_.  Return a
  \ string _ca2 len2_ that describes the string consisting of the
  \ characters _ccc_.
  \
  \ ``(heredoc)`` is a factor of `heredoc`. See `heredoc` for a usage
  \ example.
  \
  \ }doc

: heredoc ( "<name>text<name>" -- ca len )
  parse-name dup 0= abort" Missing initial heredoc's delimiter"
  (heredoc) ;

  \ doc{
  \
  \ heredoc ( "<name>ccc<name>" -- ca len )
  \
  \ Parse _name_, then parse _ccc_ delimited by _name_.  Return a
  \ string _ca len_ that describes the string consisting of the
  \ characters _ccc_.
  \
  \ ``heredoc`` was inspired by PHP's homonymous notation.
  \
  \ Usage examples:

  \ ----
  \ ' heredoc alias <<<
  \
  \ <<< EOT bla bla bla
  \   bla bla bla
  \   bla bla bla
  \   EOT type
  \
  \ : {{  s" }}" (heredoc)  ;
  \
  \ {{ bla bla bla
  \   bla bla bla
  \   bla bla bla }} type
  \
  \ :noname  s\" \"" (heredoc) save-mem  ;
  \ :noname  s\" \"" (heredoc) postpone sliteral  ;
  \ interpret/compile: txt"

  \ txt" bla bla bla
  \ bla bla " type
  \ ----

  \ See: `"`, `["`, `<"`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2013-06-27: Added.
\
\ 2014-02-18: Trivial change in the loop; '/heredoc?' factored out
\ from the loop.
\
\ 2014-10-26: Fix: stack comment of '(heredoc)'.
\
\ 2014-11-17: Module name updated.
\
\ 2017-07-15: Require `s+`, which was removed from Gforth 0.7.9.
\ Update layout.
\
\ 2017-08-17: Update stack notation. Document.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-10-25: Update minor layout details.
