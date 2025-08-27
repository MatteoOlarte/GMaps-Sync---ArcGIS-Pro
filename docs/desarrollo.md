# Guía de Desarrollo para GMaps Sync

Esta guía está diseñada para desarrolladores que deseen contribuir al proyecto GMaps Sync para ArcGIS Pro o modificar el código fuente para sus propias necesidades.

## Requisitos Técnicos

- Visual Studio 2022 o superior
- ArcGIS Pro SDK para .NET (compatible con tu versión de ArcGIS Pro)
- .NET Framework compatible con ArcGIS Pro
- Conocimientos de:
  - C# y .NET
  - Patrones de diseño MVVM
  - Programación asíncrona
  - ArcGIS Pro SDK
  - Selenium WebDriver

## Arquitectura del Proyecto

El proyecto sigue una arquitectura de capas, basada en principios de Clean Architecture:

### Estructura de Carpetas

```
SIGUE Google-Sync/
├── Application/
│   ├── Ext/              # Extensiones de utilidades
│   ├── Services/         # Servicios como WebDriverHelper
│   └── UseCases/         # Casos de uso de la aplicación
├── Core/
│   ├── Browser.cs        # Enumeraciones y tipos core
│   └── Settings.cs       # Configuración del add-in
├── Presentation/
│   ├── View/             # Vistas XAML y code-behind
│   └── ViewModel/        # ViewModels para las vistas (MVVM)
├── Images/               # Recursos gráficos para modo claro
├── DarkImages/           # Recursos gráficos para modo oscuro
├── Config.daml           # Archivo de configuración para ArcGIS Pro
└── MainModule.cs         # Punto de entrada del add-in
```

### Patrones de Diseño

- **MVVM**: Separación de la lógica de presentación (ViewModel) de la interfaz (View)
- **Singleton**: Implementado en WebDriverHelper para mantener una única instancia del navegador
- **Command Pattern**: A través de RelayCommand para acciones de UI
- **Clean Architecture**: Separación de capas de aplicación, dominio y presentación

## Componentes Principales

### MainModule.cs

Es el punto de entrada del add-in y coordina la inicialización. Gestiona la validación del dominio y activa/desactiva estados según sea necesario.

```csharp
protected override bool Initialize()
{
    ProjectOpenedEvent.Subscribe(this.OnProjectOpened);
    return base.Initialize();
}

public void OnProjectOpened(ProjectEventArgs args)
{
    if (Common.ValidateDomain.Invoke())
    {
        FrameworkApplication.State.Activate("GMapsSync_InCompanyDomain");
        return;
    }
    FrameworkApplication.State.Deactivate("GMapsSync_InCompanyDomain");
}
```

### WebDriverHelper

Gestiona la interacción con el navegador web usando Selenium WebDriver. Implementa un patrón singleton para evitar múltiples instancias.

```csharp
public WebDriverHelper(Browser browser, string path)
{
    if (_driver is null)
    {
        _driver = this.CreateDriver(browser, path);
    }

    this.BrowserType = browser;
    this.DriverPath = path;
}
```

### StreetViewTool

Herramienta para seleccionar un punto y dirección en el mapa y abrir Google Street View.

### SyncButtons

Botones para sincronizar vistas entre ArcGIS Pro y Google Maps:

- ArcGISGoogleMapsSyncButton: Sincroniza desde ArcGIS Pro a Google Maps
- GoogleMapsArcGISSyncButton: Sincroniza desde Google Maps a ArcGIS Pro

## Flujo de Trabajo de Contribución

### Configuración del Entorno

1. Clona el repositorio

```
git clone https://github.com/yourusername/SIGUE-Google-Sync.git
```

2. Abre la solución en Visual Studio

3. Instala las dependencias NuGet:

   - ArcGIS.Desktop.SDK
   - Selenium.WebDriver
   - Selenium.Support

4. Configura la ruta de depuración para que apunte a ArcGIS Pro

### Convenciones de Código

- Seguir convenciones de nomenclatura de Microsoft para C#
- Utilizar `camelCase` para variables locales y privadas
- Utilizar `PascalCase` para nombres de clases, métodos y propiedades públicas
- Utilizar prefijo `_` para campos privados
- Agregar comentarios XML para clases y métodos públicos

### Compilación y Prueba

1. Compila la solución en Visual Studio
2. El add-in se copiará automáticamente a la carpeta de desarrollo de ArcGIS Pro
3. Inicia ArcGIS Pro para probar los cambios

### Depuración

Para depurar el add-in:

1. Configura Visual Studio para iniciar ArcGIS Pro al depurar
2. Coloca puntos de interrupción en tu código
3. Presiona F5 para iniciar la depuración

### Consejos de Depuración

- Usa `System.Diagnostics.Debug.WriteLine()` para registro de depuración
- Para problemas con WebDriver, verifica que la versión del controlador coincida con la versión del navegador
- Si el add-in no carga, revisa la configuración en `Config.daml`

## Consideraciones de Rendimiento

- El WebDriver es un recurso intensivo. Siempre cierra correctamente las instancias.
- Utiliza técnicas asíncronas para operaciones largas para evitar bloqueos de UI.
- Minimiza las transformaciones de coordenadas innecesarias.

## Consejos para Extensiones

Si deseas añadir nuevas características:

1. **Nuevas herramientas de mapeo**: Extiende la clase MapTool y regístrala en Config.daml
2. **Nuevas opciones de configuración**: Modifica Settings.settings y PropertyPageViewModel
3. **Soporte para más navegadores**: Amplía WebDriverHelper para incluir más navegadores
