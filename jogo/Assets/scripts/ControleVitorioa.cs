using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControleVitorioa : MonoBehaviour
{
    public AudioSource motorJogador;
    public ControleVida vidaInimigo;
    public ControleVida vidaJogador;
    public bool FimJogo = false;

    public TextMeshProUGUI textoDialogo;
    public GameObject telaFimGame;
    public // Start is called before the first frame update
    void Start()
    {
        telaFimGame.SetActive(false);
        motorJogador.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaJogador.VidaAtual <= 0 || vidaInimigo.VidaAtual <= 0)
        {
            FimJogo = true;
            motorJogador.Stop();
            telaFimGame.SetActive(true);
            if(vidaJogador.VidaAtual <= 0)
            {
                textoDialogo.text = "Derrota";
            }
            else
            {
                textoDialogo.text = "Vitoria";
            }
        }
        else
        {
            FimJogo = false;
        }
    }

    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }



    public void FecharJogo()
    {

        Application.Quit();

    }
}
