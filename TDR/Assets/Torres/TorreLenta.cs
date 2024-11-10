using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TorreLenta : TorreBase
{
    [SerializeField] private float slowAmount = 0.99f; // Porcentagem de desacelera��o (0 a 1)
    [SerializeField] private float slowRadius = 3f; // Raio de desacelera��o
    [SerializeField] private float slowDuration = 2f; // Dura��o do efeito de desacelera��o

    private HashSet<InimigoBase> enemiesInSlowZone = new HashSet<InimigoBase>();
    private Dictionary<InimigoBase, float> originalSpeeds = new Dictionary<InimigoBase, float>();

    private void Update()
    {
        // Adiciona inimigos que entram na zona de desacelera��o
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, slowRadius, enemyMask);
        foreach (Collider2D collider in colliders)
        {
            InimigoBase enemy = collider.GetComponent<InimigoBase>();
            if (enemy != null && !enemiesInSlowZone.Contains(enemy))
            {
                enemiesInSlowZone.Add(enemy);
                originalSpeeds[enemy] = enemy.GetSpeed(); // Armazena a velocidade original
                enemy.SetSpeed(enemy.GetSpeed() * slowAmount); // Aplica desacelera��o imediata
            }
        }

        // Remove inimigos que sa�ram da zona de desacelera��o
        enemiesInSlowZone.RemoveWhere(enemy =>
        {
            bool isOutsideRange = enemy == null || Vector2.Distance(transform.position, enemy.transform.position) > slowRadius;
            if (isOutsideRange && enemy != null)
            {
                // Restaura a velocidade original do inimigo
                enemy.SetSpeed(originalSpeeds[enemy]);
                originalSpeeds.Remove(enemy); // Remove do dicion�rio de velocidades originais
            }
            return isOutsideRange;
        });
    }




    private IEnumerator ApplySlow(InimigoBase enemy)
    {
        Debug.Log("Aplicando desacelera��o para: " + enemy.name); // Log para verificar se o m�todo � chamado
        enemy.SetSpeed(enemy.GetSpeed() * slowAmount);
        yield return new WaitForSeconds(slowDuration);
        enemy.SetSpeed(enemy.GetSpeed() / slowAmount);
        enemiesInSlowZone.Remove(enemy); // Remove do conjunto de inimigos desacelerados
    }

}
