import os

path = "./Okra/View/Commands"

def removeExtension(filename):
	return os.path.splitext(file)[0]
	
for root,dirs,files in os.walk(path): 
	for file in files:
		command = removeExtension(file)
		ns = os.path.split(root)[-1]
		print("<%s:%s x:Key=\"%s\" ViewModel=\"{StaticResource ViewModel}\" />" % (ns,command, command))