
CONFIG=Debug
MSBARGS="/p:Configuration=$(CONFIG)" 
# /p:RunCodeAnalysis=true
VERSION=1.5.8

NUSF=MarkdownDeep/MarkdownDeep.nuspec MDGuiGtk2/MDGuiGtk2.nuspec MarkdownRenderers/MarkdownRenderers.nuspec  MDGuiGtk3/MDGuiGtk3.nuspec
PKGS=$(notdir $(patsubst %.nuspec,%-$(VERSION).nupkg,$(NUSF)))

all:
	msbuild $(MSBARGS)

pack: $(PKGS)


%-$(VERSION).nupkg : %
	nuget pack -Version $(VERSION) $^/$^.nuspec

run:
	mono MDGuiGtk3/bin/$(CONFIG)/MDGui.Gtk3.exe&

runmd:
	monodevelop MarkdownDeep.sln&

