#!/bin/sh

. pkginfo

(cd .. && msbuild /p:Configuration=Release) || exit 1

nuget pack ../MarkdownDeep/MarkdownDeep.nuspec -Properties version=$version
nuget pack ../MarkdownRenderers/MarkdownRenderers.nuspec -Properties version=$version
nuget pack ../MDGui.Gtk3/MDGui.Gtk3.nuspec -Properties version=$version -Tool 


