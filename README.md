# Adres Technical Test

Este repositorio contiene la solución para la prueba técnica de Adres, incluyendo:

- Backend en **.NET 10**
- Frontend en **Angular 19**

## Estructura del repositorio

```
Adres.Procurement.Services/   # Backend .NET 10 (API, lógica de negocio, dominio, infraestructura)
Adres.Web/                    # Frontend Angular 19
docker-compose.yml            # Orquestación de servicios con Docker
```

## Levantar el proyecto con Docker Compose

1. Clona el repositorio:

   ```sh
   git clone https://github.com/natalyoc12/Adres.Test.git
   cd Adres.Test
   ```

2. Ejecuta Docker Compose:
   ```sh
   docker-compose up --build
   ```

Esto levantará los siguientes servicios:

- **api**: Backend .NET en modo desarrollo, expuesto en el puerto `8080`.
- **sqlserver**: Base de datos SQL Server, expuesta en el puerto `1433`.

La API estará disponible en: [http://localhost:8080](http://localhost:8080)

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
