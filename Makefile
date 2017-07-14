# Makefile

# This file is part of Galope
# http://programandala.net/en.program.galope.html

# Last modified 201707141521

# ==============================================================
# Author

# Marcos Cruz (programandala.net), 2017.

# ==============================================================
# License

# You may do whatever you want with this work, so long as you
# retain every copyright, credit and authorship notice, and this
# license.  There is no warranty.

# ==============================================================
# Requirements

# Asciidoctor (by Dan Allen)
# 	http://asciidoctor.org

# cat (from the GNU coreutils)

# Gforth (by Anton Erlt, Bernd Paysan et al.)
# 	http://gnu.org/software/gforth

# Glosara (by Marcos Cruz)
# 	http://programandala.net/en.program.glosara.html

# htmldoc (by Michael Sweet)
# 	http://www.htmldoc.org

# ==============================================================
# History

# See at the end of the file.

# ==============================================================
# Notes about make

# $@ = the name of the target of the rule
# $< = the name of the first prerequisite
# $? = the names of all the prerequisites that are newer than the target
# $^ = the names of all the prerequisites

# `%` works only at the start of the filter pattern

# ==============================================================
# Config

VPATH = ./

MAKEFLAGS = --no-print-directory

#.ONESHELL:

# ==============================================================
# Main

.PHONY: all
all: doc

.PHONY: clean
clean: cleandoc

.PHONY: cleandoc
cleandoc:
	-rm -f doc/*.html doc/*.pdf tmp/*.adoc

# ==============================================================
# Documentation

# ----------------------------------------------
# Common rules

%.pdf: %.html
	htmldoc \
		--book \
		--no-toc \
		--linkcolor blue \
		--linkstyle plain \
		--header " t " \
		--footer "  1" \
		--format pdf14 \
		--webpage \
		$< > $@

%.html: %.adoc
	asciidoctor --out-file=$@ $<

tmp/glossary.adoc: tmp/files.txt
	glosara --level=3 --input=$< > $@

%.docbook: %.adoc
	asciidoctor --backend=docbook --out-file=$@ $<

# ----------------------------------------------
# Main

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

.PHONY: doc
doc: doc/galope_manual.html doc/galope_manual.pdf

# ==============================================================
# Change log

# 2017-07-14: Start.
