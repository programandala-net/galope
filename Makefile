# Makefile

# This file is part of Galope
# http://programandala.net/en.program.galope.html

# Last modified 20250224T1728+0100

# Author {{{1
# ==============================================================

# Marcos Cruz (programandala.net), 2017, 2018, 2020, 2025.

# License {{{1
# ==============================================================

# You may do whatever you want with this work, so long as you
# retain every copyright, credit and authorship notice, and this
# license.  There is no warranty.

# Requirements {{{1
# ==============================================================

# Asciidoctor (by Dan Allen and Sara White)
# 	http://asciidoctor.org

# asciidoctor-pdf (by Dan Allen and Sara White)
# 	http://asciidoctor.org

# cat (from the GNU coreutils)

# Gforth (by Anton Erlt, Bernd Paysan et al.)
# 	http://gnu.org/software/gforth

# Glosara (by Marcos Cruz)
# 	http://programandala.net/en.program.glosara.html

# htmldoc (by Michael Sweet)
# 	http://www.htmldoc.org

# pandoc (by Johw Macfarlane)
#	http://john-macfarlane.net/pandoc

# History {{{1
# ==============================================================

# See at the end of the file.

# Notes about make {{{1
# ==============================================================

# $@ = the name of the target of the rule
# $< = the name of the first prerequisite
# $? = the names of all the prerequisites that are newer than the target
# $^ = the names of all the prerequisites

# `%` works only at the start of the filter pattern

# Config {{{1
# ==============================================================

VPATH = ./

MAKEFLAGS = --no-print-directory

#.ONESHELL:

# Main {{{1
# ==============================================================

.PHONY: all
all: doc

.PHONY: clean
clean: cleandoc

.PHONY: cleandoc
cleandoc:
	-rm -f doc/*.html doc/*.pdf tmp/*.adoc

# Documentation {{{1
# ==============================================================

.PHONY: doc
doc: \
	doc/galope_manual.html \
	doc/galope_manual.pdf

# Common rules {{{2
# ----------------------------------------------

doc/%.pdf: tmp/%.adoc
	asciidoctor-pdf --out-file $@ $<

%.html: %.adoc
	asciidoctor --out-file=$@ $<

tmp/glossary.adoc: tmp/files.txt
	glosara --level=3 --input=$< --output=$@

#glosara --level=3 -m "glossary{ }glossary" --input=$< --output=$@

%.docbook: %.adoc
	asciidoctor --backend=docbook --out-file=$@ $<

%.texi: %.docbook
	pandoc -o $@ $<

%.info: %.texi
	makeinfo -o $@ $<

# Main {{{2
# ----------------------------------------------

galope_modules=$(wildcard *.fs)

doc/galope_manual.html: \
	tmp/galope_manual.adoc \
	README.adoc
	asciidoctor --out-file=$@ $<

tmp/manual_skeleton.adoc: \
	docsrc/manual_skeleton.adoc \
	VERSION.txt
	version=$$(cat VERSION.txt); \
	sed -e "s/%VERSION%/$${version}/" $< > $@

tmp/files.txt: $(galope_modules)
	ls -1 $^ > $@

tmp/galope_manual.adoc: \
	tmp/manual_skeleton.adoc \
	tmp/glossary.adoc
	cat $^ > $@

doc/galope_manual.texi: tmp/galope_manual.docbook
	pandoc -o $@ $<

doc/galope_manual.info: doc/galope_manual.texi
	makeinfo -o $@ $<

# README {{{1
# ==============================================================

readme_title = Galope

include Makefile.readme

# Change log {{{1
# ==============================================================

# 2017-07-14: Start.
#
# 2017-07-15: Try Glosara `--output` parameter.
#
# 2017-11-20: First try to create Texinfo and Info versions of the manual.
#
# 2017-11-21: Improve.
#
# 2018-12-07: Update requirements.
#
# 2018-12-19: Replace htmldoc with asciidoctor-pdf, the PDF is much better.
#
# 2020-12-24: Build an online version of the README file for the Fossil
# repository.
#
# 2025-02-24: Include <Makefile.readme> to build a Commonmark version of
# <README.adoc>.
