\ galope/sides-slash.fs
\ sides/

\ This file is part of Galope

\ Copyright (C) 2013 Marcos Cruz (programandala.net)

\ **************************************************************
\ Change log

\ 2013-06-07 First version, written as part of Fendo
\ (http://programandala.net/en.program.fendo) This word was inspired
\ by Wil Banden's 'hunt' (Charscan library, 2003-02-17, public
\ domain).

\ 2013-07-11 Moved to Galope. 

\ 2013-11-06 <plus-slash-string.fs> was unnecessary but still
\ included.

\ 2013-11-06 Fixed: It didn't work if the substring was at the start
\ of the string, because the result flag was calculated at the end
\ comparing the last result of 'search' with the original string.  The
\ solution was to preserve any true flag returned by 'search' and use
\ it as result flag.

\ **************************************************************

require ./sides.fs  \ 'sides'
require ./str-not-equals.fs  \ 'str<>'

: sides/  { ca1 len1 ca2 len2 -- ca1 len1' ca3 len3 wf }
  \ Search a string ca1 len1
  \ for the last occurence of a substring ca2 len2.
  \ Divide the string ca1 len1 in two parts: return both sides
  \ of the substring ca2 len2 (last occurence), excluding the
  \ substring ca2 len2 itself.
  \ ca1 len1  = string
  \ ca2 len2  = substring
  \ ca1 len1' = left side (or whole string if not found) 
  \ ca3 len3  = right side (or empty string if not found)
  \ wf = result flag: found?
  \ Note: ca3 len3 can be empty also when wf is true.
  false >r  \ default value of the result flag 
  ca1 len1 2dup
  begin   ca2 len2 search
          dup r> or >r  \ update the result flag
  while   2nip 2dup +x/string   \ update the result and step forward
  repeat  2drop
  r@  \ something was found?
  if    ca1 len1 len2 sides
  else  over 0  \ fake right side
  then  r>
  ;
