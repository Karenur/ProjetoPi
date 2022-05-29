using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SlotCanhao : MonoBehaviour, IDropHandler
{
    public List<AudioSource> sonsTiro;
    [SerializeField] private RectTransform _transform;
    public Baralho baralho;
    public BancoDeMunicoes bm;
    [SerializeField] ControleCanhao controleCanhao;
    [SerializeField] Municao municao;

    public GameObject canhao;
    public GameObject saidaCanhao;
    public float podeAtirar_;
    float velocidadeTiro_;




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
        if (nomeCarta != "carta_verso")
        {
            if (podeAtirar_ >= velocidadeTiro_)
            {
                int canhaoUsado;
                controleCanhao.podeAtirar = 0;
                eventData.pointerDrag.GetComponent<Image>().sprite = bm.spriteVersoCarta;
                baralho.podebaralhar += 1;
                if (name == "canhao1")
                {
                    canhaoUsado = 1;
                    canhao.transform.DORotate(new Vector3(0, 0, 5), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta, canhaoUsado); });
                                     

                }
                if (name == "canhao2")
                {
                    canhaoUsado = 2;
                    canhao.transform.DORotate(new Vector3(0, 0, 25), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta, canhaoUsado); });
                    
                    
                }
                if (name == "canhao3")
                {
                    canhaoUsado = 3;
                    canhao.transform.DORotate(new Vector3(0, 0, 45), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta, canhaoUsado); });
                    
                                       
                }


            }
        }


    }
    
    public void Atirar(string nomeCarta_, int slotCanhao_)
    {
        
        if (nomeCarta_ == "escudo(carta)")
        {
            sonsTiro[2].Play();
            GameObject municaoAtirada = Instantiate(bm.municoesDisponiveis[0], saidaCanhao.transform).gameObject;
            municaoAtirada = DefinirCaminhoEAlvo(municaoAtirada, slotCanhao_, "Inimigo");
            
        }
        if (nomeCarta_ == "lanca(carta)")
        {
            sonsTiro[0].Play();
            GameObject municaoAtirada = Instantiate(bm.municoesDisponiveis[1], saidaCanhao.transform).gameObject;
            municaoAtirada = DefinirCaminhoEAlvo(municaoAtirada, slotCanhao_, "Inimigo");
            
        }
        if (nomeCarta_ == "bolaFerro(carta)")
        {
            sonsTiro[1].Play();
            GameObject municaoAtirada = Instantiate(bm.municoesDisponiveis[2], saidaCanhao.transform).gameObject;
            municaoAtirada = DefinirCaminhoEAlvo(municaoAtirada,slotCanhao_,"Inimigo");
           
        }        
    }
    public GameObject DefinirCaminhoEAlvo(GameObject municaoAtirada_, int slotCanhao_, string alvo)
    {
        municaoAtirada_.GetComponent<Municao>().caminho[0] = GameObject.Find("saidaTiro").transform.position;
        municaoAtirada_.GetComponent<Municao>().caminho[4] = GameObject.Find("PontoAlvoInimigo").transform.position;
        municaoAtirada_.GetComponent<Municao>().EscolherCaminho(slotCanhao_);
        municaoAtirada_.GetComponent<Municao>().alvo = "Inimigo";
        return municaoAtirada_;
    }

}
