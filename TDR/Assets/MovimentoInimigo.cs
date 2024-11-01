using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : InimigoBase
{
    // M�todo chamado no in�cio
    public override void Start()
    {
        base.Start(); // Chama o m�todo Start da classe base
    }

    // M�todo chamado a cada frame
    public override void Update()
    {
        base.Update(); // Chama o m�todo Update da classe base
    }

    // M�todo chamado a cada FixedFrame (usado para f�sica)
    public override void FixedUpdate()
    {
        base.FixedUpdate(); // Chama o m�todo FixedUpdate da classe base
    }
}
