# Actividad 6

- Creador del repositorio: Carlos Miranda

## Descripción

Proyecto de Hosting de Servidores del juego 'Terraria'.

## Tecnologías utilizadas

- C#
- .NET 10
- Entity Framework Core
- PostgreSQL
- Scalar

<<<<<<< HEAD
## Reparto de métodos de inicio de sesión

- Carlos Abraham Viza Huarachi: Discord y Google
- Adolfo Kevin Cruz Merma: Twitch y Microsoft
- Carlos Daniel Miranda Almazan: DropBox y Spotify
=======
## Integrantes del equipo

| Integrante                    | Rol        | Proveedor fácil | Proveedor medio |
|-------------------------------|------------|-----------------|-----------------|
| Carlos Daniel Miranda Almazan | Líder      | Dropbox         | Spotify         |
| Carlos Abraham Viza Huarachi  | Integrante | Discord         | Google          |
| Adolfo Kevin Cruz Merma       | Integrante | Twitch          | Microsoft       |

## Distribución de tablas

Cada integrante será responsable de implementar sus tablas, incluyendo modelos, configuración del contexto, migraciones y controladores.

| Tabla                    | Responsable                      |
|--------------------------|----------------------------------|
| configuracion_servidores | Carlos Daniel Miranda Almazan    |
| eventos_servidores       | Carlos Daniel Miranda Almazan    |
| puertos_servidores       | Carlos Daniel Miranda Almazan    |
| usuarios                 | Compartida entre los integrantes |


| Tabla                    | Responsable                      |
|--------------------------|----------------------------------|
| juegos                   | Carlos Abraham Viza Huarachi     |
| version_juegos           | Carlos Abraham Viza Huarachi     |
| servidores               | Carlos Abraham Viza Huarachi     |
| usuarios                 | Compartida entre los integrantes |


| Tabla                    | Responsable                      |
|--------------------------|----------------------------------|
| roles                    | Adolfo Kevin Cruz Merma          |
| copias_seguridad         | Adolfo Kevin Cruz Merma          |
| almacenamiento_servidores| Adolfo Kevin Cruz Merma          |
| usuarios                 | Compartida entre los integrantes |

## Flujo de trabajo

El proyecto utiliza una modalidad de colaboración mediante Fork y Pull Requests.

1. Cada integrante realiza un Fork del repositorio original.
2. Clona su propio Fork.
3. Crea una rama para cada etapa de trabajo.
4. Implementa y prueba sus cambios.
5. Realiza un Push a su Fork.
6. Abre una Pull Request hacia la rama main del repositorio original.
7. El líder revisa, aprueba e integra los cambios.

Ningún integrante debe ser agregado como colaborador del repositorio original.

## Integración de cambios

- Todas las contribuciones deben ingresar mediante Pull Requests.
- Las Pull Requests deben ser revisadas antes de integrarse.
- El autor de una Pull Request no puede aprobar su propia propuesta.
- Para la etapa final de PUT y Soft Delete se utilizará Squash and merge.
>>>>>>> upstream/main
