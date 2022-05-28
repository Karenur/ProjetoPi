using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleVida : MonoBehaviour
{
    public ControleVitorioa controleVitoria;
    [SerializeField] Animator anim;
    [SerializeField] Image barraVida;
    [SerializeField] float vidaMaxima;
    [SerializeField] float vidaAtual;

    public Sprite vidaVerde;
    public Sprite vidaAmarela;
    public Sprite vidaVermelha;
    public float VidaAtual 
    { 
        get => vidaAtual; 
        set => vidaAtual = Mathf.Clamp(value,0,vidaMaxima); 
    }



    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        AtualizarBarraVida();
    }

    private void AtualizarBarraVida()
    {
        barraVida.fillAmount = VidaAtual / vidaMaxima;
        if(vidaAtual>= vidaMaxima-(0.25*vidaMaxima))
        {
            barraVida.sprite = vidaVerde;
        }
        if (vidaAtual >= vidaMaxima-(0.5*vidaMaxima) && vidaAtual < vidaMaxima-(0.25 * vidaMaxima))
        {
            barraVida.sprite = vidaAmarela;
        }
        if (vidaAtual >= vidaMaxima - (0.75 * vidaMaxima) && vidaAtual < vidaMaxima - (0.5 * vidaMaxima))
        {
            barraVida.sprite = vidaVermelha;
        }

    }

    public void LevarDano(float danoLevado)
    {
        if (controleVitoria.FimJogo == false)
        {
            if (VidaAtual <= danoLevado)
            {
                VidaAtual = 0;
                anim.SetBool("morto", true);
            }
            else
            {
                VidaAtual -= danoLevado;
            }
        }
    }
}
