\ galope/time&date-to-iso.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History

\ 2014-07-13: Written. Inspired by code from fhp ("Forth HTML
\ Preprocessor") version B-00-201206, <fhp-date.fs>.

\ .............................................................
\ Code

\ XXX TODO
\ svariable time-zone
\ s" +02:00" time-zone place  \ system dependent time zone
\ s" CET" time-zone place  \ system dependent time zone
\ s" Z" time-zone place  \ alternative for UTC time zone

: time>d  ( u1 u2 u3 -- d )
  10000 * swap 100 * + + s>d
  ;
: time>hh:mm:ss  ( u1 u2 u3 -- ca len )
  \ u1 = hour
  \ u2 = minute
  \ u3 = second
  time>d <# # # [char] : hold # # [char] : hold #s #>
  ;
: date>yyyy-mm-dd  ( u1 u2 u3 -- ca len )
  \ u1 = day
  \ u2 = month
  \ u3 = year
  time>d <# # # [char] - hold # # [char] - hold #s #>
  ;
: time&date>iso  ( u1 u2 u3 u4 u5 u6 -- ca len )
  \ u1 = second
  \ u2 = minute
  \ u3 = hour
  \ u4 = day
  \ u5 = month
  \ u6 = year
  \ ca len = ISO date
  date>yyyy-mm-dd s" T" s+ 2>r time>hh:mm:ss 2r> 2swap s+
  \ XXX TODO time-zone count >>html
  ;

