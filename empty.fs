\ galope/empty.fs

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-05-18 Added.
\ 2012-09-14 Code reformated.

\ Taken from ToolBelt 2002 by Wil Baden.

require ./anew.fs

\ empty  ( -- )

\ Reset the dictionary to a predefined golden state, discarding
\ all definitions and releasing all allocated data space beyond
\ that state.  This 'empty' uses '--empty--' to separate kernel
\ words and user words.  Rename '--empty--' if you wish.
\ 'marker --empty--' will setup a new golden area for 'empty'.
\ '--empty--' will restore the previous golden area.

: empty  ( -- )
    s" anew --empty-- decimal  only forth definitions "
    evaluate
    ;
