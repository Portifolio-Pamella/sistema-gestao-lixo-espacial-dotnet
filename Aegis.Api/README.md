# AEGIS - Plataforma de Gestão de Lixo Espacial

Projeto desenvolvido para otimizar a segurança orbital através da monitorização e gestão de detritos espaciais.

## 👥 Integrantes
* **João Pedro Pereira Camilo** | RM562005
* **Lucas Matsubara Reis** | RM565020
* **Pamella Christiny Chaves Brito** | RM565206

---

## 1. Problema Abordado
O crescimento exponencial de detritos espaciais em órbita terrestre baixa (LEO) — fenômeno conhecido como Síndrome de Kessler — cria uma ameaça crítica à integridade de satélites ativos, infraestruturas de telecomunicações e tripulações. Atualmente, a gestão dessas ameaças é fragmentada, com a ausência de um sistema centralizado que correlacione, em tempo real, a trajetória de detritos perigosos com a localização de ativos espaciais.

## 2. Objetivos da Solução
A Plataforma AEGIS visa transformar a segurança orbital através de:
* **Monitoramento Centralizado:** Consolidar dados de ativos e detritos em uma base íntegra.
* **Automação de Resposta:** Reduzir a latência operacional através de missões de interceptação automatizadas.
* **Visibilidade de Risco:** Permitir o cálculo imediato de risco de colisão.
* **Gestão de Ciclo de Vida:** Acompanhar desde a identificação do risco até a execução da missão.

---

## 3. Requisitos Técnicos
* **Arquitetura:** API REST com separação de camadas (Controllers, Services, Repositories).
* **Persistência:** Banco de Dados Oracle.
* **ORM:** Entity Framework Core.
* **Relacionamentos:** Mapeamento de 1:N e N:N conforme as regras de negócio.
* **Gestão de Banco:** Uso de Migrations para versionamento do esquema.

---

## 4. Como Executar

### Pré-requisitos
1. Ter o **.NET SDK** instalado.
2. Configurar a *Connection String* no `appsettings.json`.

### Instalação de Dependências
No terminal, dentro da pasta do projeto, execute:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Oracle.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Mvc