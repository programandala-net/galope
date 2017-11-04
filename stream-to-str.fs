\ galope/stream-to-str.fs
\ stream>s
\ Multiline strings from the source stream

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012, 2013, 2014, 2017.

\ ==============================================================

require ./package.fs
require ./s-plus.fs
require ./s-variable.fs

package galope-stream-to-str

svariable end-of-stream

public

: stream>str ( ca len "text" -- )
  end-of-stream place  s" "
  begin
    parse-word dup
    if
      2dup end-of-stream count compare
      if    2swap s"  " s+ 2swap s+ false
      else  true
      then
    else
      2drop refill 0=
      abort" End of stream string missing" false
    then
  until  2drop 1 /string ;

' stream>str alias stream>s \ XXX TMP -- old name

: s(( ( "text<space><right paren><right paren>" -- ca len )
  s" ))" stream>s ;

: s<< ( "text<space><greater><greater>" -- ca len )
  s" >>" stream>s ;

: s[[ ( "text<space><]><]>" -- ca len )
  s" ]]" stream>s postpone sliteral ; immediate

end-package

\ ==============================================================
\ Change log

\ 2012-04-30: First version.
\
\ 2012-09-14: The code was reformated.
\
\ 2013-05-28: Typo in error message.
\
\ 2013-05-28: Fix: 'require ./sb.fs' was unnecessary.
\
\ 2013-09-28: File renamed from "stream_s.fs" to
\ "stream-to-string.fs".
\
\ 2014-11-17: Module name fixed.
\
\ 2015-10-22: Renamed file and two words.
\
\ 2017-07-15: Require `s+`, which was removed from Gforth 0.7.9.
\ Update layout and stack notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
\
\ 2017-11-04: Update filename of `svariable`.
