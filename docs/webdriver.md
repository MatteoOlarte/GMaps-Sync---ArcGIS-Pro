# Instalación y Configuración del WebDriver

Una parte fundamental para el correcto funcionamiento de GMaps Sync es la correcta configuración de Selenium WebDriver, que permite la interacción con los navegadores web.

## ¿Qué es WebDriver?

WebDriver es una herramienta que permite a programas y scripts automatizar acciones en un navegador web, como si fuera un usuario real. En el caso de GMaps Sync, se utiliza para:

- Abrir Google Maps con una ubicación específica
- Interactuar con Street View
- Obtener y sincronizar coordenadas entre ArcGIS Pro y Google Maps

## WebDrivers Soportados

GMaps Sync soporta los siguientes navegadores:

### Google Chrome

Requiere ChromeDriver: [Descargar ChromeDriver](https://chromedriver.chromium.org/downloads)

### Mozilla Firefox

Requiere GeckoDriver: [Descargar GeckoDriver](https://github.com/mozilla/geckodriver/releases)

## Instrucciones de Instalación

### Paso 1: Descargar el WebDriver

1. Identifica qué navegador utilizarás (Chrome o Firefox)
2. Determina la versión de tu navegador:
   - En Chrome: Menú ⋮ > Ayuda > Acerca de Google Chrome
   - En Firefox: Menú ☰ > Ayuda > Acerca de Firefox
3. Descarga la versión del WebDriver que coincida con tu versión de navegador

> [!IMPORTANT]
> La versión del WebDriver **debe** coincidir con la versión principal de tu navegador.

### Paso 2: Extraer el WebDriver

1. Los WebDrivers suelen venir en formato comprimido (.zip)
2. Extrae el contenido a una ubicación permanente en tu equipo
   - Ejemplo: `C:\WebDrivers\`
3. No muevas el archivo después de configurar el add-in

### Paso 3: Configurar GMaps Sync

1. Abre ArcGIS Pro
2. Ve a la pestaña "Proyecto" > "Opciones" > "GMaps"
3. En la sección de configuración:
   - Selecciona el navegador que vas a utilizar (Chrome o Firefox)
   - Haz clic en "Examinar" para seleccionar la ubicación del WebDriver que descargaste
   - Haz clic en "Guardar"

![Configuración del WebDriver](images/webdriver-config.png)

## Solución de Problemas

### El add-in no encuentra el WebDriver

- Verifica que la ruta proporcionada es correcta y el archivo existe
- Asegúrate de que el archivo tiene permisos de ejecución
- Comprueba que el WebDriver coincide con la versión de tu navegador

### El navegador se abre pero muestra errores

- Verifica que la versión del WebDriver coincida exactamente con tu navegador
- Actualiza tanto el navegador como el WebDriver a la última versión
- Reinicia ArcGIS Pro y prueba nuevamente

### El WebDriver funciona pero Google Maps no carga correctamente

- Asegúrate de tener conexión a Internet
- Verifica que no hay problemas de red o firewall que bloqueen Google Maps
- Comprueba que tu navegador puede acceder a Google Maps normalmente

## Mantenimiento

Es importante mantener actualizado el WebDriver:

1. Cuando actualices tu navegador, es posible que necesites actualizar también el WebDriver
2. Descarga la nueva versión y reemplaza el archivo antiguo
3. Actualiza la configuración en GMaps Sync si cambió la ubicación del archivo

## Configuración Avanzada

### Configuración Personalizada del Navegador

En casos avanzados, GMaps Sync permite configurar opciones adicionales para el WebDriver a través de archivos de configuración. Consulta la documentación detallada si necesitas personalizar el comportamiento del navegador.
