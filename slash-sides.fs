\ galope/slash-sides.fs
\ /sides

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ 2013-07-11 Added. Taken from Fendo
\ (http://programandala.net/en.program.fendo)
\ 2013-11-06 Changed the stack notation of flag.

require ./sides.fs  \ 'sides'

: /sides  { ca1 len1 ca2 len2 -- ca1 len1' ca3 len3 wf }
  \ Search a string ca1 len1
  \ for the first occurence of a substring ca2 len2.
  \ Divide the string ca1 len1 in two parts: return both sides
  \ of the substring ca2 len2 (first occurence), excluding the
  \ substring ca2 len2 itself.
  \ 2013-06-07
  \ This word was inspired by Wil Baden's 'hunt'
  \ (Charscan library, 2003-02-17, public domain).
  \ ca1 len1  = string
  \ ca2 len2  = substring
  \ ca1 len1' = left side (or whole string if not found)
  \ ca3 len3  = right side (or empty string if not found)
  \ wf = found?
  \ Note: ca3 len3 can be empty also when wf is true.
  ca1 len1 ca2 len2 search dup >r
  if    ca1 len1 len2 sides
  else  over 0  \ fake right side
  then  r>
  ;
