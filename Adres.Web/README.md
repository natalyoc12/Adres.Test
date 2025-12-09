# AdresWeb

Proyecto frontend desarrollado en **Angular 19** y preparado para despliegue con Docker.

---

## Tabla de Contenidos

- [Descripción](#descripción)
- [Estructura](#estructura)
- [Instalación y ejecución](#instalación-y-ejecución)
- [Despliegue con Docker](#despliegue-con-docker)
- [Scripts útiles](#scripts-útiles)
- [Testing](#testing)
- [Contacto](#contacto)

---

## Descripción

Esta aplicación permite visualizar y gestionar adquisiciones, consumiendo la API backend del proyecto. Incluye componentes para filtros, paginación, listado y detalles de adquisiciones.

---

## Estructura

```
Adres.Web/
├── src/                  # Código fuente principal
│   ├── app/              # Componentes, páginas y rutas
│   ├── domain/           # Modelos y casos de uso
│   ├── data/             # Repositorios y entidades
│   └── presentation/     # Componentes visuales
├── public/               # Archivos estáticos
├── Dockerfile            # Imagen Docker multistage
├── angular.json          # Configuración Angular
├── package.json          # Dependencias y scripts
└── README.md             # Documentación
```

---

## Instalación y ejecución local

1. Clona el repositorio:

   ```bash
   git clone https://github.com/natalyoc12/Adres.Test.git
   cd Adres.Test/Adres.Web
   ```

2. Instala dependencias:

   ```bash
   npm install
   ```

3. Ejecuta el servidor de desarrollo:

   ```bash
   npm start
   # o
   ng serve
   ```

4. Abre tu navegador en [http://localhost:4200](http://localhost:4200)

---

## Despliegue con Docker

Construye y corre la imagen Docker:

```bash
docker build -t adres-web .
docker run -p 80:80 adres-web
```

Esto iniciará el servicio `web` (Angular) en el puerto **80**. Accede a la app en [http://localhost](http://localhost:80).

---

## Scripts útiles

- `npm start` / `ng serve`: Inicia el servidor de desarrollo.
- `npm run build`: Compila la app para producción en `dist/`.
- `npm test`: Ejecuta los tests unitarios con Karma.

---

## Testing

Para ejecutar los tests unitarios:

```bash
npm test
```

Puedes agregar más tests en la carpeta `src/app` siguiendo las convenciones de Angular.

---

## Notas técnicas

- El proyecto está preparado para producción usando Nginx como servidor estático (ver Dockerfile).
- El consumo de la API está centralizado en los repositorios dentro de `src/data`.
- El diseño es responsivo y utiliza Tailwind CSS y DaisyUI para estilos.
- Puedes modificar rutas y endpoints en los archivos de configuración y servicios.

---

## Contacto

- Autor: Leidy Nataly Ocampo
- Email: [[leidyocampo1821@gmail.com](mailto:leidyocampo1821@gmail.com)]
- Github: [https://github.com/natalyoc12]
- LinkedIn: [https://www.linkedin.com/in/leidy-nataly/]
