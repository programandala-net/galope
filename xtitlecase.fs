\ galope/xtitlecase.fs
\ 'xtitlecase'
\ Convert a UTF-8 string to titlecase
\ (change uppercase the first character of every word)

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2013,2014 Marcos Cruz (programandala.net)

\ History
\ 2013-08-27: Written, based on 'xuppercase'.
\ 2014-11-17: Module name updated.

require ./module.fs
require ./xbounds.fs
require ./xcase.fs
require ./x-c-store.fs
require ./tilde-tilde.fs

module: galope-xtitlecase-module

variable apart?
: ?word_separation  ( xc -- )
  \ Update the word separation flag: is xc a word separation char?
  dup bl = swap [char] - = or apart? !
  ;
: first_of_word?  ( n -- wf )
  \ Is the n-position xchar the first character of a word?
  0= apart? @ or
  ;

export

: xtitlecase  ( xca len -- )  \ xxx todo fixme
  \ Convert a UTF-8 string to titlecase.
  apart? off
  xbounds ( xca n 0 ) ?do
    dup xc@+ ( xca xca' xc )  i first_of_word?
    over ?word_separation  \ update for the **next** loop
    if  xtoupper rot xc!  else  drop nip  then
  loop  drop
  ;

;module
