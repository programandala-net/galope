\ galope/stream_bs.fs
\ Multiline buffered strings from the source stream

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ 2012-04-30 First version.
\ 2012-09-14 The code was reformated.

require module.fs
require svariable.fs

module: galope_string_bs

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
