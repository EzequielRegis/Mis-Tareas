# 📱 TodoApp — .NET MAUI para Android

App de tareas para **Android** construida con **.NET MAUI (C# + XAML)** para Microsoft Visual Studio 2022.

## ✨ Funciones

- ✅ Crear tareas con título y descripción
- ✅ Marcar/desmarcar como completadas (con tachado)
- ✅ Eliminar tareas individuales y "Borrar completadas"
- ✅ Contador: `X pendientes · Y completadas`
- ✅ Estado vacío con mensaje guía
- ✅ MVVM con `INotifyPropertyChanged` + `ObservableCollection`

## 🛠️ Tecnologías

- **Lenguaje:** C# 12 (NET 8)
- **Framework:** .NET MAUI (Single Project)
- **UI:** XAML + CollectionView + Material Colors
- **Plataforma:** `net8.0-android` (min SDK 21, Android 5.0+)
- **IDE:** Microsoft Visual Studio 2022

## 📂 Estructura

```
TodoApp.sln
TodoApp/
├── TodoApp.csproj
├── MauiProgram.cs
├── App.xaml / App.xaml.cs
├── MainPage.xaml / MainPage.xaml.cs
├── Models/TodoItem.cs
├── ViewModels/TodoViewModel.cs
└── Platforms/Android/MainActivity.cs
```

## 🚀 Cómo ejecutar

### Requisitos
- Microsoft Visual Studio 2022 17.8+ con workload **Desarrollo para el móvil con .NET**
- .NET 8 SDK
- Android SDK API 34+

### Pasos
1. Abrí `TodoApp.sln` en Visual Studio
2. En el desplegable `Target` arriba elegí **Android emulator** o tu celular
3. Pulsa **▶ Iniciar** o `F5`
4. Visual Studio compila y instala en emulador/dispositivo

### Build CLI (sin abrir Visual Studio)
```powershell
dotnet workload restore
dotnet build TodoApp/TodoApp.csproj -f net8.0-android
```

El APK sale en `TodoApp/bin/Debug/net8.0-android/`

## 📄 Licencia

MIT
