using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Municao : MonoBehaviour
{
    [SerializeField]GameObject bancoMunicoa_;
    BancoDeMunicoes bancoMunicao;
    
    public Rigidbody2D rbMunicao;
    public Vector3[] caminho;

    // Start is called before the first frame update
    void Start()
    {
        bancoMunicoa_ = GameObject.Find("bancoMunicoes");
        bancoMunicao = bancoMunicoa_.GetComponent<BancoDeMunicoes>();
        EscolherCaminho(bancoMunicao.nCanhao);
        
        this.gameObject.transform.SetParent(null);
        caminho[0] = bancoMunicao.saidaCanhao.position;
        caminho[2] = bancoMunicao.Inimigo.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EscolherCaminho(int nCanhao)
    {
        switch (nCanhao)
        {
            case 0:
                SeguirCaminho0();
                break;
            case 15:
                SeguirCaminho15();
                break;
            case 45:
                SeguirCaminho45();
                break;

            default:
                break;
        }


    }

    public void SeguirCaminho0()
    {
        caminho[1] = bancoMunicao.weyPoints1.transform.localPosition;
        transform.DOPath(caminho, 2, PathType.CatmullRom, PathMode.Sidescroller2D);
        Debug.Log("usando caminho 1");
        
    }
    public void SeguirCaminho15()
    {
        caminho[1] = bancoMunicao.weyPoints2.transform.localPosition;
        transform.DOPath(caminho, 2, PathType.CatmullRom, PathMode.Sidescroller2D);
        Debug.Log("usando caminho 2");
        
    }
    public void SeguirCaminho45()
    {
        caminho[1] = bancoMunicao.weyPoints3.transform.localPosition;
        transform.DOPath(caminho, 2, PathType.Linear, PathMode.Ignore);
        Debug.Log("usando caminho 3");
    }





}
