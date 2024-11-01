using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorConstru��o : MonoBehaviour
{
    public static GerenciadorConstru��o main; // Inst�ncia �nica do GerenciadorConstru��o

    [SerializeField] List<Torre> torres; // Lista de torres dispon�veis

    int selectedTower = 0; // �ndice da torre selecionada

    private void Awake()
    {
        main = this; // Inicializa a inst�ncia �nica
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
