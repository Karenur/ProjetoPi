using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baralho : Local
{

    public BancoDeMunicoes bm;
    public List<GameObject> slotMao;
    public List<GameObject> canhaoes;
    public Sprite botaoAberto;
    public Sprite botaoFechado;
    public int podebaralhar = 0;
    public Button botaoEmbaralhar;
    GameObject controleVitorioa;

    // Start is called before the first frame update
    void Start()
    {
        controleVitorioa = GameObject.Find("ControleVitoria");


    }

    // Update is called once per frame
    void Update()
    {        
        if (podebaralhar == 5)
        {
            botaoEmbaralhar.GetComponent<Image>().sprite = botaoAberto;
        }
        if (podebaralhar == 0)
        {
            botaoEmbaralhar.GetComponent<Image>().sprite = botaoFechado;
        }
    }

    public void Embaralhador()
    {
        if (controleVitorioa.gameObject.GetComponent<ControleVitorioa>().FimJogo == true)
        {
            return;
        }

        if (podebaralhar == 5)
        {
            for (int i = 0; i < slotMao.Count; i++)
            {
                int rnd = Random.Range(0, bm.cartasDisponiveis.Count);
                slotMao[i].GetComponent<Image>().sprite = bm.cartasDisponiveis[rnd].GetComponent<SpriteRenderer>().sprite;
                podebaralhar = 0;
            }
        }

    }


}
