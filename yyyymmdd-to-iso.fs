\ galope/yyyymmdd-to-iso.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2006,2013 Marcos Cruz (programandala.net)

\ ==============================================================

require ./module.fs
require ./buffer-colon.fs

module: galope-yyyymmdd-to-iso-module

10 chars constant /iso-date
/iso-date 1+ chars buffer: iso-date

: +iso_length  ( u -- )
  \ Add a given number to the length of the ISO date.
  iso-date c@ + iso-date c!
  ;
: >iso  ( ca len u -- )
  \ Copy a string to the date buffer, with the u offset.
  1+ iso-date + swap cmove
  ;
: year>iso  ( ca len -- )
  \ Receive a string in the format "yyyy[mm[dd]]", extract the
  \ year and place it at the date buffer.
  dup 3 >
  if    drop 4  0 >iso  4 +iso_length
  else  2drop  then
  ;
: >cc  ( ca len u -- ca' 2 )
  \ Get two chars at u position of the given string.
  \ /string drop 2  \ XXX OLD first version
  nip + 2  \ XXX simpler
  ;
: cc>iso  ( ca len u -- )
  \ Copy the given string to the given position in the ISO date.
  >iso  3 +iso_length
  ;
: month>iso  ( ca len -- )
  \ Receive a string in the format "yyyy[mm[dd]]",
  \ extract the month and place it at the date buffer.
  dup 5 > if  4 >cc  5 cc>iso  else  2drop  then
  ;
: day>iso  ( ca len -- )
  \ Receive a string in the format "yyyy[mm[dd]]",
  \ extract the day and place it at the date buffer.
  dup 7 > if  6 >cc  8 cc>iso  else  2drop  then
  ;
: -iso-date  ( -- )
  \ Init the date buffer.
  0 iso-date c!  \ empty
  iso-date 1+ /iso-date [char] - fill  \ hyphens
  ;

export

: yyyymmdd>iso  ( c-addr1 u1 -- c-addr2 u2 )
  \ Convert a date string with the format "yyyy[mm[dd]]"
  \ to the format "yyyy[-mm[-dd]]".
  -iso-date
  2dup year>iso 2dup month>iso day>iso
  iso-date count
  ;

;module

\ ==============================================================
\ Change log

\ 2013-05-18: Taken from fhp
\ (http://programandala.net/en.program.fhp).  Rewritten in a much
\ simpler way.
\
\ 2014-07-14: code common to 'day>iso' and 'month>iso' is factored
\ out.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout.
