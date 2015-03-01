\ galope/file-exists-question.fs
\ file-exists?

\ This file is part of Galope

\ Copyright (C) 2015 Marcos Cruz (programandala.net)

\ 2015-02-01

: file-exists?  ( ca len -- wf )
  \ ca len = filename
  file-status -514 <> nip
  ;
