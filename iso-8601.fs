\ galope/iso-8601.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2017, 2018.

\ ==============================================================

variable extended-iso-8601  extended-iso-8601 on

  \ doc{
  \
  \ extended-iso-8601 ( -- a )
  \
  \ _a_ is the address of a cell containing a flag. If the flag is
  \ non-zero, ISO 8601 strings are created in extended format (with
  \ separators) instead of basic format (without them).  Otherwise the
  \ basic format is used.
  \
  \ The default value of ``extended-iso-8061`` is _true_.
  \
  \ See: `iso-8601-t`, `iso-8601-colon`, `iso-8601-hyphen`,
  \ `date>iso`, `time>iso`, `time&date>iso`, `>yyyymmddhhmmss`.
  \
  \ }doc

variable iso-8601-t iso-8601-t on

  \ doc{
  \
  \ iso-8601-t ( -- a )
  \
  \ _a_ is the address of a cell containing a flag. If the flag is
  \ non-zero, the words that convert date and time to ISO 8601 strings
  \ use a 'T' character to separate date from time.  Otherwise no
  \ separator is included.
  \
  \ The default value of ``iso-8601-t`` is _true_.
  \
  \ See: `time&date>iso`,  `extended-iso-8061`.
  \
  \ }doc

: iso-8601-colon ( -- ) extended-iso-8601 @ if ':' hold then ;

  \ doc{
  \
  \ iso-8601-colon ( -- )
  \
  \ If `extended-iso-8061` contains a non-zero flag, do ``':' hold``;
  \ otherwise do nothing.  ``iso-8601-colon`` is a factor of
  \ `time>iso`.
  \
  \ See: `iso-8601-hyphen`, `iso-8601-t$`.
  \
  \ }doc

: iso-8601-hyphen ( -- ) extended-iso-8601 @ if '-' hold then ;

  \ doc{
  \
  \ iso-8601-hyphen ( -- )
  \
  \ If `extended-iso-8061` contains a non-zero flag, do ``'-' hold``;
  \ otherwise do nothing.  ``iso-8601-hyphen`` is a factor of
  \ `date>iso`.
  \
  \ See: `iso-8601-colon`, `iso-8601-t$`.
  \
  \ }doc

: iso-8601-t$ ( -- ca len ) s" T" iso-8601-t @ and ;

  \ doc{
  \
  \ iso-8601-t$ ( -- ca len )
  \
  \ If `iso-8601-t` contains a non-zero flag, return the 'T'
  \ character as the string _ca len_. Otherwise return an empty
  \ string.
  \
  \ See: `time&date>iso`, `iso-8601-colon`, `iso-8601-hyphen`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2017-11-13: Start. New words to configure the ISO 8601 converters.
\
\ 2018-07-22: Improve documentation.
