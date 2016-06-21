\ galope/stream-to-str.fs
\ stream>s
\ Multiline strings from the source stream

\ This file is part of Galope

\ Copyright (C) 2012,2013,2014 Marcos Cruz (programandala.net)

\ History
\ 2012-04-30: First version.
\ 2012-09-14: The code was reformated.
\ 2013-05-28: Typo in error message.
\ 2013-05-28: Fix: 'require ./sb.fs' was unnecessary.
\ 2013-09-28: File renamed from "stream_s.fs" to "stream-to-string.fs".
\ 2014-11-17: Module name fixed.
\ 2015-10-22: Renamed file and two words.

require ./module.fs
require ./svariable.fs

module: galope-stream-to-str-module

svariable end-of-stream

export

: stream>str  ( a u "text" -- )
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
  until  2drop 1 /string
  ;

' stream>str alias stream>s  \ old name

: s((  ( "text<space><right paren><right paren>" -- a u )
  s" ))" stream>s
  ;
: s<<  ( "text<space><greater><greater>" -- a u )
  s" >>" stream>s
  ;
: s[[  ( "text<space><]><]>" -- a u )
  s" ]]" stream>s postpone sliteral
  ;  immediate

;module
