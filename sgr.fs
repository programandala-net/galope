\ galope/sgr.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ History
\
\ 2012-12-02 Refactored from the "Asalto y castigo" project
\ (<http://programandala.net/es.programa.asalto_y_castigo.forth>).



\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

require ffl/trm.fs  \ Forth Foundation Library

\ SGR (Select Graphic Rendition) parameters not included in the
\ 'trm' module of Forth Foundation library.
\
\ Reference:
\ <http://en.wikipedia.org/wiki/ANSI_escape_code#graphics>.

003 constant trm.italic-on
023 constant trm.italic-off
090 constant trm.foreground-black-high
091 constant trm.foreground-red-high
092 constant trm.foreground-green-high
093 constant trm.foreground-brown-high
094 constant trm.foreground-blue-high
095 constant trm.foreground-magenta-high
096 constant trm.foreground-cyan-high
097 constant trm.foreground-white-high
100 constant trm.background-black-high
101 constant trm.background-red-high
102 constant trm.background-green-high
103 constant trm.background-brown-high
104 constant trm.background-blue-high
105 constant trm.background-magenta-high
106 constant trm.background-cyan-high
107 constant trm.background-white-high

' trm+set-attributes alias sgr
