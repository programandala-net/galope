\ galope/paragraph.fs
\ Left justified paragraphs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ Based on:
\ galope/print.fs

\ Based on:
\ 4tH library - PRINT - Copyright 2003,2010 J.L. Bezemer
\ You can redistribute this file and/or modify it under
\ the terms of the GNU General Public License

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History

\ 2012-09-29 Start. A wrapper for galope/print.fs, based on its
\ usage example.
\ 2012-12-18 Module removed. '(paragraph)' refactored.
\ 2013-08-30 Change: Stack notation.

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require ./print.fs

2 value indentation
: (paragraph)  ( -- )
  print_cr indentation print_indentation
  ;
: paragraph  ( ca len -- )
  (paragraph) print
  ;

