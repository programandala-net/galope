\ galope/sourcepath.fs

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-09-28 Written.

require ./minus-filename.fs

: sourcepath  ( -- ca len )
  \ Return the path of the source file being interpreted.
  sourcefilename -filename
  ;
