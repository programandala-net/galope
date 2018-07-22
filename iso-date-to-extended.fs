\ galope/iso-date-to-extended.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2006, 2013, 2014,
\ 2017, 2018.

\ ==============================================================

require ./package.fs
require ./buffer-colon.fs

package galope-iso-date-to-extended

10 chars constant /iso-date

/iso-date 1+ chars buffer: iso-date

: +iso-length ( u -- ) iso-date c@ + iso-date c! ;
  \ Add _u_ to the length of the ISO date.

: >iso ( ca len u -- ) 1+ iso-date + swap cmove ;
  \ Copy a string _ca len_ to the date buffer, with offset _u_.

: year>iso ( ca len -- )
  dup 3 > if   drop 4 0 >iso 4 +iso-length
          else 2drop  then ;
  \ Extract the year from a string _ca len_ that is in the
  \ format "yyyy[mm[dd]]", and place it in the date buffer.

: >cc ( ca len u -- ca' 2 ) nip + 2 ;
  \ Get two characters at position _u_ of the given string _ca
  \ len_.

: cc>iso ( ca len u -- ) >iso 3 +iso-length ;
  \ Copy string _ca len_ to position _u_ in the ISO date.

: month>iso ( ca len -- ) dup 5 > if    4 >cc 5 cc>iso
                                  else  2drop then ;
  \ Extract the month from a string _ca len_ in the format
  \ "yyyy[mm[dd]]", and place it in the date buffer.

: day>iso ( ca len -- ) dup 7 > if   6 >cc 8 cc>iso
                                else 2drop then ;
  \ Extract the day from a string in the format "yyyy[mm[dd]]",
  \ and place it in the date buffer.

: -iso-date ( -- ) 0 iso-date c!
                   iso-date 1+ /iso-date '-' fill ;
  \ Init the date buffer.

public

: iso-date>extended ( ca1 len1 -- ca2 len2 )
  -iso-date
  2dup year>iso 2dup month>iso day>iso
  iso-date count ;

  \ doc{
  \
  \ iso-date>extended ( ca1 len1 -- ca2 len2 )
  \
  \ Convert an ISO-8601 date string _ca1 len1_ from basic
  \ format "yyyy[mm[dd]]" to extended format _ca2 len2_
  \ "yyyy[-mm[-dd]]".
  \
  \ See: `time&date>iso`, `>yyyymmddhhmmss`.
  \
  \ }doc

end-package

\ ==============================================================
\ Change log

\ 2013-05-18: `yyyymmdd>iso` taken from fhp
\ (http://programandala.net/en.program.fhp.html).  Rewritten in
\ a much simpler way.
\
\ 2014-07-14: Code common to 'day>iso' and 'month>iso' is
\ factored out.
\
\ 2014-11-17: Module name updated.
\
\ 2017-08-17: Update change log layout.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-11-13: Update source style and stack comments. Improve
\ documentation.
\
\ 2017-11-14: Rename `yyyymmdd>iso` `iso-date>extended`. Rename
\ module accordingly. Update first entry of the change log.
\
\ 2018-07-22: Improve documentation.
