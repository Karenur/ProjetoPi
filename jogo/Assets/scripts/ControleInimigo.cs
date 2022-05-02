using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour
{

    [SerializeField]Vector3[] caminho_Inimigo;
    [SerializeField]Transform saidaCanhaoInimigo;
    [SerializeField] BancoDeMunicoes bm;
    [SerializeField] GameObject canhaoInimigo;
    [SerializeField] Transform jogador;
    public ControleVida controleVida;


    [SerializeField] float cadenciaTiro;
    [SerializeField] float cadenciaTiroMaximo;
    [SerializeField] float velocidadeMunicao;

    // Start is called before the first frame update
    void Start()
    {
        caminho_Inimigo[0] = saidaCanhaoInimigo.position;
        caminho_Inimigo[4] = jogador.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controleVida.VidaAtual > 0)
        {
            if (cadenciaTiro <= cadenciaTiroMaximo)
            {
                cadenciaTiro += Time.deltaTime;
            }
            if (cadenciaTiro >= cadenciaTiroMaximo)
            {
                int rnd = Random.Range(1, 4);
                EscolherCaminho(rnd);
            }
        }
    }

    public Vector3[] EscolherCaminho(int nCanhao)
    {
        cadenciaTiro = 0;
        switch (nCanhao)
        {
            case 1:

                caminho_Inimigo[1] = GameObject.Find("Caminho0 (2)").transform.position;
                caminho_Inimigo[2] = GameObject.Find("Caminho0").transform.position;
                caminho_Inimigo[3] = GameObject.Find("Caminho0 (1)").transform.position;
               
                this.canhaoInimigo.transform.DORotate(new Vector3(0, 0, -10), 1, RotateMode.Fast).OnComplete(() => { this.Atirar(); });


                break;
            case 2:
                caminho_Inimigo[1] = GameObject.Find("Caminho15 (2)").transform.position;
                caminho_Inimigo[2] = GameObject.Find("Caminho15").transform.position;
                caminho_Inimigo[3] = GameObject.Find("Caminho15 (1)").transform.position;
               
                this.canhaoInimigo.transform.DORotate(new Vector3(0, 0, -30), 1, RotateMode.Fast).OnComplete(() => { this.Atirar(); });
                break;
            case 3:
                caminho_Inimigo[1] = GameObject.Find("Caminho45 (2)").transform.position;
                caminho_Inimigo[2] = GameObject.Find("Caminho45").transform.position;
                caminho_Inimigo[3] = GameObject.Find("Caminho45 (1)").transform.position;                
                
                this.canhaoInimigo.transform.DORotate(new Vector3(0, 0, -45), 1, RotateMode.Fast).OnComplete(() => { this.Atirar(); });
                break;

            default:
                break;
        }        
        return caminho_Inimigo;
    }
    void Atirar()
    {        
        int rnd = Random.Range(0, bm.municoesDisponiveis.Count);
        GameObject municaoAtirada = Instantiate(bm.municoesDisponiveis[rnd], this.saidaCanhaoInimigo.transform);
        municaoAtirada.GetComponent<Municao>().caminho = caminho_Inimigo;
        municaoAtirada.GetComponent<Municao>().Seguir();
        municaoAtirada.GetComponent<Municao>().alvo = "Player";
    }

    

}
