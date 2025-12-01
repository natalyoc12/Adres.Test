# Adres Procurement Services

Sistema core para la gestión de adquisiciones de bienes y servicios. Construido en **.NET 10** siguiendo arquitectura limpia y buenas prácticas.

---

## Tabla de Contenidos

- [Descripción](#descripción)
- [Arquitectura](#arquitectura)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Requisitos Previos](#requisitos-previos)
- [Instalación y Ejecución](#instalación-y-ejecución)
- [Migraciones y Base de Datos](#migraciones-y-base-de-datos)
- [Uso de la API](#uso-de-la-api)
- [Documentación Swagger](#documentación-swagger)
- [Docker](#docker)
- [Contacto](#contacto)

---

## Descripción

Este proyecto expone servicios REST para la gestión de adquisiciones, permitiendo registrar, consultar, actualizar y gestionar documentos asociados a cada adquisición.

---

## Arquitectura

[![](https://mermaid.ink/img/pako:eNpVj0tOwzAQhq9izQqktEqcp4yElDQsuqsEbEiysBK3sajtyHYkIMmpOAIXww0FidEs5vH985igVR0DAidNhx49lXe1RM7yKj_sG7TZ3M-P6sxbbumMiiofXExb_vUpmx-wWJln49q7qlSCS67-tQ5MG24sm1FZ7eVRU2asHls7anrlypUrqGGoc06tMjN6qG7K4rYBz13GOyBOwzwQTAt6SWG6aGuwPROsBuLCjurXGmq5OM1A5YtS4lem1XjqgRzp2bhsHNwOVnLqfhZ_Vc1kx_ROjdICCcN1BpAJ3oDgCG9xGmSJn8VBjP008eDdQdE2DHCU4RCHaRL56eLBx7rV32ZpvHwDdmtsTw?type=png)](https://mermaid.live/edit#pako:eNpVj0tOwzAQhq9izQqktEqcp4yElDQsuqsEbEiysBK3sajtyHYkIMmpOAIXww0FidEs5vH985igVR0DAidNhx49lXe1RM7yKj_sG7TZ3M-P6sxbbumMiiofXExb_vUpmx-wWJln49q7qlSCS67-tQ5MG24sm1FZ7eVRU2asHls7anrlypUrqGGoc06tMjN6qG7K4rYBz13GOyBOwzwQTAt6SWG6aGuwPROsBuLCjurXGmq5OM1A5YtS4lem1XjqgRzp2bhsHNwOVnLqfhZ_Vc1kx_ROjdICCcN1BpAJ3oDgCG9xGmSJn8VBjP008eDdQdE2DHCU4RCHaRL56eLBx7rV32ZpvHwDdmtsTw)

- **API**: Expone los endpoints REST.
- **Application**: Lógica de negocio y validaciones.
- **Domain**: Entidades y contratos.
- **Infrastructure**: Persistencia y migraciones.

---

## Estructura del Proyecto

```
Adres.Procurement.Services/
├── Adres.Procurement.Api/           # API REST principal
├── Adres.Procurement.Application/   # Lógica de negocio
├── Adres.Procurement.Domain/        # Entidades y contratos
├── Adres.Procurement.Infrastructure/# Persistencia y migraciones
├── Dockerfile                       # Imagen Docker
├── Adres.Procurement.slnx           # Solución
```

---

## Requisitos Previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/) (opcional)
- Base de datos SQL Server (o compatible)

---

## Instalación y Ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/natalyoc12/Adres.Test.git
cd Adres.Test/Adres.Procurement.Services
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Ejecutar migraciones y levantar la base de datos

```bash
cd Adres.Procurement.Infrastructure
dotnet ef database update --startup-project ../Adres.Procurement.Api
```

### 4. Ejecutar la API

```bash
dotnet run --project Adres.Procurement.Api
```

La API estará disponible en `http://localhost:5115` (por defecto).

---

## Migraciones y Base de Datos

Para crear una nueva migración:

```bash
cd Adres.Procurement.Infrastructure
dotnet ef migrations add <NombreMigracion> --startup-project ../Adres.Procurement.Api
```

Para aplicar migraciones:

```bash
dotnet ef database update --startup-project ../Adres.Procurement.Api
```

Configura la cadena de conexión en `Adres.Procurement.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AdresDb;User Id=usuario;Password=clave;"
  }
}
```

O configura la variable de entorno `DB_CONNECTION_STRING`.

---

## Uso de la API

### Endpoints principales

#### 1. Crear adquisición

`POST /api/v1/procurements`

**Ejemplo de request (form-data):**
| Campo | Tipo | Ejemplo |
|------------|--------|-----------------|
| Budget | float | 15000.50 |
| Entity | string | "Ministerio X" |
| Item | string | "Computador" |
| Quantity | int | 10 |
| UnitPrice | float | 1500.05 |
| Date | string | 2025-12-01T10:00:00Z |
| Supplier | string | "Proveedor S.A."|
| Files | file | (PDF/JPG) |

**Curl:**

```bash
curl -X POST http://localhost:5115/api/v1/procurements \
  -F "Budget=15000.50" \
  -F "Entity=Ministerio X" \
  -F "Item=Computador" \
  -F "Quantity=10" \
  -F "UnitPrice=1500.05" \
  -F "Date=2025-12-01T10:00:00Z" \
  -F "Supplier=Proveedor S.A." \
  -F "Files=@/ruta/al/archivo.pdf"
```

#### 2. Listar adquisiciones

`GET /api/v1/procurements`

**Curl:**

```bash
curl http://localhost:5115/api/v1/procurements
```

**Respuesta ejemplo:**

```json
[
  {
    "id": "7a3bd86d-dfeb-4c23-ba5a-d397ea4ab119",
    "budget": 15000.5,
    "entity": "Ministerio X",
    "item": "Computador",
    "quantity": 10,
    "unitPrice": 1500.05,
    "date": "2025-12-01T10:00:00Z",
    "supplier": "Proveedor S.A.",
    "status": "Active"
  }
]
```

#### 3. Obtener adquisición por ID

`GET /api/v1/procurements/{procurementId}`

**Curl:**

```bash
curl http://localhost:5115/api/v1/procurements/7a3bd86d-dfeb-4c23-ba5a-d397ea4ab119
```

#### 4. Obtener archivo de adquisición

`GET /api/v1/procurements/{procurementId}/files/{fileId}`

**Curl:**

```bash
curl http://localhost:5115/api/v1/procurements/7a3bd86d-dfeb-4c23-ba5a-d397ea4ab119/files/123bd86d-dfeb-4c23-ba5a-d397ea4ab884
```

#### 5. Actualizar adquisición

`PUT /api/v1/procurements/{procurementId}`

**Curl:**

```bash
curl -X PUT http://localhost:5115/api/v1/procurements/7a3bd86d-dfeb-4c23-ba5a-d397ea4ab119 \
  -H "Content-Type: application/json" \
  -d '{
    "budget": 20000.00,
    "entity": "Ministerio Y",
    "item": "Impresora",
    "quantity": 5,
    "unitPrice": 4000.00,
    "date": "2025-12-02T10:00:00Z",
    "supplier": "Proveedor S.A."
  }'
```

#### 6. Activar/Desactivar adquisición

`PATCH /api/v1/procurements/{procurementId}/status/activate`
`PATCH /api/v1/procurements/{procurementId}/status/deactivate`

**Curl:**

```bash
curl -X PATCH http://localhost:5115/api/v1/procurements/7a3bd86d-dfeb-4c23-ba5a-d397ea4ab119/status/activate
curl -X PATCH http://localhost:5115/api/v1/procurements/7a3bd86d-dfeb-4c23-ba5a-d397ea4ab119/status/deactivate
```

---

## Documentación Swagger

La API expone documentación interactiva Swagger en:

```
http://localhost:5115/swagger
```

---

## Colección de Postman

La colección de Postman para probar los endpoints está disponible en:

```
https://www.postman.com/gold-astronaut-46512/adres/collection/rutzaxv/adres?action=share&creator=15039240
```

---

## Docker

### 1. Build de la imagen

```bash
docker build -t adres-procurement .
```

### 2. Ejecutar el contenedor

```bash
docker run -p 8080:8080 \
  -e DB_CONNECTION_STRING="Server=db;Database=test;User Id=user;Password=pass;" \
  adres-procurement
```

La API estará disponible en `http://localhost:8080`.

---

## Contacto

- Autor: Leidy Nataly Ocampo
- Email: [leidyocampo1821@gmail.com]
- Github: [https://github.com/natalyoc12]
- LinkedIn: [https://www.linkedin.com/in/leidy-nataly/]
