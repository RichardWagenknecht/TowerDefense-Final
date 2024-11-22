using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GerenciadorDeConstru��o : MonoBehaviour
{
    public static GerenciadorDeConstru��o main; // Inst�ncia �nica do GerenciadorConstru��o

    [SerializeField] List<Torre> torres; // Lista de torres dispon�veis
    [SerializeField] TextMeshProUGUI moedaUI;

    int selectedTower = 0; // �ndice da torre selecionada

    private void Awake()
    {
        main = this; // Inicializa a inst�ncia �nica
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
