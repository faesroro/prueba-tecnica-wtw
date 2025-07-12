# Estrategia DevOps para Despliegue y Automatización

Este documento describe la estrategia propuesta para los despliegues por entorno, manejo de secretos/configuración y mecanismos de rollback automático, como parte de la implementación DevOps del proyecto `SolicitudesApp`.

---

## 1. Despliegues por entorno (Dev, QA, Prod)

Se utilizará **Azure DevOps Pipelines** con definición en YAML para mantener el pipeline como código y versionado dentro del repositorio.

### Enfoque sugerido:

- Cada entorno (Dev, QA, Prod) tendrá su propio **pipeline o stage**, definidos condicionalmente dentro del mismo archivo YAML o en pipelines separados.
- Se manejarán variables por entorno usando:
  - Archivos `.env` o `appsettings.{Environment}.json`
  - Variables de grupo en Azure DevOps (Library)
  - Parámetros en la línea de comandos (`--configuration`, `--environment`, etc.)

### Ejemplo de flujo:

```text
Branch "develop" → despliegue automático a Dev
Branch "qa"      → despliegue automático a QA
Branch "main"    → requiere aprobación para Prod
