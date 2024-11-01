using UnityEngine;

public class Vida : MonoBehaviour, IReceberDano
{
    [SerializeField] int pontosDeVida = 2; // Pontos de vida do objeto
    [SerializeField] int valorEmMoeda = 50; // Valor em moeda ao ser destru�do
    bool estaDestruido = false; // Indica se o objeto j� foi destru�do

    // M�todo para receber dano
    public void TakeDamage(int dano)
    {
        pontosDeVida -= dano; // Reduz os pontos de vida pelo dano recebido

        // Verifica se os pontos de vida s�o menores ou iguais a zero e se n�o foi destru�do
        if (pontosDeVida <= 0 && !estaDestruido)
        {
            GameManager.onEnemyDestroy.Invoke(); // Invoca o evento de destrui��o de inimigo
            GameManager.main.AumentarMoeda(valorEmMoeda); // Aumenta a moeda do jogador
            estaDestruido = true; // Marca como destru�do
            Destroy(gameObject); // Destroi o objeto
        }
    }
}
