
CONFIG=Debug

all:
	msbuild


rungui:
	mono MDGuiGtk3/bin/$(CONFIG)/MDGui.Gtk3.exe&

runmd:
	monodevelop MarkdownDeep.sln&

