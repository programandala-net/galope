\ galope/in-brackets.fs

\ This file is part of Galope
\ http://programandala.net/en.program.galope.html

\ Author: Marcos Cruz (programandala.net), 2018

\ ==============================================================

: in-brackets ( ca1 len1 -- ca2 len2 )
  s" [" 2swap s" ]" s+ s+ ;

  \ doc{
  \
  \ in-brackets ( ca1 len1 -- ca2 len2 )
  \
  \ Return string _ca1 len1_ in brackets as string _ca2 len2_.
  \
  \ See: `in-parens`, in-spaces.
  \
  \ }doc

\ ==============================================================
\ Change log

\ 2018-07-27: Move from project _El arcabuz de agua_
\ (http://programandala.net/es.programa.el_arcabuz_de_agua.html).
