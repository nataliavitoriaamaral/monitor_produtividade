# Monitor de Produtividade

## Sobre 
O **Monitor de Produtividade** é uma aplicação desktop desenvolvida em **C#** (Windows Forms) que atua como um rastreador de tempo de uso do sistema. O programa identifica automaticamente qual janela ou aplicativo está ativo e contabiliza o tempo gasto pelo usuário em cada tarefa, gerando um log detalhado.

Este projeto foi criado com o objetivo de explorar conceitos de automação, interação com o sistema operacional e **coleta de dados** focada na otimização da rotina e gestão do tempo.

## Funcionalidades
* **Rastreamento em Tempo Real:** Captura o título da janela ativa no Windows (ex: abas do navegador, IDEs, aplicativos abertos).
* **Cronometragem Automática:** Registra o tempo exato (em horas, minutos e segundos) de permanência em cada aplicação.
* **Geração de Relatório de Uso:** Consolida os dados capturados em um painel estruturado de fácil leitura.
* **Envio de Relatórios:** O código original possui integração para envio de relatório via e-mail. **Nota de Segurança:** As credenciais do servidor SMTP foram removidas propositalmente deste repositório público para proteger dados sensíveis. Ao clicar em "Enviar relatório", o sistema retornará um erro esperado de falta de servidor.

## Tecnologias e Conceitos Aplicados
**Linguagem:** C# (.NET)
**Interface:** Windows Forms (WinForms)
**IDE:** Visual Studio Community
* **Conceitos de Computação Explorados:**
  * Interação com APIs nativas do Windows.
  * Manipulação de eventos e *Timers* (processamento em segundo plano).
  * Lógica de programação para estruturação, soma e formatação de dados de tempo.
---
Desenvolvido por **Natália Amaral**
