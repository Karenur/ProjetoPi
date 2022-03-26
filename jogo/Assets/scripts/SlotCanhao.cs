using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotCanhao : MonoBehaviour, IDropHandler
{
    public DragAndDrop da;
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
        //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _transform.anchoredPosition;
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

        if (nomeCarta == "bolaFerro")
        {
            Instantiate(bm.cartasDisponiveis[0], saidaCanhao.transform);

        }
        if (nomeCarta == "broca")
        {
            Instantiate(bm.cartasDisponiveis[1], saidaCanhao.transform);

        }
        if (nomeCarta == "escudo")
        {
            Instantiate(bm.cartasDisponiveis[2], saidaCanhao.transform);

        }


        eventData.pointerDrag.GetComponent<Image>().sprite = null;
        baralho.podebaralhar += 1;
        
    }
}
