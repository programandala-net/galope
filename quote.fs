\ galope/less-than-quote.fs

\ This file is part of Galope

\ Copyright (C) 2014 Marcos Cruz (programandala.net)

\ History
\ 2014-02-13 Adapted from the word '<"', written by the same author in
\ 2013 for a text game.

require ./heredoc.fs

:noname  s\" \"" (heredoc) save-mem  ;
:noname  s\" \"" (heredoc) postpone sliteral  ;
interpret/compile: "
