
# Guía de contribución

## 1. Obtener el proyecto

Cada integrante debe realizar un Fork del repositorio original desde GitHub.

Después debe clonar su propio Fork:

```bash
git clone https://github.com/USUARIO/Actividad-6.git
```

Ingresar al proyecto:

```bash
cd Actividad-6
```

Configurar el repositorio original como upstream:

```bash
git remote add upstream https://github.com/zDANIEL-BOT/Actividad-6.git
```

## 2. Sincronizar cambios

Antes de comenzar una nueva tarea:

```bash
git fetch upstream
git switch main
git pull upstream main
```

## 3. Convención de ramas

Cada contribución debe realizarse en una rama independiente.

Se utilizarán los siguientes prefijos:

- feature/: nuevas funcionalidades.
- fix/: corrección de errores.

Ejemplos:

```text
feature/modelos-servidores
feature/oauth-dropbox-spotify
feature/controladores-servidores
feature/put-soft-delete
fix/error-autenticacion
```

## 4. Convención de commits

Los commits deben describir claramente los cambios realizados.

Ejemplos:

```text
Se agregaron modelos de servidores
Se implementaron autenticacion con Dropbox
Se agregaron controladores protegidos
Se implementó soft delete
Se corrigieron las validacion de rutas
```

## 5. Implementación y pruebas

Antes de enviar una contribución, ejecutar:

```bash
dotnet restore
dotnet build
dotnet test
```

Verificar que los cambios funcionen y que no existan errores de compilación.

No incluir credenciales, contraseñas ni archivos de configuración con secretos.

## 6. Enviar contribuciones

Subir la rama al Fork personal:

```bash
git push origin NOMBRE-RAMA
```

Desde GitHub, crear una Pull Request con las siguientes características:

- Base repository: zDANIEL-BOT/Actividad-6.
- Base branch: main.
- Compare branch: rama de trabajo del Fork personal.

La descripción debe explicar los cambios realizados y las pruebas ejecutadas.

## 7. Revisión de Pull Requests

- Todas las Pull Requests requieren revisión.
- El líder revisará y aprobará las contribuciones de los integrantes.
- Las Pull Requests del líder deben ser revisadas por otro integrante.
- El autor nunca debe aprobar su propia Pull Request.
- Ningún cambio debe integrarse directamente en main sin revisión.

## 8. Integración

Una vez aprobada la Pull Request, el líder realizará la integración.

Para la etapa de PUT y Soft Delete se utilizará Squash and merge, conservando los dos commits originales en la rama de trabajo y reuniéndolos en un único commit en main.