using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotCanhao : MonoBehaviour, IDropHandler
{
    
    [SerializeField] private RectTransform _transform;
    public Baralho baralho;
    public BancoDeMunicoes bm;
   

    public GameObject canhao;
    public GameObject saidaCanhao;


    // Start is called before the first frame update
    void Start()
    {
        _transform = this.GetComponent<RectTransform>();
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        string nomeCarta = eventData.pointerDrag.GetComponent<Image>().sprite.name;

       

        Debug.Log($"atirei {nomeCarta}");
        Debug.Log($"usando o {this.name} ");
        

        if (name == "canhao1")
        {
            canhao.transform.rotation = Quaternion.Euler(0,0,0);            
        }
        if (name == "canhao2")
        {
           canhao.transform.rotation = Quaternion.Euler(0,0,15);
        }
        if (name == "canhao3")
        {
            canhao.transform.rotation = Quaternion.Euler(0,0,45);
        }
        if (nomeCarta == "escudo(carta)")
        {
            Instantiate(bm.municoesDisponiveis[0], saidaCanhao.transform);

        }
        if (nomeCarta == "broca(carta)")
        {
            Instantiate(bm.municoesDisponiveis[1], saidaCanhao.transform);

        }
        if (nomeCarta == "bolaFerro(carta)")
        {
            Instantiate(bm.municoesDisponiveis[2], saidaCanhao.transform);

        }  
        


        eventData.pointerDrag.GetComponent<Image>().sprite = null;
        baralho.podebaralhar += 1;       
        
    }
    public void atirar()
    {
        
        Debug.Log("atira");
        Instantiate(bm.municoesDisponiveis[0], saidaCanhao.transform);

    }

}
