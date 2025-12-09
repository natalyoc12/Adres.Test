# Adres Technical Test

Este repositorio contiene la solución para la prueba técnica de Adres, incluyendo:

- Backend en **.NET 10**
- Frontend en **Angular 19**

## Estructura del repositorio

```
Adres.Procurement.Services/   # Backend .NET 10
Adres.Web/                    # Frontend Angular 19
docker-compose.yml            # Orquestación de servicios con Docker
setup.sh                      # Script de configuración inicial y levantamiento del entorno
```

## Levantar el proyecto (recomendado)

La forma más sencilla de levantar todo el entorno es ejecutar Docker Compose desde la raíz del repositorio:

1. Clona el repositorio:

   ```sh
   git clone https://github.com/natalyoc12/Adres.Test.git
   cd Adres.Test
   ```

2. Ejecuta Docker Compose:

   ```sh
   docker compose -p adrestest up -d --build
   ```

   o ejecuta el script de configuración:

   ```sh
   chmod +x ./setup.sh
   ./setup.sh
   ```

Esto levantará automáticamente:

- La base de datos SQL Server, expuesta en el puerto `1433`.
- El backend .NET (API), en modo desarrollo, expuesto en el puerto `8080`.
- El frontend Angular (web), expuesto en el puerto `80`.
- Un contenedor de migraciones que aplica las migraciones de Entity Framework antes de iniciar la API

No necesitas tener .NET ni Angular instalados localmente, ni ejecutar migraciones manualmente. Todo se realiza dentro de los contenedores.

- La API estará disponible en: [http://localhost:8080](http://localhost:8080)
- La app web estará disponible en: [http://localhost](http://localhost)

---

## Documentación de los proyectos internos

- **Backend (.NET 10):** Consulta la documentación específica en [`Adres.Procurement.Services/README.md`](Adres.Procurement.Services/README.md).

- **Frontend (Angular 19, Adres.Web):** Consulta la documentación específica en [`Adres.Web/README.md`](Adres.Web/README.md).

## Notas

- El proyecto está diseñado para ser fácilmente extensible, permitiendo agregar todos los componentes en el mismo repositorio.
- Si tienes dudas sobre la configuración, dependencias o el flujo de trabajo, revisa los README internos o contacta al autor.

---

## Contacto

- Autor: Leidy Nataly Ocampo
- Email: [[leidyocampo1821@gmail.com](leidyocampo1821@gmail.com)]
- Github: [https://github.com/natalyoc12]
- LinkedIn: [https://www.linkedin.com/in/leidy-nataly/]
