# SIGUE Google Sync

Potencia tu experiencia en QGIS integrando Google Street View y sincronizando la vista con Google Maps de forma bidireccional. Explora, navega y compara ubicaciones en tiempo real, todo desde la comodidad de tu entorno QGIS.

> [!important]
> Este complemento no integra Google Maps como un **navegador embebido** dentro de QGIS. Al abrir Street View o sincronizar la vista entre Google Maps y QGIS (en ambos sentidos), se abrirá una ventana de navegador aparte.

## Características principales

### Street View

![Abrir Street View](docs/icons/location-man-alt-60.png)



|     |     |
| --- | --- |

Con esta herramienta, el usuario puede elegir un punto en el mapa y la dirección de visualización. Al confirmar, Google Street View se abrirá en una ventana aparte, mostrando la ubicación y orientación seleccionadas desde QGIS.

### QGIS - Google Maps sync

![alt text](docs/icons/world-map-60.png)

Con esta herramienta, el usuario puede sincronizar la vista actual de QGIS con Google Maps. Al activarla, se abrirá una ventana de navegador mostrando la misma ubicación y nivel de zoom que tiene el mapa en QGIS.

### Google Maps - QGIS sync

![alt text](docs/icons/map-time-60.png)

Con esta herramienta, el usuario puede sincronizar la vista actual de Google Maps con QGIS. Al activarla, el mapa de QGIS se centrará y ajustará automáticamente según la ubicación y el nivel de zoom que tenga Google Maps.

## Instalación

### QGIS Plugin Manager

1. Descarga la última versión.
2. Abre QGIS.
3. Ve a Complementos > Administrar e Instalar Complementos > Instalar a partir de ZIP.
4. Selecciona el archivo ZIP descargado.
5. Haz clic en "Instalar Complemento".
6. Una vez instalado, se abrirá una ventana para seleccionar el navegador y el driver a usar.

### Instalación Manual

1. Descarga la última versión.
2. Copia la carpeta del plugin en:
   * Windows 11: `C:\Users\[USERNAME]\AppData\Roaming\QGIS\QGIS3\profiles\default\python\plugins\`
   * MacOS/Linux: `~/.qgis3/python/plugins/`
3. Abre QGIS

> [!Note]
> ¿Usas Linux? Consulta la guía detallada de instalación, solución de problemas y errores frecuentes aquí: [Instalación en Linux](gmaps_sigue/docs/instalacion_linux.md)

## Uso

* Abre QGIS y accede al menú de SIGUE Google Sync.
* Configura el navegador y el driver siguiendo las indicaciones del asistente.
* Utiliza las opciones del complemento para abrir Street View, sincronizar la vista con Google Maps o centrar el mapa de QGIS según Google Maps.

## Requisitos

* QGIS 3.40+ (Qt5 o Qt6)
* Python 3.12+
* Selenium 4.34.2
* ChromeDriver o GeckoDriver según el navegador seleccionado

## Licencia

Este proyecto está bajo la Licencia GPL v2 o superior.

## Autor

EAAB - [`molarte@acueducto.com.co`](mailto:molarte@acueducto.com.co)
