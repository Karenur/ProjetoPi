using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ControleVitorioa : MonoBehaviour
{

    public GameObject CamCineMagine;
    public AudioSource SomDerrota;
    public AudioSource SomVitoria;
    public AudioSource musicaFundo;
    public AudioSource botaoClick;
    public AudioSource motorJogador;
    public ControleVida vidaInimigo;
    public ControleVida vidaJogador;
    public bool FimJogo = false;

    public Sprite Vitoria;
    public Sprite Derrota;


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
        if (FimJogo == true)
        {
            return;
        }

        if (vidaJogador.VidaAtual <= 0 || vidaInimigo.VidaAtual <= 0)
        {
            musicaFundo.Stop();
            FimJogo = true;
            motorJogador.Stop();
            CamCineMagine.SetActive(false);
            Invoke("SelecionarTelaFinal", 1);
            
        }
        else
        {
            FimJogo = false;
        }
    }
    public void SelecionarTelaFinal()
    {
        if (vidaJogador.VidaAtual <= 0)
        {
            SomDerrota.Play();
            telaFimGame.SetActive(true);
            telaFimGame.GetComponent<Image>().sprite = Derrota;
            return;
        }
        else
        {
            SomVitoria.Play();
            telaFimGame.SetActive(true);
            telaFimGame.GetComponent<Image>().sprite = Vitoria;
            return;
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

    public void SomBotao()
    {

        botaoClick.Play();
    }

}
