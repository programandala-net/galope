\ galope/stream_s.fs
\ Multiline strings from the source stream

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-04-30 First version.
\ 2012-09-14 The code was reformated.
\ 2013-05-28 Typo in error message.
\ 2013-05-28 Fix: 'require ./sb.fs' was unnecessary. 

require ./module.fs
require ./svariable.fs

module: galope_string_s

svariable end_of_stream

export

: stream>s  ( a u "text" -- )
  end_of_stream place  s" "
  begin
    parse-word dup
    if
      2dup end_of_stream count compare
      if    2swap s"  " s+ 2swap s+ false
      else  true
      then
    else
      2drop refill 0= 
      abort" End of stream string missing" false
    then
  until  2drop 1 /string
  ;

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
