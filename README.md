# NoDespiertesDonaRosa

Proyecto Unity de terror y estrategia en primera persona.

## Cómo jugar

- W/A/S/D para moverte  
- Mouse para mirar  
- Esc para pausar

## Pasos iniciales para la construcción del videojuego

A continuación se describen, en orden, los pasos que hemos seguido para poner en marcha el proyecto en Unity y preparar la escena jugable en primera persona.

1. **Instalamos Unity y Visual Studio Community**  
   - Mediante **Unity Hub**, instalamos la versión **2022.3.62f1 (LTS)**.  

2. **Creamos el proyecto en Unity**  
   - En Unity Hub → **New project** → plantillas **3D (Built-In RP)** → nombrar `NoDespiertesDonaRosa` → ubicación deseada → **Create**.  
   - Se generaron las carpetas `Assets/`, `Packages/`, `ProjectSettings/`.

3. **Importamos y organizamos assets**  
   - **Casa** (ALP_Assets – `country house01`):  
     1. Copiamos la carpeta `ALP_Assets` dentro de `Assets/`.  
     2. Arrastramos los prefabs (`House_Green_Prefab`, etc.) a la jerarquía (`Hierarchy`).  
     3. Ajustamos `Transform.position` a `(0, 1, 0)` para asentarla sobre el suelo (`Plane`).  
   - **Audio ambiental** (Horror Atmosphere LITE):  
     1. Importamos la carpeta `Horror Atmosphere LITE/ Ambience/ Atmosphere And Chaos`.  
     2. Creamos un GameObject vacío `AmbientAudio`, añadimos un componente **Audio Source** y asignamos uno de los clips con **Loop** activo.

4. **Importamos controlador en primera persona**  
   - En **Window → Package Manager** → pestaña **My Assets** → buscar **Starter Assets – FirstPerson** → **Download** + **Import**.  
   - En `Assets/StarterAssets/FirstPersonController/Prefabs` arrastramos `PlayerCapsule` a la Jerarquía.  
   - Añadimos un GameObject vacío `Player`, con **Character Controller** y el script `SimpleFPSController` hecho en C#.  
     - En el Inspector, asignamos el campo **Camera Transform** al hijo `PlayerCamera`.  
     - Configuramos **Movement Settings** y **Mouse Look Settings** (sensibilidad, gravedad, velocidad).

5. **Construimos la escena principal**  
   - Creamos un **Plane** en la escena para suelo (GameObject → 3D Object → Plane).  
   - Posicionamos la casa y el `Player` sobre el plane.  
   - Ajustamos el ángulo de la **Directional Light** para simular éxito lumínico.

6. **Decoración del entorno**
   **Texturizar suelo:**
      - Creamos un material Ground_Material.
      - Asignamos la textura de pasto seco al canal Albedo y ajustamos Tiling.
      - Asignamos Ground_Material al Plane.

   **Árboles tenebrosos:**
      - Importamos prefabs de árboles oscuros.
      - Arrastramos y distribuimos varios ejemplares alrededor de la casa para ambientar el escenario.

   **Nubes y cielo:**
      - Importamos un asset de nubes.
      - Arrastramos el prefab de cielo a la escena, lo escalamos y configuramos para cubrir el entorno.
      - Desactivamos cualquier emisión de luz o reflexión que modifique el tono tenebroso.

   **Afinar iluminación “tenebrosa”**
      - Directional Light: Bajamos su intensidad a ~0.3. Cambiamos su color a un gris azulado.
      - Point Lights: Añadimos luces puntuales en el interior (GameObject → Light → Point Light) con intensidad baja para puntos de interés.
      - Ambient Lighting: En Window → Rendering → Lighting → pestaña Environment, cambiamos el Ambient Color a un gris oscuro o cerca del negro.

7. **Probamos y ajustamos**  
   - Pulsamos **Play**. 
   - Corregimos la altura del `Player` (Transform.position.y) para que los pies toquen el suelo.  
   - Ajustamos colisiones y parámetros del **Character Controller** (radius, height).


## Equipo
- Valentina Arriaga
- Ona Labay
- Carolina Sanchez
