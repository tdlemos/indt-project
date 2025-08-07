# indt-project
Ao clonar o projeto, o avaliador precisará baixar os pacotes Nuget e executar os dois projetos WebApi ao mesmo tempo, desta maneira será possível a valiação correta da aplicação.

O projeto **Indt.Proposta.WebApi** é responsável por cadastrar, listar e atualizar o status de uma proposta, conforme indicado nos endpoints:

<img width="1920" height="1030" alt="image" src="https://github.com/user-attachments/assets/41e9c485-2a0e-4fda-b5b4-95fda5bff770" />

O projeto Indt.Contratacao.WebApi é responsável por criar a contratação da proposta, para isso ele irá utilizar o serviço do projeto Indt.Prospota.WebApi que está em execução.

<img width="1920" height="1030" alt="image" src="https://github.com/user-attachments/assets/8b5dbb3e-76d4-4ac8-9470-4554f7d9b2f9" />
