\ galope/time-and-date-to-iso.fs
\ time&date>iso

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History

\ 2014-07-13: Written. Inspired by code from fhp ("Forth HTML
\ Preprocessor") version B-00-201206, in file <fhp-date.fs>
\ (http://programandala.net/es.programa.fhp.html).
\ 2014-11-02: Change: stack notation, comment.

\ .............................................................
\ Code

\ XXX TODO
\ svariable time-zone
\ s" +02:00" time-zone place  \ system dependent time zone
\ s" CET" time-zone place  \ system dependent time zone
\ s" Z" time-zone place  \ alternative for UTC time zone

: time>d  ( n1 n2 n3 -- d )
  10000 * swap 100 * + + s>d
  ;
: time>hh:mm:ss  ( n1 n2 n3 -- ca len )
  \ n1 = hour
  \ n2 = minute
  \ n3 = second
  time>d <# # # [char] : hold # # [char] : hold #s #>
  ;
: date>yyyy-mm-dd  ( n1 n2 n3 -- ca len )
  \ n1 = day
  \ n2 = month
  \ n3 = year
  time>d <# # # [char] - hold # # [char] - hold #s #>
  ;
: time&date>iso  ( n1 n2 n3 n4 n5 n6 -- ca len )
  \ n1 = second
  \ n2 = minute
  \ n3 = hour
  \ n4 = day
  \ n5 = month
  \ n6 = year
  \ ca len = ISO date
  date>yyyy-mm-dd s" T" s+ 2>r time>hh:mm:ss 2r> 2swap s+
  \ XXX TODO time-zone count >>html
  ;

