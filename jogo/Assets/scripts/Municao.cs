using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Municao : MonoBehaviour
{

    public float MultiplicadorForcaTiro;
    public float forcaTiro;
    public string slotCanhao;
    public string alvo;
    public float dano;
    [SerializeField] GameObject fraqueza;
    public Rigidbody2D rbMunicao;
    public Vector3[] caminho;

    [SerializeField]public int _canhaoUsado;

    // Start is called before the first frame update
    void Start()
    {
        
        this.gameObject.transform.SetParent(null);
        this.rbMunicao = GetComponent<Rigidbody2D>();
        this.gameObject.name = (this.gameObject.name+" ");  
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public  Vector3[] EscolherCaminho(int nCanhao)
    {
        switch (nCanhao)
        {
            case 1:

                caminho[1] = GameObject.Find("Caminho0 (1)").transform.position;
                caminho[2] = GameObject.Find("Caminho0").transform.position;
                caminho[3] = GameObject.Find("Caminho0 (2)").transform.position;
                MultiplicadorForcaTiro = 1f;
                Seguir();
                break;
            case 2:
                caminho[1] = GameObject.Find("Caminho15 (1)").transform.position;
                caminho[2] = GameObject.Find("Caminho15").transform.position;
                caminho[3] = GameObject.Find("Caminho15 (2)").transform.position;
                MultiplicadorForcaTiro = 1.2f;
                Seguir();
                break;
            case 3:
                caminho[1] = GameObject.Find("Caminho45 (1)").transform.position;
                caminho[2] = GameObject.Find("Caminho45").transform.position;
                caminho[3] = GameObject.Find("Caminho45 (2)").transform.position;
                MultiplicadorForcaTiro = 1.5f;
                Seguir();
                break;

            default:
                Seguir();
                break;
        }
        _canhaoUsado = nCanhao;
        return caminho;
    }

    
    public virtual void Seguir()
    {
        
        transform.DOPath(caminho, forcaTiro *= MultiplicadorForcaTiro, PathType.CatmullRom, PathMode.Sidescroller2D).SetLookAt(0.01f);
    }

    public string EscolherAlvo(string alvo_)
    {
        return alvo;
    }    
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == alvo)
        {
            collision.GetComponent<ControleVida>().LevarDano(dano);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == fraqueza.gameObject.tag)
        {
            Debug.Log($"acertei fraqueza {collision.name}");
            transform.DOPause();
            
            rbMunicao.velocity = Vector2.zero;
            rbMunicao.gravityScale = 1;
        }
        Debug.Log($"acertei {collision.name}");
    }
}
