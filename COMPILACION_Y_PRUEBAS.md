# 🚀 Guía de Compilación y Pruebas - QuienEsJesus

## 📋 Pre-requisitos

- ✅ .NET 10.0 SDK instalado
- ✅ Visual Studio 2022 o VS Code
- ✅ Navegador moderno (Chrome, Edge, Firefox)

## 🔨 Compilación

### Modo Debug (Desarrollo)

```bash
# Limpiar build anterior
dotnet clean

# Restaurar paquetes
dotnet restore

# Compilar
dotnet build -c Debug

# Ejecutar
dotnet run
```

**Características activas:**
- ✅ Editor de artículos
- ✅ Artículos privados visibles
- ✅ Toggle modo producción
- ✅ Botones de edición
- ✅ Badges de estado

### Modo Release (Producción)

```bash
# Limpiar
dotnet clean

# Compilar para producción
dotnet build -c Release

# Publicar
dotnet publish -c Release -o ./publish

# El contenido estará en ./publish/wwwroot
```

**Características activas:**
- ✅ Solo artículos públicos
- ❌ Editor oculto
- ❌ Controles de desarrollo ocultos
- ✅ Performance optimizada

## 🧪 Pruebas

### 1. Verificar Compilación Sin Errores

```bash
# Debe completarse sin errores
dotnet build -c Debug
dotnet build -c Release
```

**Resultado esperado:**
```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

### 2. Probar Modo Debug

```bash
dotnet run
```

**Navegador abrirá en:** `https://localhost:5001` o `http://localhost:5000`

**Verificar:**
- [ ] Página de inicio se carga correctamente
- [ ] Hero section con gradientes visibles
- [ ] Navegación a "/articulos" funciona
- [ ] Botón "Nuevo Artículo" visible
- [ ] Toggle "Modo Producción" visible
- [ ] Puede crear un artículo
- [ ] Vista previa de Markdown funciona
- [ ] Puede editar artículos existentes
- [ ] Artículos privados tienen badge "Privado"

### 3. Probar Toggle Modo Producción (Debug)

En `/articulos`:

1. Click en "Modo Producción"
   - [ ] Botón "Nuevo Artículo" desaparece
   - [ ] Artículos privados desaparecen
   - [ ] Alert de modo debug desaparece

2. Click de nuevo en "Modo Debug"
   - [ ] Todo vuelve a aparecer

### 4. Simular Modo Release

```bash
# Compilar en Release
dotnet build -c Release

# Ejecutar (requiere servidor web para wwwroot)
cd bin/Release/net10.0/wwwroot
# Usar Live Server o similar
```

**Verificar:**
- [ ] Solo artículos públicos visibles
- [ ] Ruta `/articulos/crear` redirige a `/articulos`
- [ ] Ruta `/articulos/editar/{id}` redirige a `/articulos`
- [ ] No hay botones de edición
- [ ] No hay toggle de modo
- [ ] Artículos privados inaccesibles

### 5. Verificar Estilos

**En cualquier página:**
- [ ] Paleta de colores correcta (rojos/naranjas)
- [ ] Navbar sticky funciona
- [ ] Hover effects en botones
- [ ] Gradientes visibles
- [ ] Animaciones suaves
- [ ] Sombras elegantes
- [ ] Responsive en móvil

**Página Home:**
- [ ] Hero full-screen
- [ ] Wave effect entre secciones
- [ ] Cards de temas con hover
- [ ] Footer elegante

**Página Artículos:**
- [ ] Cards con efecto elevación al hover
- [ ] Gradientes en títulos
- [ ] Breadcrumbs funcionando

### 6. Verificar Navegación

```
Rutas a probar:
✅ /               → Home
✅ /articulos      → Lista de artículos
✅ /articulos/{id} → Vista de artículo
```

**Solo en Debug:**
```
✅ /articulos/crear       → Editor nuevo artículo
✅ /articulos/editar/{id} → Editor editar artículo
```

**En Release (deben redirigir):**
```
❌ /articulos/crear       → Redirige a /articulos
❌ /articulos/editar/{id} → Redirige a /articulos
```

## 🐛 Solución de Problemas

### Error: "No se puede encontrar BuildConfiguration"

**Causa:** Archivo no compilado o namespace incorrecto

**Solución:**
```bash
dotnet clean
dotnet restore
dotnet build
```

### Error: Estilos no se aplican

**Causa:** CSS no cargado correctamente

**Solución:**
1. Verificar que `wwwroot/css/elegant.css` existe
2. Verificar `index.html` tiene:
   ```html
   <link rel="stylesheet" href="css/elegant.css" />
   ```
3. Hacer hard refresh: `Ctrl + Shift + R`

### Error: LocalStorage no funciona

**Causa:** Navegador bloquea localStorage

**Solución:**
1. Usar protocolo `https://` o `http://`
2. No usar `file://`
3. Verificar `wwwroot/js/storage.js` existe

### Artículos no se guardan

**Causa:** LocalStorage deshabilitado

**Solución:**
1. Verificar configuración del navegador
2. Limpiar caché y cookies
3. Probar en ventana de incógnito

## 📊 Checklist de Calidad

### Funcionalidad
- [ ] Compilación sin errores (Debug)
- [ ] Compilación sin errores (Release)
- [ ] Navegación funciona
- [ ] Editor guarda artículos (Debug)
- [ ] Markdown se renderiza correctamente
- [ ] Toggle modo producción funciona (Debug)
- [ ] Artículos privados ocultos en Release

### Diseño
- [ ] Paleta de colores aplicada
- [ ] Animaciones fluidas
- [ ] Responsive en móvil
- [ ] Navbar sticky funciona
- [ ] Hero section impresionante
- [ ] Cards con efectos hover
- [ ] Footer informativo

### Performance
- [ ] Carga rápida (< 3 segundos)
- [ ] Sin errores en consola
- [ ] Sin warnings importantes
- [ ] Imágenes optimizadas (si hay)

## 🎯 Criterios de Aceptación

Para considerar la aplicación lista:

✅ **Compilación:**
- 0 errores en Debug
- 0 errores en Release
- Builds exitosos en ambos modos

✅ **Funcionalidad:**
- Editor funciona en Debug
- Editor oculto en Release
- Visibilidad de artículos correcta
- Navegación sin errores

✅ **Diseño:**
- Paleta de colores aplicada
- Componentes elegantes
- Responsive perfecto
- Animaciones suaves

✅ **Código:**
- Sin #if en archivos .razor
- Lógica en helpers C#
- Código limpio y documentado
- README actualizado

## 📈 Próximos Pasos

Después de verificar todo:

1. **Commit de cambios:**
```bash
git add .
git commit -m "Refactor: Eliminados #if de Razor + Diseño elegante implementado"
```

2. **Deploy a producción:**
```bash
dotnet publish -c Release -o ./publish
# Subir contenido de ./publish/wwwroot a hosting
```

3. **Documentación:**
- Actualizar documentación de usuario
- Crear guías de contribución
- Documentar API (si aplica)

## ✨ ¡Felicidades!

Si todos los tests pasan, tu aplicación está lista para:
- ✅ Desarrollo activo
- ✅ Testing de usuarios
- ✅ Deploy a producción
- ✅ Showcase en portfolio

---

**Nota:** Guarda este archivo como referencia para futuros builds y troubleshooting.
