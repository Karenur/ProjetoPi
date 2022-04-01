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

    [SerializeField]string _canhaoUsado;

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
        caminho[0] = GameObject.Find("saidaTiro").transform.position;
        caminho[4] = GameObject.Find("inimigo").transform.position;
    }
    public void EscolherCaminho(int nCanhao)
    {
        switch (nCanhao)
        {
            case 1:
                SeguirCaminho1();
                break;
            case 2:
                SeguirCaminho2();
                break;
            case 3:
                SeguirCaminho3();
                break;

            default:
                break;
        }


    }

    public void SeguirCaminho1()
    {
        caminho[1] = GameObject.Find("Caminho0 (1)").transform.position;
        caminho[2] = GameObject.Find("Caminho0").transform.position;        
        caminho[3] = GameObject.Find("Caminho0 (2)").transform.position;
        transform.DOPath(caminho, forcaTiro, PathType.CatmullRom, PathMode.TopDown2D);
        
        Debug.Log("usando caminho 1");
        
    }
    public void SeguirCaminho2()
    {
        caminho[1] = GameObject.Find("Caminho15 (1)").transform.position;
        caminho[2] = GameObject.Find("Caminho15").transform.position;        
        caminho[3] = GameObject.Find("Caminho15 (2)").transform.position;
        transform.DOPath(caminho, forcaTiro, PathType.CatmullRom, PathMode.Sidescroller2D);
        
        Debug.Log("usando caminho 2");
        
    }
    public void SeguirCaminho3()
    {
        caminho[1] = GameObject.Find("Caminho45 (1)").transform.position;
        caminho[2] = GameObject.Find("Caminho45").transform.position;        
        caminho[3] = GameObject.Find("Caminho45 (2)").transform.position;
        transform.DOPath(caminho, forcaTiro, PathType.CatmullRom, PathMode.Sidescroller2D);
        //rbMunicao.gravityScale = 1;
        //rbMunicao.AddForce(new Vector2(forcaTiro, forcaTiro) / 2);
        Debug.Log("usando caminho 3");
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Inimigo")
        {
            Destroy(this.gameObject);
        }
    }

}
