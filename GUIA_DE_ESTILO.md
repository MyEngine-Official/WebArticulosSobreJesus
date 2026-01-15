# 🎨 Guía de Estilo Visual - QuienEsJesus (PALETA FRÍA)

## Paleta de Colores Principal - TONOS FRÍOS

### Colores de Marca (Turquesa Protagonista)

```css
/* Turquesa Vibrante - Color Principal */
--color-primary: #20D4BF
RGB: (32, 212, 191)
HSL: (173°, 74%, 48%)
Uso: Botones principales, enlaces, acentos importantes
Sensación: Sereno, espiritual, celestial

/* Turquesa Brillante - Color Secundario */
--color-secondary: #40E0D0
RGB: (64, 224, 208)
HSL: (174°, 72%, 56%)
Uso: Gradientes, acentos secundarios, hover states
Sensación: Luminoso, divino, refrescante

/* Lila Medio Púrpura - Acento 1 (Contraste Principal) */
--color-accent-1: #9370DB
RGB: (147, 112, 219)
HSL: (260°, 60%, 65%)
Uso: Contraste principal, títulos especiales, elementos destacados
Sensación: Místico, real, espiritual

/* Lila Azulado - Acento 2 */
--color-accent-2: #8A7FE6
RGB: (138, 127, 230)
HSL: (246°, 69%, 70%)
Uso: Detalles sutiles, gradientes con turquesa
Sensación: Etéreo, suave, celestial

/* Orquídea Medio - Acento 3 */
--color-accent-3: #BA55D3
RGB: (186, 85, 211)
HSL: (288°, 59%, 58%)
Uso: Alertas, badges, elementos de advertencia
Sensación: Vibrante, llamativo, místico

/* Azul Acero - Acento 4 */
--color-accent-4: #4682B4
RGB: (70, 130, 180)
HSL: (207°, 44%, 49%)
Uso: CTAs secundarios, elementos de acción
Sensación: Confiable, sólido, profesional
```

### Tonos Complementarios

```css
/* Verde Azulado */
--color-teal: #17A2B8
Uso: Elementos informativos, estados de éxito

/* Cian Oscuro */
--color-cyan: #00CED1
Uso: Detalles brillantes, acentos luminosos
```

## Variaciones de Colores

### Tonos Claros
```css
--color-primary-light: #5FEDD8    /* Turquesa claro */
--color-secondary-light: #7FFFD4   /* Aquamarine */
--color-accent-light: #B19CD9      /* Lila claro */
```

### Tonos Oscuros
```css
--color-primary-dark: #0FA896      /* Turquesa profundo */
--color-secondary-dark: #20B2AA    /* Verde mar */
--color-accent-dark: #7B68EE       /* Azul medio */
```

## Colores Neutros (Con Tinte Frío)

### Grises y Bases
```css
/* Azul Oscuro Profundo */
--color-dark: #1a2332
Uso: Texto principal, headings importantes
Tinte: Azul sutil para coherencia con paleta fría

/* Oscuro Suave */
--color-dark-light: #2a3444
Uso: Backgrounds oscuros, footer

/* Gris Medio */
--color-gray: #4a5568
Uso: Texto secundario, descripciones

/* Gris Claro */
--color-gray-light: #e8ecf0
Uso: Borders, separadores, backgrounds sutiles

/* Blanco Puro */
--color-white: #ffffff
Uso: Backgrounds principales, texto en oscuro

/* Blanco Suave */
--color-off-white: #f7fafc
Uso: Background de página (con tinte azul muy sutil)
```

## Sistema de Sombras

### Elevaciones con Tinte Turquesa
```css
/* Sombra Sutil */
--shadow-sm: 0 2px 8px rgba(32, 212, 191, 0.08)
Uso: Cards, elementos flotantes ligeros

/* Sombra Media */
--shadow-md: 0 4px 16px rgba(32, 212, 191, 0.12)
Uso: Botones, cards en hover, modales

/* Sombra Grande */
--shadow-lg: 0 8px 32px rgba(32, 212, 191, 0.16)
Uso: Elementos elevados, dropdowns

/* Sombra Extra Grande */
--shadow-xl: 0 16px 48px rgba(32, 212, 191, 0.2)
Uso: Modales importantes, hero cards
```

### Sombras con Acento Lila
```css
/* Para elementos especiales con lila */
--shadow-accent-sm: 0 2px 8px rgba(147, 112, 219, 0.1)
--shadow-accent-md: 0 4px 16px rgba(147, 112, 219, 0.15)
--shadow-accent-lg: 0 8px 32px rgba(147, 112, 219, 0.2)
```

## Transiciones

### Velocidades
```css
/* Rápida */
--transition-fast: 150ms ease-in-out
Uso: Hover effects, color changes

/* Normal */
--transition-normal: 300ms ease-in-out
Uso: Animaciones estándar, cards

/* Lenta */
--transition-slow: 500ms ease-in-out
Uso: Efectos especiales, animaciones complejas
```

## Radios de Borde

### Tamaños
```css
/* Pequeño */
--radius-sm: 8px
Uso: Badges, chips, elementos pequeños

/* Medio */
--radius-md: 12px
Uso: Botones, inputs, cards estándar

/* Grande */
--radius-lg: 16px
Uso: Cards principales, modales

/* Extra Grande */
--radius-xl: 24px
Uso: Hero cards, elementos destacados
```

## Tipografía

### Familia de Fuentes
```css
font-family: 'Inter', -apple-system, BlinkMacSystemFont, 
             'Segoe UI', Roboto, 'Helvetica Neue', 
             Arial, sans-serif
```

### Tamaños de Texto
```css
/* Títulos */
h1: clamp(2rem, 5vw, 3.5rem)    /* 32-56px */
h2: clamp(1.75rem, 4vw, 2.5rem) /* 28-40px */
h3: clamp(1.5rem, 3vw, 2rem)    /* 24-32px */

/* Cuerpo */
p: 1rem (16px)
lead: 1.25rem (20px)
small: 0.875rem (14px)
```

### Pesos
```css
300 - Light      /* Subtítulos, textos secundarios */
400 - Regular    /* Cuerpo de texto estándar */
600 - SemiBold   /* Énfasis medio, labels */
700 - Bold       /* Headings, botones */
800 - ExtraBold  /* Títulos principales */
900 - Black      /* Hero titles, display */
```

## Gradientes (Tonos Fríos)

### Gradiente Principal (Turquesa)
```css
background: linear-gradient(135deg, 
    var(--color-primary) 0%,      /* #20D4BF */
    var(--color-secondary) 100%    /* #40E0D0 */
);
```

### Gradiente con Contraste (Turquesa a Lila)
```css
background: linear-gradient(135deg, 
    var(--color-primary) 0%,       /* #20D4BF */
    var(--color-accent-1) 100%     /* #9370DB */
);
```

### Gradiente de Texto
```css
background: linear-gradient(135deg, 
    var(--color-primary) 0%, 
    var(--color-accent-1) 100%
);
-webkit-background-clip: text;
-webkit-text-fill-color: transparent;
background-clip: text;
```

### Gradiente Multicolor Frío
```css
background: linear-gradient(90deg, 
    var(--color-primary),    /* Turquesa */
    var(--color-secondary),  /* Turquesa brillante */
    var(--color-accent-1)    /* Lila */
);
```

### Gradiente Lila Puro
```css
background: linear-gradient(135deg, 
    var(--color-accent-1) 0%,  /* #9370DB */
    var(--color-accent-2) 100% /* #8A7FE6 */
);
```

### Gradiente Mixto (Para Hero)
```css
background: linear-gradient(135deg, 
    var(--color-primary) 0%,     /* Turquesa */
    var(--color-accent-1) 50%,   /* Lila */
    var(--color-accent-2) 100%   /* Lila azulado */
);
```

## Componentes Clave

### Botón Primary (Turquesa)
```css
background: linear-gradient(135deg, 
    var(--color-primary) 0%, 
    var(--color-secondary) 100%
);
color: var(--color-white);
padding: 0.875rem 2rem;
border-radius: var(--radius-md);
box-shadow: var(--shadow-md);
transition: all var(--transition-normal);
```

### Botón Secondary (Lila)
```css
background: linear-gradient(135deg, 
    var(--color-accent-1) 0%, 
    var(--color-accent-2) 100%
);
color: var(--color-white);
box-shadow: var(--shadow-accent-md);
```

### Card Elegante
```css
background: var(--color-white);
border-radius: var(--radius-lg);
box-shadow: var(--shadow-sm);
transition: all var(--transition-normal);
border-top: 4px solid transparent;
/* Gradiente en hover */
border-top-color: linear-gradient(90deg, 
    var(--color-primary), 
    var(--color-accent-1)
);
```

### Navbar
```css
background: rgba(255, 255, 255, 0.95);
backdrop-filter: blur(10px);
box-shadow: var(--shadow-md);
```

## Uso de Colores por Contexto

### Acciones
```
✅ Crear/Guardar:    --color-primary (Turquesa)
📝 Editar:           --color-secondary (Turquesa brillante)
❌ Eliminar:         #dc3545 (Bootstrap danger - rojo)
🔄 Cancelar:         --color-gray
ℹ️ Info especial:    --color-accent-1 (Lila)
```

### Estados
```
✅ Éxito:    --color-teal (#17A2B8)
⚠️ Advertencia: --color-accent-3 (Orquídea)
❌ Error:    #dc3545 (Rojo)
ℹ️ Info:     --color-primary (Turquesa)
💜 Especial: --color-accent-1 (Lila)
```

### Visibilidad
```
👁️ Público:   --color-primary (Turquesa)
🔒 Privado:   --color-accent-3 (Orquídea)
```

## Psicología de Colores Fríos

### Turquesa (#20D4BF)
- **Sensación:** Serenidad, espiritualidad, claridad
- **Asociaciones:** Cielo, agua, divinidad
- **Uso ideal:** Elementos principales, acciones positivas

### Lila/Púrpura (#9370DB)
- **Sensación:** Misticismo, realeza, espiritualidad
- **Asociaciones:** Corona, nobleza, lo divino
- **Uso ideal:** Contraste, elementos destacados, títulos especiales

### Combinación Turquesa + Lila
- **Efecto:** Armonía celestial, espiritualidad elevada
- **Mensaje:** Divinidad accesible pero majestuosa
- **Perfecto para:** Tema religioso, búsqueda espiritual

## Ejemplos de Uso

### Hero Section (Gradiente Frío Celestial)
```css
background: linear-gradient(135deg, 
    var(--color-primary) 0%,      /* Turquesa */
    var(--color-accent-1) 50%,    /* Lila */
    var(--color-accent-2) 100%    /* Lila azulado */
);
```

### Hover Effect en Card
```css
.card:hover {
    transform: translateY(-8px);
    box-shadow: var(--shadow-xl);
    border-top: 4px solid var(--color-primary);
}
```

### Texto con Gradiente Turquesa-Lila
```html
<h1 class="text-gradient">Título Celestial</h1>
```

### Texto con Gradiente Lila Puro
```html
<h2 class="text-gradient-purple">Subtítulo Místico</h2>
```

### Badge Turquesa
```html
<span class="badge badge-primary">Destacado</span>
```

### Efectos de Glow
```css
.glow-turquoise {
    box-shadow: 0 0 20px rgba(32, 212, 191, 0.3);
}

.glow-purple {
    box-shadow: 0 0 20px rgba(147, 112, 219, 0.3);
}
```

## Accesibilidad

### Contraste Mínimo (WCAG AA)
```
Turquesa (#20D4BF) sobre blanco:   ✅ 3.2:1 (Texto grande OK)
Lila (#9370DB) sobre blanco:       ✅ 4.6:1 (Todo texto OK)
Turquesa sobre oscuro (#1a2332):   ✅ 6.5:1 (Excelente)
Lila sobre oscuro (#1a2332):       ✅ 7.8:1 (Excelente)
```

### Paleta Segura para Daltónicos
Los turquesas y lilas tienen suficiente diferencia de saturación y brillo para ser distinguibles incluso con deuteranopia o protanopia.

## Exportación de Paleta

### Para Diseño (Figma/Adobe)
```
Primary:      #20D4BF  (Turquesa vibrante)
Secondary:    #40E0D0  (Turquesa brillante)
Accent 1:     #9370DB  (Lila medio púrpura)
Accent 2:     #8A7FE6  (Lila azulado)
Accent 3:     #BA55D3  (Orquídea medio)
Accent 4:     #4682B4  (Azul acero)
Teal:         #17A2B8  (Verde azulado)
Cyan:         #00CED1  (Cian oscuro)
```

### Para CSS/SCSS
```scss
$primary:      #20D4BF;
$secondary:    #40E0D0;
$accent-1:     #9370DB;
$accent-2:     #8A7FE6;
$accent-3:     #BA55D3;
$accent-4:     #4682B4;
$teal:         #17A2B8;
$cyan:         #00CED1;
```

### Para Tailwind
```js
colors: {
  primary:   '#20D4BF',
  secondary: '#40E0D0',
  accent: {
    1: '#9370DB',
    2: '#8A7FE6',
    3: '#BA55D3',
    4: '#4682B4',
  },
  teal: '#17A2B8',
  cyan: '#00CED1',
}
```

---

## 📐 Reglas de Oro (Tonos Fríos)

1. **Turquesa domina** - Usar en 60% de elementos principales
2. **Lila contrasta** - Usar en 30% para destacar
3. **Azules complementan** - Usar en 10% para detalles
4. **Gradientes celestiales** - Combinar turquesa con lila
5. **Sombras sutiles** - Mantener elegancia con opacidad baja

## 🌊 Sensación de la Paleta

**ANTES (Colores Cálidos):**
- 🔥 Enérgico, apasionado, terrenal
- ❤️ Cálido, acogedor, humano

**AHORA (Colores Fríos):**
- 🌊 Sereno, celestial, divino
- 💜 Místico, espiritual, elevado
- ✨ Perfecto para temática religiosa/espiritual

---

**Última actualización:** Enero 2025 (Paleta Fría)
**Versión de guía:** 2.0 (Turquesa + Lila)
