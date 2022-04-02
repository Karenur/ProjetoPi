using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Municao : MonoBehaviour
{
    

    public float forcaTiro;
    public string slotCanhao;
    
    public Rigidbody2D rbMunicao;
    public Vector3[] caminho;

    [SerializeField]public int _canhaoUsado;

    // Start is called before the first frame update
    void Start()
    {
        
        this.gameObject.transform.SetParent(null);
        this.rbMunicao = GetComponent<Rigidbody2D>();
        this.gameObject.name = (this.gameObject.name+" ");
        caminho[0] = GameObject.Find("saidaTiro").transform.position;
        caminho[4] = GameObject.Find("inimigo").transform.position;
        EscolherCaminho(_canhaoUsado);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void EscolherCaminho(int nCanhao)
    {
        switch (nCanhao)
        {
            case 1:

                caminho[1] = GameObject.Find("Caminho0 (1)").transform.position;
                caminho[2] = GameObject.Find("Caminho0").transform.position;
                caminho[3] = GameObject.Find("Caminho0 (2)").transform.position;
                Seguir();
                break;
            case 2:
                caminho[1] = GameObject.Find("Caminho15 (1)").transform.position;
                caminho[2] = GameObject.Find("Caminho15").transform.position;
                caminho[3] = GameObject.Find("Caminho15 (2)").transform.position;                
                Seguir();
                break;
            case 3:
                caminho[1] = GameObject.Find("Caminho45 (1)").transform.position;
                caminho[2] = GameObject.Find("Caminho45").transform.position;
                caminho[3] = GameObject.Find("Caminho45 (2)").transform.position;                
                Seguir();
                break;

            default:
                break;
        }
        _canhaoUsado = nCanhao;

    }

    
    void Seguir()
    {
        transform.DOPath(caminho, forcaTiro, PathType.CatmullRom, PathMode.Sidescroller2D).OnComplete(() => { Destroy(this.gameObject); }) ;
    }
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Inimigo")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

}
