\ galope/stream_bs.fs
\ Multiline buffered strings from the source stream

\ This file is part of Galope

\ Copyright (C) 2012,2013,2014 Marcos Cruz (programandala.net)

\ History
\ 2012-04-30: First version.
\ 2012-09-14: The code was reformated.
\ 2013-05-28: Fix: 'require ./sb.fs' was missing.
\ 2014-11-17: Module name fixed.

require ./module.fs
require ./sb.fs
require ./svariable.fs

module: galope-stream-bs-module

svariable end_of_stream

export

: stream>bs  ( a u "text" -- )
  end_of_stream place  s" "
  begin
    parse-word dup
    if
      2dup end_of_stream count compare
      if  bs& false  else  true  then
    else
      2drop refill 0=
      abort" end of stream string missing" false
    then
  until  2drop
  ;

: bs((  ( "text<space><right paren><right paren>" -- a u )
  s" ))" stream>bs
  ;
: bs<<  ( "text<space><greater><greater>" -- a u )
  s" >>" stream>bs
  ;
: bs[[  ( "text<space><]><]>" -- a u )
  s" ]]" stream>bs postpone sliteral
  ;  immediate

;module
