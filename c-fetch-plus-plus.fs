\ galope/c-fetch-plus-plus.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-18 Added.

\ Taken from Common Use compilation 2003 by Wil Baden.

: c@++  ( a -- a' c )
  dup char+ swap c@
  ;
