readme_content = """# 🛰️ AEGIS - Plataforma de Gestão de Lixo Espacial

Bem-vindo ao repositório do **Projeto AEGIS**. Uma solução dedicada à otimização da segurança orbital, monitorização e gestão inteligente de detritos espaciais.

---

## 👥 Integrantes
* 👤 **João Pedro Pereira Camilo** | `RM562005`
* 👤 **Lucas Matsubara Reis** | `RM565020`
* 👤 **Pamella Christiny Chaves Brito** | `RM565206`

---

## 🎥 Vídeos de Apresentação
- [▶️ Video Pitch](https://youtu.be/QwVvUHkri4o?si=vpOtBC50kf3HHxid)
- [▶️ Apresentação do Projeto](https://youtu.be/qSeSL6MJgXI?si=GoC5-d16NxOGiAkA)

---
## Link do Miro com os diagramas
- [📊 Miro - Diagramas do Projeto](https://miro.com/app/board/uXjVHJRQwnM=/?share_link_id=863264873443)

---

## 🎯 Sobre o Projeto

![Diagrama do Sistema](Scripts\diagrama.png)

### ⚠️ O Problema
O crescimento exponencial de detritos espaciais em órbita terrestre baixa (LEO) — fenômeno conhecido como **Síndrome de Kessler** — cria uma ameaça crítica à integridade de satélites ativos, infraestruturas de telecomunicações e tripulações. Atualmente, a gestão dessas ameaças é fragmentada, sem um sistema centralizado que correlacione, em tempo real, a trajetória de detritos perigosos com a localização de ativos espaciais.

### 💡 Objetivos da Solução
* **Monitoramento Centralizado:** Consolidar dados de ativos e detritos em uma base íntegra.
* **Automação de Resposta:** Reduzir a latência operacional através de missões de interceptação automatizadas.
* **Visibilidade de Risco:** Permitir o cálculo imediato de risco de colisão.
* **Gestão de Ciclo de Vida:** Acompanhar desde a identificação do risco até a execução da missão.

---

## 🛠️ Stack Tecnológica
* **Arquitetura:** API REST (Clean Architecture: Controllers, Services, Repositories).
* **Banco de Dados:** Oracle.
* **ORM:** Entity Framework Core.
* **Gestão de Banco:** Migrations para versionamento do esquema.

---

## 🚀 Como Executar

### Pré-requisitos
1. Tenha o **.NET SDK** instalado.
2. Configure a *Connection String* no arquivo `appsettings.json`.

### Instalação de Dependências
No terminal, dentro da pasta do projeto, execute:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Oracle.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Mvc
