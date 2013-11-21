\ galope/headline.fs

\ xxx todo unfinished

\ This file is part of Galope

\ Copyright (C) 2012 Marcos Cruz (programandala.net)

\ History
\ 2012-04-29 First version.
\ 2012-09-14 Removed unused mroll.fs. Code reformated.
\ 2013-11-06 Changed the stack notation of flag.

require module.fs
require xy.fs

module: galope_headline

variable y variable x  \ top left coordinates
variable heigth  \ rows of the headline
variable width  \ max width that can be shown

: +row?  ( u -- wf )
  heigth @ 1- <
  ;
: (+row)  cr x @ at-x
  ;
: +row  ( u -- )
  +row? if (+row) then
  ;
: row/  ( a1 u1 -- a1 u1 | a1 u2 )
  width @ min
  ;
: .row  ( a1 u1 u2 -- )
  >r row/ type r> +row
  ;
: (.headline)  ( a u ... a' u' n -- )
  0 do i .row loop
  ;
: init  ( u -- )
  heigth ! cols column dup x ! - width !
  ;

export

: .headline  ( a1 u1 ... an un n -- )
  \ Print a headline at the current cursor position.
  \ n = headline rows
  dup init 2rolls  heigth @ (.headline)
  ;

\ ----8<------------------------
\ Unfinished addon!!!
: (.banner)  ( xt u -- )
  y @ at-xy execute .headline
  ;
: .banner  ( xt -- )
  row y !
  dup 0 cols 1- do  dup i (.banner)  -1 +loop  drop
  ;
\ ----8<------------------------

\ ----8<------------------------
false [if]  \ Unfinished alternative!!! 
: headline"  ( -- )
  postpone s"
  ; immediate
: headline:  ( "name" -- )
  here create 2 cells allot
  ;
: ;headline  ( a -- )
  ;
[then]
\ ----8<------------------------

\ Testing

: epic  ( -- a0 u0 ... a7 u7 8 )
  s"  _______ _______ _______ _   ________________               _______ _______ _________________________ _______ _______"
  s" (  ___  )  ____ \  ___  ) \  \__   __/  ___  )  |\     /|  (  ____ \  ___  )  ____ \__   __/\__   __/(  ____ \  ___  )"
  s" | (   ) | (    \/ (   ) | (     ) (  | (   ) |  ( \   / )  | (    \/ (   ) | (    \/  ) (      ) (   | (    \/ (   ) |"
  s" | (___) | (_____| (___) | |     | |  | |   | |   \ (_) /   | |     | (___) | (_____   | |      | |   | |     | |   | |"
  s" |  ___  |_____  )  ___  | |     | |  | |   | |    \   /    | |     |  ___  |_____  )  | |      | |   | | ____| |   | |"
  s" | (   ) |     ) | (   ) | |     | |  | |   | |     ) (     | |     | (   ) |     ) |  | |      | |   | | \_  ) |   | |"
  s" | )   ( |\____) | )   ( | (____/\ |  | (___) |     | |     | (____/\ )   ( |\____) |  | |   ___) (___| (___) | (___) |"
  s" |/     \|_______)/     \|_______/_(  (_______)     \_/     (_______//     \|_______)  )_(   \_______/(_______)_______)"
  8 \ lines
  ;


: ogre  ( -- a0 u0 ... a5 u5 6 )
  s"    _             _ _                                  _   _"
  s"   /_\  ___  __ _| | |_  ___    _   _    ___  __ _ ___| |_(_) __ _  ___"
  s"  //_\\/ __|/ _` | | __|/ _ \  | | | |  / __|/ _` / __| __| |/ _` |/ _ \"
  s" /  _  \__ \ (_| | | |_| (_) | | |_| | | (__| (_| \__ \ |_| | (_| | (_) |"
  s" \_/ \_/___/\__,_|_|\__|\___/   \__, |  \___|\__,_|___/\__|_|\__, |\___/"
  s"                                |___/                        |___/"
  6 \ lines
  ;

: maxfour ( -- a0 u0 ... a3 u3 4 )
  s"   /\        | |                      | '"
  s"  /__\ (~/~~||~|~/~\  \  /  /~~/~~|(~~|~|/~~|/~\"
  s" /    \_)\__|| | \_/   \/   \__\__|_) | |\__|\_/"
  s"                      _/                 \__|"
  4 \ lines
  ;
  
;module
