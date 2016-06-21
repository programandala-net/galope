\ galope/replaced.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-28 Copied from Fendo
\ (http://programandala.net/en.program.fendo.html); the order of the
\ parameters is changed.

require ./module.fs
require ffl/str.fs

module: galope-replaced-module
str-create tmp-str
export
: replaced ( ca1 len1 ca2 len2 ca3 len3 -- ca1' len1' )
  \ Replaces all ocurrences of ca3 len3 with ca2 len2 in ca1 len1.
  \ ca1 len1 = string to modify ("haystack")
  \ ca2 len2 = substring to replace with
  \ ca3 len3 = substring to be replaced ("needle")
  2rot tmp-str str-set  tmp-str str-replace  tmp-str str-get
  ;
;module
