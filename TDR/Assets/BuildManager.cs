using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeConstrução : MonoBehaviour
{
    public static GerenciadorDeConstrução main; // Instância única do GerenciadorConstrução

    [SerializeField] List<Torre> torres; // Lista de torres disponíveis

    int selectedTower = 0; // Índice da torre selecionada

    private void Awake()
    {
        main = this; // Inicializa a instância única
    }

    public Torre GetSelectedTower()
    {
        return torres[selectedTower]; // Retorna a torre selecionada
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower; // Define a torre selecionada
    }
}
