using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleVida : MonoBehaviour
{
    [SerializeField] Slider barraVida;
    [SerializeField] float vidaMaxima;
    float vidaAtual;



    // Start is called before the first frame update
    void Start()
    {
        barraVida.maxValue = vidaMaxima;
        vidaAtual = vidaMaxima;
        

    }
    private void Update()
    {
        barraVida.value = vidaAtual;
       
    }

    public void LevarDano(float danoLevado)
    {
        if (vidaAtual >= danoLevado)
        {
            vidaAtual -= danoLevado;
        }
    }
}
