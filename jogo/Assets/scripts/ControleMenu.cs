using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControleMenu : MonoBehaviour
{
    public AudioSource botaoClick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IniciarJogo()
    {
        botaoClick.Play();
        SceneManager.LoadScene("SampleScene");
    }
    public void FecharJogo()
    {
        botaoClick.Play();
        Application.Quit();

    }



}
