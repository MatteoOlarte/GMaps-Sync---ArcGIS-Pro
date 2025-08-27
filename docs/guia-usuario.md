# Guía de Usuario para GMaps Sync

Esta guía detalla cómo utilizar GMaps Sync para ArcGIS Pro, un add-in que permite sincronizar vistas entre ArcGIS Pro y Google Maps, así como acceder a Street View desde tu proyecto de ArcGIS.

## Interfaz de Usuario

Después de instalar GMaps Sync, encontrarás una nueva pestaña "GMaps" en la cinta de opciones de ArcGIS Pro. Esta pestaña contiene tres herramientas principales:

![Interfaz de GMaps Sync](images/gmaps-tab.png)

1. **Street View Tool** (Herramienta grande): Permite abrir Google Street View en una ubicación seleccionada.
2. **Abrir en Maps** (Botón): Sincroniza la vista actual de ArcGIS Pro con Google Maps.
3. **Traer de Maps** (Botón): Importa la vista actual de Google Maps a ArcGIS Pro.

## Uso de Street View

La herramienta Street View te permite seleccionar un punto en el mapa y definir una dirección para abrir Google Street View con esa vista específica.

### Pasos para usar Street View:

1. Haz clic en la herramienta "Street View" en la pestaña GMaps.
2. Haz clic en el mapa donde desees colocar el punto de vista.
3. Sin soltar el botón del ratón, arrastra para definir la dirección de visualización.
4. Al soltar el botón, se abrirá Google Street View en tu navegador web.

![Uso de Street View](images/street-view-usage.png)

> [!TIP]
> Para obtener mejores resultados, asegúrate de seleccionar un punto en una vía o calle donde Street View esté disponible.

## Sincronización de ArcGIS Pro a Google Maps

Esta función te permite abrir Google Maps con la misma vista que tienes actualmente en ArcGIS Pro.

### Pasos para sincronizar de ArcGIS Pro a Google Maps:

1. Navega a la ubicación deseada en tu mapa de ArcGIS Pro.
2. Ajusta el nivel de zoom que desees mantener en Google Maps.
3. Haz clic en el botón "Abrir en Maps" en la pestaña GMaps.
4. Se abrirá una ventana del navegador con Google Maps centrado en la misma ubicación.

![ArcGIS a Google Maps](images/arcgis-to-gmaps.png)

## Sincronización de Google Maps a ArcGIS Pro

Esta función te permite importar la vista actual de Google Maps a ArcGIS Pro.

### Pasos para sincronizar de Google Maps a ArcGIS Pro:

1. Abre Google Maps en tu navegador web.
2. Navega a la ubicación deseada y ajusta el nivel de zoom.
3. Asegúrate de que la ventana de Google Maps está visible.
4. Regresa a ArcGIS Pro y haz clic en el botón "Traer de Maps" en la pestaña GMaps.
5. La vista de ArcGIS Pro se actualizará para mostrar la misma ubicación y zoom que Google Maps.

![Google Maps a ArcGIS](images/gmaps-to-arcgis.png)

> [!NOTE]
> Esta función requiere que Google Maps esté abierto en tu navegador antes de hacer clic en el botón.

## Configuración de Preferencias

GMaps Sync permite configurar el navegador web y la ubicación del WebDriver.

### Para acceder a la configuración:

1. Ve a "Proyecto" > "Opciones" > "GMaps"
2. Selecciona tu navegador preferido (Chrome o Firefox)
3. Especifica la ruta al archivo WebDriver
4. Haz clic en "Guardar"

![Configuración](images/configuration.png)

## Casos de Uso Comunes

### Comparación de Imágenes Satelitales

1. Abre tu mapa en ArcGIS Pro.
2. Haz clic en "Abrir en Maps".
3. Compara las imágenes satelitales de ArcGIS Pro con las de Google Maps.

### Exploración con Street View

1. Localiza un área de interés en ArcGIS Pro.
2. Usa la herramienta Street View para explorar a nivel de calle.
3. Identifica características que pueden no ser visibles en imágenes aéreas.

### Transferencia de Ubicaciones

1. Encuentra una ubicación interesante en Google Maps.
2. Haz clic en "Traer de Maps" para centrar ArcGIS Pro en esa ubicación.
3. Realiza análisis avanzados con las herramientas de ArcGIS Pro.

## Consejos y Trucos

- **Coordenadas Precisas**: Para la mejor sincronización, asegúrate de usar datos geoespaciales con proyecciones correctas.
- **Navegación Eficiente**: Utiliza las sincronizaciones para cambiar rápidamente entre las vistas de ambas plataformas.
- **Combinación con Otras Herramientas**: Combina GMaps Sync con otras herramientas de ArcGIS Pro para análisis más completos.

## Limitaciones Conocidas

- La sincronización de vistas tiene pequeñas variaciones debido a diferentes proyecciones y sistemas de referencia.
- Street View puede no estar disponible en todas las ubicaciones.
- El rendimiento depende de tu conexión a internet y de la velocidad de tu equipo.
