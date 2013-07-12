\ galope/yyyymmdd-to-iso.fs

\ This file is part of Galope

\ Copyright (C) 2006,2013 Marcos Cruz (programandala.net)

\ History
\ 2013-05-18 Taken from fhp (http://programandala.net/en.program.fhp).
\   Rewritten in a much simpler way.

require ./module.fs
require ./buffer-colon.fs

module: galope_yyyymmdd-to-iso

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
  else  2drop
  then
  ;
: month>iso  ( ca len -- )
  \ Receive a string in the format "yyyy[mm[dd]]",
  \ extract the month and place it at the date buffer.
  dup 5 >
  if    4 /string drop 2  5 >iso  3 +iso_length
  else  2drop
  then
  ;
: day>iso  ( ca len -- )
  \ Receive a string in the format "yyyy[mm[dd]]",
  \ extract the day and place it at the date buffer.
  dup 7 >
  if    6 /string drop 2  8 >iso  3 +iso_length
  else  2drop
  then
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
