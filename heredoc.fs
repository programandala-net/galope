\ galope/heredoc.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2013, 2014, 2017.

\ ==============================================================

require string.fs  \ Gforth's dynamic strings

require ./module.fs
require ./s-plus.fs

module: galope-heredoc-module

0 [if]  \ xxx old, first version
: <<<  ( "text>>>" -- ca len )
  \ Read text from the input stream until '>>>'
  s" "
  begin   parse-name ?dup
    if    2dup s" >>>" str= dup >r
          if    2drop
          else  s+ s"  " s+
          then  r>
    else  drop refill 0= dup abort" Missing '>>>'"
    then
  until   -trailing
  ;
[then]

variable /heredoc  \ delimiter, a dynamic string

: /heredoc? ( ca len -- f )
  /heredoc $@ str= ;

export

: (heredoc) ( ca1 len1 "text<name>" -- ca2 len2 )
  /heredoc $!  s" "
  begin   parse-name dup
    if    2dup /heredoc? dup >r
          if  2drop  else  s+ s"  " s+  then  r>
    else  2drop refill 0= dup abort" Missing final heredoc's delimiter"
    then
  until   -trailing ;
  \ Read text from the input stream until a certain <name> is found.
  \ This word was inspired by PHP's heredoc notation.
  \ ca1 len1 = <name>, the delimiter
  \ ca2 len2 = text from the input stream, until <name> is found

: heredoc ( "<name>text<name>" -- ca len )
  parse-name dup 0= abort" Missing initial heredoc's delimiter"
  (heredoc) ;
  \ Read text from the input stream until a certain <name> is found.
  \ This word was inspired by PHP's heredoc notation.
  \ <name> = delimiter name

;module

0 [if]

\ Usage examples

require ../galope/heredoc.fs

' heredoc alias <<<
<<< EOT bla bla bla
  bla bla bla
  bla bla bla
  EOT type

: {{  s" }}" (heredoc)  ;
{{ bla bla bla
  bla bla bla
  bla bla bla }} type

:noname  s\" \"" (heredoc) save-mem  ;
:noname  s\" \"" (heredoc) postpone sliteral  ;
interpret/compile: txt"

txt" bla bla bla
bla bla " type

[then]

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
\ 2017-08-17: Update stack notation.
