\ galope/char-replaced.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-05-10 Written.

: char-replaced ( ca len c1 c2 -- )
  \ Replaces all ocurrences of a char in a string.
  \ ca len = string to modify
  \ c1 = char to replace with
  \ c2 = char to be replaced
  { to_char from_char }
  bounds ?do
    i c@ from_char = if  to_char i c!  then
  loop
  ;

