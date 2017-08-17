#! /usr/bin/python
import os
import sys

codefiles = ['.java','.cs','.c','.cpp','.h'] # add Xaml here to include XAML files
c_family = [';','{','}']
xaml = ['<','>','{', '}'] # Xaml files contain {Binding Property} Shorthand for the MVVM Pattern

def write(string): 
	sys.stdout.write(string) 

def print_interesting_characters(file, interesting_characters):
	while True: 
		character = file.read(1)
		if character == "": return
		if character in interesting_characters:
			write(character)
	reset(file)

def print_line_count(file):
	lines = len(file.readlines())
	write(" (" + str(lines) + "): ")
	reset(file)

def reset(file):
	file.seek(0)
	
def print_signature(path):
	file = open(path, 'r')
	print_line_count(file)
	interesting_characters = c_family
	if extension(path) == ".xaml":
		interesting_characters = xaml
	print_interesting_characters(file, interesting_characters)
	file.close()
	
def extension(filename):
	return os.path.splitext(filename)[1]
		
def absolute_path(root, filename):
	return os.path.join(root, filename)
	
def should_skip(filename):
	return extension(filename) not in codefiles or "g.i.cs" in filename or ".g.cs" in filename

# Main
def signature_survey(directory):
	for root,dirs,files in os.walk(directory):
		for filename in files:
			if should_skip(filename): continue 			
			print()
			write(filename)	
			print_signature(absolute_path(root, filename))
			print

if __name__ == "__main__":
	signature_survey("Okra")