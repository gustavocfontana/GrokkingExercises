# 🚀 Quick Start - Blazor Web

## ⚡ Como Executar

### Opção 1: Linha de Comando

```bash
cd /Users/gustavofontana/RiderProjects/GrokkingExercises/GrokkingExercises.Web
dotnet run
```

Acesse: `https://localhost:5001`

### Opção 2: Rider

1. Abra a solução `GrokkingExercises.sln` no Rider
2. No Solution Explorer, clique com botão direito em **GrokkingExercises.Web**
3. Selecione **Set as Startup Project**
4. Pressione **Shift + F10** (Run)
5. O browser abre automaticamente

### Opção 3: Visual Studio

1. Abra `GrokkingExercises.sln`
2. Selecione **GrokkingExercises.Web** como startup project
3. Pressione **F5**

---

## 📋 Verificar se Funcionou

Você deve ver:

```
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shutdown.
```

E o browser abrirá automaticamente em `https://localhost:5001`

---

## 🎨 O que Você Verá

### Dashboard
- Cards clicáveis para cada funcionalidade
- Barra de progresso
- Conquistas
- Links para documentação
- Visualização dos exercícios
- Estatísticas de progresso

---

## 🐛 Troubleshooting

### Erro: "Porta em uso"

```bash
# Mude a porta em Properties/launchSettings.json
# Ou mate o processo:
lsof -ti:5001 | xargs kill -9
```

### Erro: "Project not found"

```bash
# Verifique se está na pasta correta
cd GrokkingExercises.Web

# Verifique se o .csproj existe
ls *.csproj
```

### Erro: "Cannot resolve reference"

```bash
# Restaure os pacotes
dotnet restore

# Rebuild
dotnet build
```

### Erro: "Blazor scripts not loading"

Verifique se `_Host.cshtml` tem:
```html
<script src="_framework/blazor.server.js"></script>
```

---

## 📁 Estrutura Atual

```
GrokkingExercises.Web/
├── Pages/
│   ├── _Host.cshtml        ✅
│   ├── Index.razor         ✅
├── Shared/
│   ├── MainLayout.razor    ✅
│   └── NavMenu.razor       ✅
├── wwwroot/
│   └── css/
│       └── site.css        ✅
├── _Imports.razor          ✅
├── App.razor               ✅
├── Program.cs              ✅
├── appsettings.json        ✅
└── *.csproj                ✅
```

---

## 🎯 Próximos Passos

1. ✅ Abrir no browser
2. ✅ Navegar pelo Dashboard
3. 🚧 Implementar páginas de Practice mode
4. 🚧 Implementar páginas de Exercises list
5. 🚧 Implementar página de Statistics

---

**Agora está tudo configurado! Execute e explore!** 🚀
