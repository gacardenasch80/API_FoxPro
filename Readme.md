# 📚 Documentación Técnica: API FoxPro Integration

## 🛠 Descripción General
Este proyecto es una solución de integración desarrollada en **C# (.NET Framework 4.7.2)**. Su función principal es servir como una capa de servicios para interactuar con bases de datos **Visual FoxPro** (archivos `.dbf`). 

Es ideal para modernizar sistemas antiguos, permitiendo que aplicaciones nuevas consuman datos de bases de datos legadas de forma segura y estructurada.

## 📂 Estructura de la Solución

### 1. MedisoftCore (Biblioteca de Clases)
Es el núcleo del sistema. Contiene:
- **Entities:** Clases que representan las tablas de FoxPro (Pacientes, Citas, Facturas, Médicos).
- **Services:** Lógica de negocio para consultar y manipular los datos.
- **QueryFilters:** Clases especializadas para aplicar criterios de búsqueda (filtros) a las consultas.
- **Tecnologías:** - `Dapper`: Para el mapeo objeto-relacional (ORM) ligero.
  - `System.Data.OleDb`: Para la conexión física con FoxPro.

### 2. MedisoftFE (Capa de Ejecución)
- Proyecto de consola utilizado para ejecutar, testear y demostrar la funcionalidad de los servicios del Core.

## 📋 Funcionalidades Identificadas
El sistema está diseñado para un entorno médico/clínico y gestiona:
- **Gestión de Citas (`Adcitas`):** Consulta y seguimiento de agendas.
- **Maestro de Pacientes (`Adpaciente`):** Acceso a información demográfica y clínica.
- **Facturación (`Fafactura`):** Recuperación de registros de ventas y cobros.
- **Servicios Médicos (`Faservicio`):** Detalle de procedimientos y servicios prestados.
- **Consecutivos:** Control de numeración automática para el sistema clínico.

## 🚀 Cómo funciona la conexión
El proyecto utiliza una cadena de conexión OleDb configurada para el proveedor `VFPOLEDB.1`. 
1. El servicio recibe una solicitud de datos.
2. Se aplica un `QueryFilter` si es necesario.
3. Dapper ejecuta la consulta SQL sobre los archivos `.dbf`.
4. Los resultados se transforman en objetos C# listos para ser usados en cualquier frontend moderno o API REST.

## 📌 Requisitos
- Visual Studio 2019 o superior.
- Proveedor **VFPOLEDB** instalado en el servidor/máquina de desarrollo para permitir la comunicación con los archivos de FoxPro.