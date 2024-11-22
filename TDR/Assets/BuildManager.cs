using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GerenciadorDeConstrução : MonoBehaviour
{
    public static GerenciadorDeConstrução main; // Instância única do GerenciadorConstrução

    [SerializeField] List<Torre> torres; // Lista de torres disponíveis
    [SerializeField] TextMeshProUGUI moedaUI;

    int selectedTower = 0; // Índice da torre selecionada

    private void Awake()
    {
        main = this; // Inicializa a instância única
    }

    private void OnGUI()
    {
        moedaUI.text = GameManager.main.currency.ToString(); // Atualiza o texto da UI com a quantidade atual de moedas
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
