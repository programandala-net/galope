\ galope/anew.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Wil Baden, from ToolBelt 2002.
\ Adapted to Galope: Marcos Cruz (programandala.net), 2012, 2017.

\ ==============================================================

require ./possibly.fs

: anew ( "name" -- )
  >in @ possibly >in ! marker ;

  \ doc{
  \
  \ anew ( "name" -- )
  \
  \ Compiler directive used in the form: ``anew name``. If the
  \ word _name_ already exists, it and all subsequent words are
  \ forgotten from the current dictionary, then a ``marker`` word
  \ _name_ is created.  This is usually placed at the start of a
  \ file. When the code is reloaded, any prior version is
  \ automatically pruned from the dictionary. Executing _name_
  \ will also cause it to be forgotten, since it is a `marker`
  \ word.
  \
  \ See: `possibly`.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2012-05-18: Added.
\
\ 2017-08-17: Update change log and header layout.
\
\ 2017-10-24: Improve documentation.
\
\ 2017-10-25: Update header format.
