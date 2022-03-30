using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class SlotCanhao : MonoBehaviour, IDropHandler
{

    [SerializeField] private RectTransform _transform;
    public Baralho baralho;
    public BancoDeMunicoes bm;

    public GameObject canhao;
    public GameObject saidaCanhao;
    public float podeAtirar_;
    float velocidadeTiro_;
    [SerializeField] ControleCanhao controleCanhao;
    [SerializeField] Municao municao;



    // Start is called before the first frame update
    void Start()
    {
        _transform = this.GetComponent<RectTransform>();

    }
    private void Update()
    {
        velocidadeTiro_ = controleCanhao.velocidadeTiro;
        podeAtirar_ = controleCanhao.podeAtirar;

    }

    public void OnDrop(PointerEventData eventData)
    {
        
        string nomeCarta = eventData.pointerDrag.GetComponent<Image>().sprite.name;
        if (podeAtirar_ >= velocidadeTiro_)
        {
            controleCanhao.podeAtirar = 0;
            eventData.pointerDrag.GetComponent<Image>().sprite = null;
            baralho.podebaralhar += 1;
            if (name == "canhao1")
            {
                bm.nCanhao = 0;
                canhao.transform.DORotate(new Vector3(0, 0, 0), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta); });
                Debug.Log("seguir caminho 1");
            }
            if (name == "canhao2")
            {
                bm.nCanhao = 15;
                canhao.transform.DORotate(new Vector3(0, 0, 15), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta); });
                Debug.Log("seguir caminho 2");
            }
            if (name == "canhao3")
            {
                bm.nCanhao = 45;
                canhao.transform.DORotate(new Vector3(0, 0, 45), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta); });
                Debug.Log("seguir caminho 3");
            }


        }


    }
    public void Atirar(string nomeCarta_)
    {

        if (nomeCarta_ == "escudo(carta)")
        {
            
            Instantiate(bm.municoesDisponiveis[0], saidaCanhao.transform);
            
        }
        if (nomeCarta_ == "broca(carta)")
        {
            
            Instantiate(bm.municoesDisponiveis[1], saidaCanhao.transform);
            
        }
        if (nomeCarta_ == "bolaFerro(carta)")
        {
            
            Instantiate(bm.municoesDisponiveis[2], saidaCanhao.transform);
            
        }

    }
    

}
