\ galope/stream_bs.fs
\ Multiline buffered strings from the source stream

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012,2013,2014,2017.

\ ==============================================================

require ./package.fs
require ./sb.fs
require ./svariable.fs

package galope-stream-bs

svariable end_of_stream

public

: stream>bs ( ca len "text" -- )
  end_of_stream place s" "
  begin
    parse-word dup
    if
      2dup end_of_stream count compare
      if bs& false else true then
    else
      2drop refill 0=
      abort" end of stream string missing" false
    then
  until 2drop ;

: bs(( ( "text<space><right paren><right paren>" -- ca len )
  s" ))" stream>bs ;

: bs<< ( "text<space><greater><greater>" -- ca len )
  s" >>" stream>bs ;

: bs[[ ( "text<space><]><]>" -- ca len )
  s" ]]" stream>bs postpone sliteral ; immediate

end-package

\ ==============================================================
\ Change log

\ 2012-04-30: First version.
\
\ 2012-09-14: The code was reformated.
\
\ 2013-05-28: Fix: 'require ./sb.fs' was missing.
\
\ 2014-11-17: Module name fixed.
\
\ 2017-08-17: Update change log layout. Update header and source style
\ and stack comments notation.
\
\ 2017-08-18: Use `package` instead of `module:`.
