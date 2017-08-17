\ galope/paragraph.fs
\ Left justified paragraphs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2012.

\ Based on:
\ galope/print.fs

\ Based on:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License

\ ==============================================================

require ./print.fs

2 value indentation

: (paragraph) ( -- ) print_cr indentation print_indentation ;

: paragraph ( ca len -- ) (paragraph) print ;

\ ==============================================================
\ Change log

\ 2012-09-29 Start. A wrapper for galope/print.fs, based on its usage
\ example.
\
\ 2012-12-18 Module removed. '(paragraph)' refactored.
\
\ 2013-08-30 Change: Stack notation.
\
\ 2017-08-17: Update change log layout. Update header.
