# Guía Rápida: Debug vs Release

## 🔍 Comparación Visual

### Modo DEBUG (Desarrollo)
```
┌─────────────────────────────────────────────────────────┐
│  ¿Quién es Jesús?                                       │
├─────────────────────────────────────────────────────────┤
│                                                          │
│  Artículos sobre la Divinidad de Cristo                 │
│                                                          │
│  [⚠️ Modo Debug] [👁️ Modo Producción] [➕ Nuevo Artículo] │
│                                                          │
│  ⚠️ Modo Debug: Estás viendo todos los artículos        │
│                                                          │
│  ┌──────────────────┐  ┌──────────────────┐            │
│  │ Artículo 1       │  │ ⚠️ PRIVADO       │            │
│  │ [Público]        │  │ Artículo 2       │            │
│  │ Descripción...   │  │ [Solo Debug]     │            │
│  │ [Leer más →]     │  │ Descripción...   │            │
│  └──────────────────┘  │ [Leer más →]     │            │
│                        └──────────────────┘            │
│                                                          │
│  • Puedes ver TODOS los artículos                       │
│  • Artículos privados tienen badge amarillo 👁️‍🗨️         │
│  • Puedes crear nuevos artículos                        │
│  • Puedes editar cualquier artículo                     │
│  • Botón "Modo Producción" para simular Release        │
└─────────────────────────────────────────────────────────┘
```

### Modo RELEASE (Producción)
```
┌─────────────────────────────────────────────────────────┐
│  ¿Quién es Jesús?                                       │
├─────────────────────────────────────────────────────────┤
│                                                          │
│  Artículos sobre la Divinidad de Cristo                 │
│                                                          │
│  ┌──────────────────┐  ┌──────────────────┐            │
│  │ Artículo 1       │  │ Artículo 3       │            │
│  │                  │  │                  │            │
│  │ Descripción...   │  │ Descripción...   │            │
│  │ [Leer más →]     │  │ [Leer más →]     │            │
│  └──────────────────┘  └──────────────────┘            │
│                                                          │
│  • Solo artículos PÚBLICOS                              │
│  • Sin badges de estado                                 │
│  • Sin botón "Nuevo Artículo"                          │
│  • Sin botón "Editar"                                  │
│  • Interfaz limpia para lectores                        │
└─────────────────────────────────────────────────────────┘
```

## 🎯 Diferencias Clave

| Característica | 🔧 DEBUG | 🚀 RELEASE |
|----------------|----------|------------|
| Crear artículos | ✅ Sí | ❌ No |
| Editar artículos | ✅ Sí | ❌ No |
| Ver artículos privados | ✅ Sí | ❌ No |
| Botón "Modo Producción" | ✅ Sí | ❌ No |
| Indicadores de privacidad | ✅ Sí | ❌ No |
| Alertas de debug | ✅ Sí | ❌ No |
| Acceso a `/articulos/crear` | ✅ Sí | ❌ Redirige |
| Acceso a `/articulos/editar/{id}` | ✅ Sí | ❌ Redirige |

## 🎨 Indicadores Visuales en Debug

### 1. Badge de Artículo Privado
```
┌──────────────────────────────┐
│ Mi Artículo      [👁️‍🗨️ Privado] │
│ 15/01/2024                    │
│ Descripción del artículo...   │
│ [Leer más →]                  │
└──────────────────────────────┘
```

### 2. Alerta de Modo Debug
```
┌────────────────────────────────────────────────────┐
│ ⚠️ Modo Debug: Estás viendo todos los artículos   │
│ Usa el botón "Modo Producción" para ver como se   │
│ vería en release.                          [✖]    │
└────────────────────────────────────────────────────┘
```

### 3. Vista de Artículo Privado
```
┌────────────────────────────────────────────────────┐
│ ⚠️ Artículo Privado: Este artículo no es visible  │
│ en modo producción.                                │
└────────────────────────────────────────────────────┘

Mi Artículo Privado          [👁️‍🗨️ Privado]
```

## 🔄 Flujo de Trabajo

### Durante Desarrollo (Debug)
1. Ejecuta: `dotnet run`
2. Crea artículos (botón "Nuevo Artículo")
3. Marca como **Privado** los borradores
4. Marca como **Público** los listos para publicar
5. Prueba con botón "Modo Producción"
6. Verifica que solo se vean los públicos

### Para Publicar (Release)
1. Verifica que tus artículos públicos estén correctos
2. Compila: `dotnet build -c Release`
3. Publica: `dotnet publish -c Release -o ./publish`
4. Despliega la carpeta `./publish`

## 🎮 Probando "Modo Producción" en Debug

### Antes de hacer clic:
- ✅ Ves todos los artículos
- ✅ Ves badges "Privado"
- ✅ Ves botón "Nuevo Artículo"
- ✅ Ves botón "Editar"

### Después de hacer clic en "Modo Producción":
- ❌ Solo ves artículos públicos
- ❌ No hay badges "Privado"
- ❌ No hay botón "Nuevo Artículo"
- ❌ No hay botón "Editar"
- ✅ Ves exactamente cómo se vería en Release

### Para volver a Debug:
- Haz clic en "Modo Debug" (el mismo botón)

## 🚨 Recordatorios Importantes

### ⚠️ NUNCA publiques con modo Debug
```bash
# ❌ INCORRECTO
dotnet publish

# ✅ CORRECTO
dotnet publish -c Release
```

### ⚠️ Verifica artículos antes de publicar
- Revisa que `esPublico: true` solo esté en artículos terminados
- Usa "Modo Producción" para verificar la apariencia final
- Los artículos con `esPublico: false` NO serán visibles en Release

### ⚠️ Rutas protegidas en Release
Si alguien intenta acceder a:
- `/articulos/crear` → Redirige a `/articulos`
- `/articulos/editar/{id}` → Redirige a `/articulos`

## 💡 Consejos

1. **Usa artículos privados** para borradores y trabajo en progreso
2. **Prueba con "Modo Producción"** antes de cada despliegue
3. **Mantén separado** el contenido público del privado
4. **Documenta** qué artículos planeas hacer públicos
5. **Haz backup** de localStorage periódicamente (exporta el JSON)

---

**Recuerda**: El modo Debug es tu espacio de trabajo completo, y Release es la versión pública y limpia para tus lectores.
