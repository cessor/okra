# -*- coding: utf-8 -*-
from BeautifulSoup import BeautifulSoup


	
aliases = {
	"Control" : "Ctrl"
}
	
class Interaction(object):
	
	keyformat = "[%s]"

	def __init__(self, binding):
		self.binding = binding
		self.modifierKey = self.part("modifiers")
		self.key = self.part("key")
		self.command = self.part("command")
	
	def format(self, key):
		return self.keyformat % key
	
	def part(self, attribute):
		return (self.binding.get(attribute) or "").strip()
		
	def formatCommand(self):
		return self.command.replace("{o:Commands", '').replace("}",'').strip()

	def alias(self, mod):
		if mod in aliases.keys():
			return aliases[mod]
		return mod
		
	def formatModifier(self):	
		if self.modifierKey:
			mod = self.alias(self.modifierKey)
			return "%s + " % self.format(mod)
		return ""
		
	def __str__(self):
		return "%s%s : %s" % (self.formatModifier(), self.format(self.key), self.formatCommand())
		

def soup(file):
	content = ""
	with open(file) as file:
		content = file.read() #.encode("utf-8", "ignore")
	return BeautifulSoup(content)

def keymap(view):
	xaml = soup(view)
	interactions = keybindings(xaml)
	interactions.sort(key=lambda i:i.command)
	for interaction in interactions:
		print str(interaction)

def keybindings(xaml):
	return [Interaction(b) for b in xaml.findAll("keybinding")]
 	
if __name__ == "__main__":
	view = "Okra/View/Clock/MainWindow.xaml"	
	keymap(view)