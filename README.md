# Algoritmos de Busca em Unity
Este projeto estuda a aplicação dos algoritmos de busca BFS (Breadth-First Search - Busca em Largura), DFS (Depth-First Search - Busca em Profundidade), Dijkstra (Busca Uniforme) e A* em um grid procedural.
O projeto foi construído na Unity 2022.3.20f1.

## Como usar o exemplo:
- Baixe o projeto via git ou fazendo o download do arquivo .zip.
- Se baixou o .zip, descompacte em uma pasta.
- Abra o projeto na Unity. Recomenda-se a versão de criação (2022.3.20f1) ou superior.
- Importe o TextMeshPro para o projeto (senão a UI não funciona).
- Abra a cena Main.
- Mude a resolução da janela Game para 1920x1080 (ou a UI ficará bugada).
- Clique no ícone para executar o projeto (botão de "play").

## Funcionamento do projeto:
- Clique em "Selecionar origem" e clique em um dos quadrados brancos na tela.
- Clique em "Selecionar destino" e clique em um dos quadrados brancos na tela.
- Selecione o algoritmo de busca (BFS, DFS, Dijkstra ou A*)
- Clique em "Realizar busca" para que o caminho seja calculado.
- Se quiser refazer a busca com outra origem e destino, clique em "Limpar grid".

## Ajustes no GameManager
- Selecione o objeto GameManager na cena Main.
- Poderá ajustar a quantidade de linhas e colunas do grid gerado proceduralmente (limitada no intervalo de 10 a 200).
- Ajuste também a porcentagem de quadrados que serão obstáculos, que ficarão na cor preta.
- Configure as cores (observe se o canal alpha delas está em 100%. Pode ocorrer das cores estarem com o canal alpha zerado).

Os exemplos contidos neste projeto foram extraídos e adaptados do livro AI for Games, de Ian Millington e outros foram construídos com algoritmos que aprendi na faculdade e ficaram guardados em minha biblioteca (não lembro a fonte).
O ChatGPT foi utilizado para adaptar parte dos algoritmos ao projeto.
