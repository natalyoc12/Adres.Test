#!/bin/bash
set -e

# Mensaje de inicio
clear
echo "==============================="
echo "  Adres Test Setup Script"
echo "==============================="

# Levantar servicios con Docker Compose
echo "[1/1] Levantando servicios con Docker Compose..."
docker compose -p adrestest up -d --build
echo "Servicios levantados correctamente."

# Espera con puntos animados
echo -n "Abriendo la aplicación en el navegador."
for i in {1..8}; do
  sleep 1
  echo -n "."
done
echo ""

# Abrir el navegador en la URL del API
if which xdg-open > /dev/null; then
  xdg-open "http://localhost/"
elif which open > /dev/null; then
  open "http://localhost/"
else
  echo "Por favor, abre tu navegador y visita http://localhost/"
fi

# Mensaje final
echo "====================================="
echo "  ¡Todo listo!"
echo "  API disponible en: http://localhost:8080"
echo "  Swagger: http://localhost:8080/swagger"
echo "  Frontend disponible en: http://localhost"
echo "  Base de datos SQL Server en el puerto 1433"
echo "  Usuario SQL Server: sa"
echo "  Password: Your_strong_password_123"
echo "====================================="
