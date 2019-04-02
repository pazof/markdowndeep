

CONFIG=Debug
MSBARGS=/p:Configuration=$(CONFIG) /p:RunCodeAnalysis=true
VERSION=1.5.19

NUSF=MarkdownDeep/MarkdownDeep.nuspec MDGuiGtk2/MDGuiGtk2.nuspec MarkdownRenderers/MarkdownRenderers.nuspec  MDGuiGtk3/MDGuiGtk3.nuspec
PKGS=$(notdir $(patsubst %.nuspec,%-$(VERSION).nupkg,$(NUSF)))

all:
	msbuild $(MSBARGS)

MDGuiGtk3/bin/Debug//MDGui.Gtk3.exe:
	msbuild MDGuiGtk3 /p:Configuration=Debug

pack: $(PKGS)

clean:
	msbuild $(MSBARGS) /t:clean

%-$(VERSION).nupkg : %
	msbuild /p:Configuration=Release /restore $^
	nuget pack -Version $(VERSION) $^/$^.nuspec

run:
	mono MDGuiGtk3/bin/$(CONFIG)/MDGui.Gtk3.exe&

debug: MDGuiGtk3/bin/Debug//MDGui.Gtk3.exe
	mono --debug MDGuiGtk3/bin/Debug//MDGui.Gtk3.exe

runmd:
	monodevelop MarkdownDeep.sln&

