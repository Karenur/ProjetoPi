using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baralho : Local
{

    public BancoDeMunicoes bm;
    public List<GameObject> posicoesCartas;

    // Start is called before the first frame update
    void Start()
    {
        cartas = new List<GameObject>();
            
        
        
       

    }

    // Update is called once per frame
    void Update()
    {

       
        

    }

    public void Embaralhador()
    {
        
        for (int i = 0; i < posicoesCartas.Count; i++)
        {
            int rnd = Random.Range(0, bm.cartasDisponiveis.Count);            
            posicoesCartas[i].GetComponent<Image>().sprite = bm.cartasDisponiveis[rnd].GetComponent<SpriteRenderer>().sprite;
            
        }
        



    }


}
