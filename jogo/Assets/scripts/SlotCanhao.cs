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
        
        if(nomeCarta == "bolaFerro")
        {
            Instantiate(bm.cartasDisponiveis[0], canhao.transform);

        }
        if (nomeCarta == "broca")
        {
            Instantiate(bm.cartasDisponiveis[1], canhao.transform);

        }
        if (nomeCarta == "escudo")
        {
            Instantiate(bm.cartasDisponiveis[2], canhao.transform);

        }


        eventData.pointerDrag.GetComponent<Image>().sprite = null;
        baralho.podebaralhar += 1;
        
    }
}
