using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // N�o esque�a de adicionar esta diretiva para acessar os componentes da UI

public enum SelectionState
{
    None,
    SelectingOrigin,
    SelectingDestination,
    Filled
}

public enum SearchType
{
    BFS,        // Busca em largura
    DFS,        // Busca em profundidade
    Dijkstra,   // Algoritmo de Dijkstra
    AStar       // Algoritmo A*
}

public class UIController : MonoBehaviour
{


    public SelectionState currentState = SelectionState.None;
    public Node originNode = null;
    public Node destinationNode = null;

    public GameManager gameManager; // Refer�ncia para o seu script GameManager
    //public BFS bfsScript; // Refer�ncia para o script BFS

    // Refer�ncias aos bot�es
    public Button selectOriginButton;
    public Button selectDestinationButton;
    public Button clearGrid;
    public Button buscar;
    public TMP_Dropdown searchTypeDropdown;
    public SearchType searchType = SearchType.BFS;

    public TMP_Text infoText;

    void Start()
    {
        // Popula o dropdown com os valores do enum
        PopulateSearchTypeDropdown();
        infoText.text = "Clique em 'Selecionar origem' e clique em um quadrado branco.";
        // Adiciona listeners aos bot�es para selecionar origem e destino
        selectOriginButton.onClick.AddListener(() => { currentState = SelectionState.SelectingOrigin; });
        selectDestinationButton.onClick.AddListener(() => { currentState = SelectionState.SelectingDestination; });
        buscar.onClick.AddListener(() => { StartSearch(); });
        // Adiciona um listener ao bot�o para limpar o grid
        clearGrid.onClick.AddListener(() => { 
            gameManager.gridGenerator.ClearGrid(); 
            originNode = null;
            destinationNode = null;
            currentState = SelectionState.None;
            buscar.interactable = true; // Habilita o bot�o de busca
            infoText.text = "Clique em 'Selecionar origem' e clique em um quadrado branco.";
        });
    }

    // M�todo chamado quando um n� � clicado
    public void NodeClicked(Node clickedNode)
    {
        if (clickedNode.isObstacle) return; // Ignora cliques em obst�culos

        // Dependendo do estado atual, o n� clicado ser� a origem ou o destino
        switch (currentState)
        {
            case SelectionState.SelectingOrigin:
                originNode = clickedNode;
                // Marque o quadrado como origem, por exemplo, mudando sua cor
                clickedNode.square.GetComponent<SpriteRenderer>().color = gameManager.startColor;
                currentState = SelectionState.None; // Reseta o estado
                infoText.text = "Clique em 'Selecionar destino' e clique em um quadrado branco.";
                break;
            case SelectionState.SelectingDestination:
                destinationNode = clickedNode;
                // Marque o quadrado como destino
                clickedNode.square.GetComponent<SpriteRenderer>().color = gameManager.endColor;
                currentState = SelectionState.Filled; // Muda o estado para preenchido
                infoText.text = "Clique em 'Realizar busca' para iniciar a busca.";
                break;
        }
    }

    public void StartSearch()
    {
        buscar.interactable = false; // Desabilita o bot�o de busca

        switch (searchTypeDropdown.value)
        {
            case 0:
                searchType = SearchType.BFS;
                break;
            case 1:
                searchType = SearchType.DFS;
                break;
            case 2:
                searchType = SearchType.Dijkstra;
                break;
            case 3:
                searchType = SearchType.AStar;
                break;
        }
        // Se ambos, origem e destino, foram selecionados, executa a busca em largura
        if (originNode != null && destinationNode != null)
        {
            gameManager.RunSearch(originNode, destinationNode, searchType); // Assuma que seu m�todo de busca em largura se chama RunBFS
            infoText.text = "Busca realizada com sucesso.\n\nClique em 'Limpar grid' para selecionar novos pontos.";
        }
    }

    void PopulateSearchTypeDropdown()
    {
        // Limpa as op��es existentes no dropdown
        searchTypeDropdown.ClearOptions();

        // Cria uma lista de strings baseada nos nomes dos valores do enum
        List<string> options = new List<string>();

        foreach (var value in System.Enum.GetValues(typeof(SearchType)))
        {
            options.Add(value.ToString());
        }

        // Adiciona a lista de strings como op��es do dropdown
        searchTypeDropdown.AddOptions(options);
    }
}
