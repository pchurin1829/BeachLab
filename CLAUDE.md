# CLAUDE.md

# Proyecto

BeachLab

Laboratorio de conocimiento para Beach Volleyball.

Su objetivo es importar información de torneos, almacenar datos, generar análisis técnicos, tácticos y estadísticos, y transformar el conocimiento del entrenador en herramientas reutilizables.

BeachLab es un proyecto complementario de ODU.

El conocimiento generado aquí podrá incorporarse posteriormente a ODU cuando esté suficientemente validado.

---

# Inicio obligatorio de cada sesión

Antes de comenzar cualquier tarea:

1. Leer CLAUDE.md.
2. Leer ROADMAP.md.
3. Leer PROJECT_STATUS.md.
4. Verificar que ROADMAP y PROJECT_STATUS sean consistentes.
5. Ejecutar `git status`.
6. Identificar la etapa actual.
7. Continuar únicamente con la siguiente tarea pendiente.

No asumir que una tarea quedó terminada sin verificar el código y el repositorio.

---

# Objetivos

BeachLab debe permitir:

- importar torneos;
- almacenar información histórica;
- analizar jugadores y equipos;
- estudiar rendimiento;
- generar conocimiento deportivo;
- validar nuevas ideas antes de incorporarlas a ODU.

---

# Arquitectura

Tecnologías

- C#
- .NET 8
- Windows Forms
- PostgreSQL
- ClosedXML

Arquitectura

UI

↓

Core

↓

Data

↓

PostgreSQL

Toda la lógica debe permanecer dentro del Core.

La interfaz únicamente presenta información.

---

# Reglas No Negociables

- Mantener una arquitectura simple.
- No agregar complejidad antes de ser necesaria.
- No reorganizar el proyecto sin autorización.
- No realizar refactorizaciones fuera del alcance solicitado.
- No crear documentación innecesaria.
- No realizar commits sin autorización.
- Mantener siempre el proyecto compilando.
- No reabrir decisiones ya aprobadas salvo que exista un problema real.

---

# Filosofía de Trabajo

BeachLab es un laboratorio.

Aquí pueden desarrollarse ideas experimentales.

Sin embargo:

- primero validar;
- luego estabilizar;
- finalmente integrar en ODU.

No desarrollar funcionalidades complejas directamente en ODU sin haberlas validado previamente cuando puedan probarse en BeachLab.

Priorizar terminar antes que perfeccionar continuamente.

---

# Base de Datos

- PostgreSQL.
- Mantener compatibilidad entre versiones.
- Evitar modificaciones innecesarias del modelo.

---

# Git

- Commits pequeños.
- Una funcionalidad = un commit.
- Compilar antes de cada commit.
- Mantener sincronizado origin/main.

---

# Documentación

El proyecto utiliza únicamente estos documentos como referencia principal:

- CLAUDE.md
- ROADMAP.md
- PROJECT_STATUS.md

No generar documentación adicional salvo que aporte valor real.

---

# Cierre de cada sesión

Antes de finalizar:

1. Actualizar PROJECT_STATUS.md.
2. Verificar si corresponde actualizar ROADMAP.md.
3. Actualizar CLAUDE.md únicamente si cambió una regla permanente.
4. Ejecutar git status.
5. Informar el estado final del proyecto.