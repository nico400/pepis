# Pepis (Pepito)

Jogo 3D de plataforma e puzzle em terceira pessoa, feito em Unity 6 (URP). O jogador controla **Pepito**, que corre, escala paredes de vinhas, sobe em pilares, **pega e arremessa uma bola** com trajetória prevista para ativar mecanismos e coleta itens de um inventário. O jogo tem cutscene de introdução, um hub e duas fases.

---

## Stack

| | |
|---|---|
| Engine | **Unity 6000.0.38f1** |
| Render | **URP 17.0** + Shader Graph |
| Física | Rigidbody (`linearVelocity`, API do Unity 6) + Physic Materials próprios (`frictionBall`, `frictionGroundWall`) |
| Input | **Input System 1.13**, com classe C# gerada (`InputsAction`) e suporte a teclado/mouse e gamepad |
| Câmera | **Cinemachine 3.1** (câmeras de exploração, mira e shake, com Custom Blends) |
| Plataformas móveis | **Splines** (`SplineAnimate`) |
| Outros | Timeline, ProBuilder, TextMesh Pro, AI Navigation, VideoPlayer |

---

## Estrutura

```
Assets/script
├── getInputsHandler.cs        # Camada de input (Input System → propriedades)
├── loadLevelManager.cs        # Portais de troca de fase
├── Player
│   ├── moviment.cs            # Locomoção baseada na normal do chão
│   ├── rotatePlayer.cs        # Alinhamento ao chão / parede / pilar / mira
│   ├── MovimentWall.cs        # Escalada em vinhas
│   ├── MovimentInPillar.cs    # Movimento orbital em pilares
│   ├── launchBall.cs          # Pegar, mirar e arremessar a bola + trajetória
│   └── grabbBall.cs
├── plataforms                 # Plataformas móveis, parafusos giratórios, arcos de velocidade…
├── interactive                # Alavancas/torres (eventos) e "keysRuns" (chave que foge)
├── changeCams                 # Troca de câmeras Cinemachine (normal ↔ mira)
├── menu                       # Menu, cutscene em slides, inventário
└── CutSeane
```

---

## Destaques técnicos

### Camada de input desacoplada

`getInputsHandler` encapsula o **Input System** e expõe o estado como propriedades somente leitura (`dirXY`, `mouseXY`, `jump`, `launc`, `interactived`, `runShift`, `runGamepad`…).

- Ações contínuas (`move`, `mouseAim`) são lidas com `ReadValue<Vector2>()`. Ações de "segurar" (`launchBall`, `Interact`, `runing`) usam os callbacks `started`/`canceled`.
- Detecta se há gamepad (`Gamepad.current`) e alterna entre **correr segurando Shift** (teclado) e **correr com toggle no analógico** (gamepad).
- Dois action maps: `Player` (gameplay) e `ui` (`ExitPainel`).

| Ação | Teclado / mouse | Gamepad |
|---|---|---|
| Mover | WASD | Analógico esquerdo |
| Mirar | Mouse | — |
| Pular | Espaço | A / ✕ |
| Interagir / pegar a bola | E | X / ▢ |
| Mirar e arremessar | Segurar E (mira) e soltar (arremessa) | Segurar X / ▢ e soltar |
| Correr | Shift esquerdo | Clique no analógico esquerdo (toggle) |
| Sair de painel | Esc | B / ◯ |

### Locomoção alinhada à superfície

- Um raycast a partir de um offset acima do pé obtém a **normal do chão** (`upNormal`) e o estado de grounded.
- A direção de movimento relativa à câmera é montada com **produtos vetoriais sobre a normal** (`right = cam.forward × normal`, `forward = right × normal`), então o personagem anda corretamente em rampas e superfícies inclinadas.
- A velocidade é decomposta em **componente vertical** (`Vector3.Project` na normal) e **horizontal** (`ProjectOnPlane`). Aceleração e desaceleração usam `Vector3.MoveTowards` só na parte horizontal, preservando a vertical (pulo e gravidade).
- Pulo com velocidade calculada pela altura desejada: `v = √(2·g·h)`.
- A velocidade máxima é dinâmica (andar, correr, carregando a bola) e volta suavemente ao normal depois de um boost (`Mathf.Lerp`).

### Modos de movimento especiais

| Modo | Implementação |
|---|---|
| **Escalada em vinhas** (`MovimentWall`) | Raycast frontal na layer `Viny`. Desliga a gravidade, cola o jogador no ponto de impacto, move no plano `right/up` local e faz wall-jump com impulso para trás e para cima |
| **Pilares** (`MovimentInPillar`) | `OverlapSphere` acha o pilar mais próximo. O input horizontal vira rotação ao redor do pilar (vetor tangente `dirToPillar × normal`) e o vertical vira subida/descida |
| **Arcos de velocidade** (`arcSpeed`) | Ao entrar no trigger, aplica velocidade na direção do arco, opcionalmente reposicionando o jogador (lançadores) |

`rotatePlayer` decide a orientação conforme o modo ativo: alinhar ao chão (`FromToRotation` + `Slerp`), olhar para a parede/pilar ou girar com o mouse no modo de mira.

### Arremesso com trajetória prevista

`launchBall` faz o ciclo pegar → mirar → arremessar com coroutines:

1. **Pegar:** a bola perde a gravidade e é presa a um ponto na frente do personagem enquanto `Grab` estiver ativo. O pulo fica bloqueado e a velocidade máxima cai.
2. **Mirar:** o jogador para, a câmera troca para a de mira (`controllCams`) e um **`LineRenderer` desenha a parábola** calculada analiticamente:

   ```
   p(t) = p₀ + v₀·t + ½·g·t²
   ```

   amostrada em `countPositions` pontos ao longo de `timeOfTheFlight`.
3. **Arremessar:** devolve a gravidade e aplica `v₀` na bola. A trajetória desenhada é a mesma que a física vai percorrer.

### Puzzles orientados a eventos

Os mecanismos se comunicam por **eventos estáticos C# com ID**, sem referências diretas entre objetos:

```csharp
public delegate void EventRotateScrew(int id);
public static event EventRotateScrew OnRotateScrew;
// ...
OnRotateScrew?.Invoke(Id_linkScrew);   // quando a bola acerta o gatilho
```

- `StartRotateScrew` → `RotateScrew`: a bola atinge um gatilho e todos os parafusos com o mesmo ID executam uma sequência de rotação em etapas (coroutine com fases temporizadas e retorno à rotação original).
- `ActiveLever` → `TowerComp`: alavancas ativam torres pelo ID.
- `BreakWalls` (paredes destruídas pela bola), `movingPlataform` (plataforma que leva a bola até um destino) e `RespawnBall` (recria a bola se ela for destruída).
- `plataformSpline`: plataformas sobre **Splines** com `SplineAnimate` e tempo inicial defasado.

### "Chave fugitiva" (`keysRuns`)

Um objeto que **foge do jogador** por um circuito de waypoints:

- Percorre a lista de pontos em loop e, ao chegar perto de um ponto, escolhe o próximo.
- Calcula um ponto à frente (`PointGhost`) e usa o **produto escalar** entre a direção desse ponto e a direção do jogador para saber se o jogador está na frente. Se estiver, **inverte o sentido** do percurso.
- A direção é suavizada com `Vector3.Slerp` e gizmos desenham o circuito no editor.

### Inventário com ScriptableObjects

- `ItemCreator` (`[CreateAssetMenu]`): cada item é um asset com ícone, nome e descrição (ex.: `CartaoCastracao`, `FotoLakshmi`, `Pneu`, `SacoDeRacao`).
- `PepitoPega` coleta itens próximos com `OverlapSphere` filtrado por layer. `Inventario` guarda a lista sem duplicatas.
- `InventarioUI` recria os slots dinamicamente (instancia prefabs, liga `onClick` por lambda) e mostra um painel de detalhes com TextMesh Pro.

### Fluxo de cenas e apresentação

```
Menu → Startcutscene → Hub → Level1 / Level2
```

- `MainMenu`: painel de opções e fade para preto antes de carregar a cena.
- `Cutscene`: história em slides (imagem + texto) avançando com qualquer tecla.
- Vídeo de abertura via `VideoPlayer` → `RenderTexture`.
- `loadLevelManager`: portais no Hub que carregam a fase ao interagir.
- Timeline, partículas, skybox estilizado e fontes próprias.

---

## Como rodar

1. Abra o projeto com **Unity 6000.0.38f1**.
2. Abra `Assets/Scenes/Menu.unity` e dê Play.

Cenas: `Menu`, `Startcutscene`, `Hub`, `Level1`, `Level2` (em `Assets/Scenes`).
