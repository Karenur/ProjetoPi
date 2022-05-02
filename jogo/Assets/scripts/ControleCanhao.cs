using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCanhao : MonoBehaviour
{

    
    public float velocidadeTiro = 1;
    public float podeAtirar;
    public ControleVida controleVida;

    // Start is called before the first frame update
    void Start()
    {
        podeAtirar = velocidadeTiro;
    }

    // Update is called once per frame
    void Update()
    {
        if (podeAtirar <= velocidadeTiro && controleVida.VidaAtual > 0)
        {
            podeAtirar += Time.deltaTime;
        }
    }
}
