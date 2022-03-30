using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baralho : Local
{

    public BancoDeMunicoes bm;
    public List<GameObject> slotMao;
    public List<GameObject> canhaoes;

    public int podebaralhar = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Embaralhador()
    {
        
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
