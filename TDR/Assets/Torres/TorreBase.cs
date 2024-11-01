using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Classe abstrata base para torres
public abstract class TorreBase : MonoBehaviour
{
    // A dist�ncia m�xima que a torre pode atingir um inimigo
    [SerializeField] protected float targetingRange = 5f;

    // M�scara de camada que define quais objetos s�o considerados inimigos
    [SerializeField] protected LayerMask enemyMask;

    // Prefab do proj�til que a torre ir� disparar
    [SerializeField] protected GameObject bulletPrefab;

    // Ponto de onde os proj�teis ser�o disparados
    [SerializeField] protected Transform firingPoint;

    // N�mero de disparos por segundo
    [SerializeField] protected float bps = 1f;

    // Transform do alvo atual que a torre est� mirando
    protected Transform target;

    // Tempo at� que a torre possa disparar novamente
    private float timeUntilFire;

    // M�todo chamado a cada frame
    private void Update()
    {
        // Se n�o houver alvo, procura um novo
        if (target == null)
        {
            FindTarget();
            return; // Se n�o h� alvo, sai do m�todo
        }

        // Verifica se o alvo est� fora do alcance
        if (!CheckTargetIsInRange())
        {
            target = null; // Se o alvo est� fora do alcance, reseta o alvo
        }
        else
        {
            // Acumula o tempo at� o pr�ximo disparo
            timeUntilFire += Time.deltaTime;

            // Verifica se � hora de disparar
            if (timeUntilFire >= 1f / bps)
            {
                Shoot(); // Dispara o proj�til
                timeUntilFire = 0f; // Reseta o temporizador
            }
        }
    }

    // M�todo virtual para disparar, pode ser sobrescrito nas classes filhas
    protected virtual void Shoot()
    {
        // Instancia o proj�til no ponto de disparo
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        // Obt�m o script do proj�til para definir o alvo
        Tiro bulletScript = bulletObj.GetComponent<Tiro>();
        bulletScript.SetTarget(target); // Define o alvo do proj�til
    }

    // Verifica se o alvo est� dentro do alcance da torre
    protected bool CheckTargetIsInRange()
    {
        // Retorna verdadeiro se a dist�ncia at� o alvo � menor ou igual ao alcance
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    // M�todo virtual para encontrar um alvo, pode ser sobrescrito nas classes filhas
    protected virtual void FindTarget()
    {
        // Realiza um raio em c�rculo para encontrar inimigos dentro do alcance
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0f, enemyMask);

        // Se algum inimigo foi encontrado, define o primeiro como alvo
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    // M�todo para desenhar uma representa��o visual do alcance da torre no editor
    public void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue; // Define a cor do gizmo
        // Desenha um disco wireframe ao redor da torre para visualizar o alcance
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
