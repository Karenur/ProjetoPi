using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SlotCanhao : MonoBehaviour, IDropHandler
{

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
                    canhao.transform.DORotate(new Vector3(0, 0, 10), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta, canhaoUsado); });
                    Debug.Log("seguir caminho 1");


                }
                if (name == "canhao2")
                {
                    canhaoUsado = 2;
                    canhao.transform.DORotate(new Vector3(0, 0, 30), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta, canhaoUsado); });
                    Debug.Log("seguir caminho 2");

                }
                if (name == "canhao3")
                {
                    canhaoUsado = 3;
                    canhao.transform.DORotate(new Vector3(0, 0, 45), velocidadeTiro_, RotateMode.Fast).OnComplete(() => { Atirar(nomeCarta, canhaoUsado); });
                    Debug.Log("seguir caminho 3");

                }


            }
        }


    }
    public void Atirar(string nomeCarta_, int slotCanhao_)
    {

        if (nomeCarta_ == "escudo(carta)")
        {
            Instantiate(bm.municoesDisponiveis[0], saidaCanhao.transform);
            Debug.Log("Usando " + slotCanhao_);
            municao = GameObject.Find(bm.municoesDisponiveis[0].name + "(Clone)").GetComponent<Municao>();
        }
        if (nomeCarta_ == "lanca(carta)")
        {
            Instantiate(bm.municoesDisponiveis[1], saidaCanhao.transform);
            Debug.Log("Usando " + slotCanhao_);
            municao = GameObject.Find(bm.municoesDisponiveis[1].name + "(Clone)").GetComponent<Municao>();            
        }
        if (nomeCarta_ == "bolaFerro(carta)")
        {

            Instantiate(bm.municoesDisponiveis[2], saidaCanhao.transform);
            Debug.Log("Usando " + slotCanhao_);
            municao = GameObject.Find(bm.municoesDisponiveis[2].name + "(Clone)").GetComponent<Municao>();
        }

        Debug.Log("Atire " + municao.name);
        municao._canhaoUsado = slotCanhao_;
    }

}
