using UnityEngine;

public class TorreNormal : TorreBase
{
    // A torre normal usar� o bulletPrefab da classe base
    // O m�todo Shoot permanece o mesmo, pois j� est� implementado na classe base

    protected override void Shoot()
    {
        // Verifica se h� um alvo antes de disparar
        if (target != null)
        {
            // Instancia um proj�til para o alvo
            GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity); // Cria um novo proj�til
            Tiro bulletScript = bulletObj.GetComponent<Tiro>(); // Obt�m o script do proj�til
            bulletScript.SetTarget(target); // Define o alvo do proj�til
        }
    }

    // Se desejar adicionar Gizmos espec�ficos para a TorreNormal, voc� pode implementar aqui
    private void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected(); // Chama o m�todo base para desenhar o alcance da torre
        // Voc� pode adicionar outros Gizmos aqui, se necess�rio
    }
}
