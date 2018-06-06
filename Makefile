
CONFIG=Debug
DEFAULTMSBARGS=/p:RunCodeAnalysis=true

all:
	msbuild $(DEFAULTMSBARGS)


run:
	mono MDGuiGtk3/bin/$(CONFIG)/MDGui.Gtk3.exe&

runmd:
	monodevelop MarkdownDeep.sln&

