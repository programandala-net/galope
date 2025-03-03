# Galope

## Description

Galope is a general-purpose [Forth](http://forth-standard.org) library.
It started in 2012 in order to compile Forth code that was common to
several Forth projects under development by the author, and also Forth
code that was generic enough to be useful in future projects.

Galope is focused on [Gforth](http://gnu.org/software/gforth), but most
of its code is sytem-independent. In fact Galope has shared code with
the library of [Solo
Forth](http://programandala.net/en.program.solo_forth.html), in both
directions.

The home page of the project is
<http://programandala.net/en.program.galope.html>.

## Current status

As of 2020-11 Galope consists of 360 module files. Many of them contain
only one definition, even simple one-liner ones; others contain whole
tools.

Galope is used by most Forth projects of the author, but anything in the
library may be changed before its first public release.

The documentation is 80% finished. Its main part is a detailed glossary,
with full descriptions, usage examples and cross references. The manual
(in EPUB, HTML and PDF) is built from the source code by
[Glosara](http://programandala.net/en.program.glosara.html) ([Glosara in
SourceHut](https://hg.sr.ht/~programandala_net/glosara)).

## About the name

"Galope" stands for "Gforth Accessory Library Of Particular Elements".
In Spanish, "galope" is a noun that means "gallop"; in Esperanto,
"galope" is an adverb (the "-e" ending marks the adverbs in this
language) that means "at a gallop". "Galope" is pronounced identically
in Spanish and Esperanto; its phonemic transcription using the
International Phonetic Alphabet (IPA) is: /ɡa’lope/.

## Installation

In order to use the library, the path to its modules must be accessible
from your Forth system.

For Gforth, two methods are suggested:

One method is to add the Galope’s source directory to Gforth’s `fpath`.
Consult the documentation of Gforth.

A second method is to make a symbolic link to Galope’s sources directory
from Gforth’s \<site-forth\> directory. In a locally compiled Gforth,
the command on a Linux shell would be the following:

    sudo ln -s ~/YOUR-PATH/ /usr/local/share/gforth/site-forth/galope

where "YOUR-PATH" must be replaced with the corresponding path to
Galope’s sources directory on your system.

## History of the repository

2016-06-21: In order to preserve the evolution of the code and prepare
the first public release, a Git repository was created out of
development and ordinary backups created since 2013 (one year after the
beginning of the project).

2020-11-29: The Git repository was converted to a
[Fossil](https://fossil-scm.org), keeping GitHub as a mirror.

2023-04-01: The repository was converted to
[Mercurial](https://mercurial-scm.org), which allows bidirectional
communication with Git.

2025-02-23: The repository was uploaded to
[SourceHut](https://hg.sr.ht/~programandala_net/galope), keeping GitHub
as a mirror.
