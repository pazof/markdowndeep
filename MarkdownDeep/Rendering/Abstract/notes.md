
# l'interface IMarkdownRenderer' #

Actuellement définie ainsi : `interface IMarkdownRenderer<TFinal,TSpan,TBlock>`.

mieux aurait vallu une interface parlant de

```csharp
     IMarkdownRenderer<TFinal, TContext, TManager>

     where TContext : ISimpleTextReference
        where TManager : IRenderer<TFinal,TContext>
```

