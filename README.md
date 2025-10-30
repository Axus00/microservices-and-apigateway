# Microservices and API Gateway (Proof of Concept)

Proyecto POC sobre microservicios y aplicación de gateway de API como balanceador de carga para la distribución de peticiones.

## 📚 Estructura del proyecto

├── ApiGateway/ # Proyecto del gateway de API que dirige las peticiones hacia los microservicios
├── Users/ # Microservicio de usuarios (servicio independiente)
├── .env.example # Archivo de ejemplo para variables de entorno
├── Microservices.sln # Solución principal (posiblemente para Visual Studio / .NET)
├── .gitignore
└── README.md


## 🚀 Tecnologías usadas

- Lenguaje / framework principal: **C#** (todo el código está en C#).  
- Arquitectura de microservicios + gateway (API Gateway) para el enrutamiento y balanceo de carga entre servicios.

## 🔧 Configuración local

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Axus00/microservices-and-apigateway.git

2. Copia el archivo de entorno y personalízalo:
   cp .env.example .env
3. Luego edita .env con tus credenciales, puertos, cadenas de conexión, etc.

4. Abre la solución (Microservices.sln) en tu IDE (por ejemplo Visual Studio).

5. Restaura dependencias, construye la solución y ejecuta los proyectos de microservicios y del API Gateway.

🔁 Flujo de peticiones

El usuario hace solicitudes al API Gateway, que actúa como punto de entrada.

El gateway enruta cada petición al microservicio correspondiente (por ejemplo, al servicio de usuarios).

Los microservicios manejan la lógica de negocio, base de datos, etc., devolviendo respuestas al gateway, que las reenvía al cliente.

✅ Buenas prácticas

Mantener cada microservicio independiente, con su propia base de datos y lógica aislada.

Usar variables de entorno para configuración sensible y parámetros de despliegue.

Versionar cambios en cada microservicio separadamente para facilitar mantenimiento.

🔧 Cómo contribuir

1. Crea un branch para tu feature o fix:

git checkout -b feature/mi-feature

2. Realiza tus cambios, asegúrate de que todo compila y se prueban los microservicios.

3. Haz commit y push:

`git commit -am "Añade nueva funcionalidad a Users service"`
`git push origin feature/mi-feature`

4. Abre un pull request hacia main.

🤝 Licencia

Este proyecto podría usar una licencia abierta (MIT, Apache, etc.). Asegúrate de añadir un archivo LICENSE si deseas compartirlo públicamente.

ℹ️ Notas adicionales

Puedes expandir este POC añadiendo más microservicios (por ejemplo, productos, órdenes, autenticación).

También se podría incorporar autenticación / autorización en el gateway (JWT, OAuth).

Ideal para experimentar con contenedores (Docker / Kubernetes) y despliegue en la nube.

```bash
---

Si quieres, puedo armarte un README ya completo con tus rutas reales, endpoints documentados (basado en tu código), ejemplos de peticiones (curl / Postman), y un diagrama de arquitectura en ASCII / MD para que lo puedas pegar directo en tu repo. ¿Te lo genero completo?
::contentReference[oaicite:2]{index=2}
