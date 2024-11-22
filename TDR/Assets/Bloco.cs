using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer; // Renderer do sprite do bloco
    [SerializeField] Color hoverColor; // Cor do bloco ao passar o mouse

    GameObject tower; // Refer�ncia � torre constru�da
    Color startColor; // Cor original do bloco

    private void Start()
    {
        startColor = spriteRenderer.color; // Armazena a cor original
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor; // Muda a cor do bloco ao passar o mouse
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = startColor; // Restaura a cor original ao sair com o mouse
    }

    private void OnMouseDown()
    {
        if (tower != null) return; // Retorna se j� houver uma torre constru�da

        Torre towerToBuild = GerenciadorDeConstru��o.main.GetSelectedTower(); // Obt�m a torre selecionada

        if (towerToBuild.custo > GameManager.main.currency) // Verifica se h� moedas suficientes
        {
            Debug.Log("Voc� n�o pode comprar esta torre."); // Log de erro se n�o houver moedas suficientes
            return;
        }
        GameManager.main.GastarMoeda(towerToBuild.custo); // Deduz o custo da torre

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity); // Instancia a nova torre
    }
}
