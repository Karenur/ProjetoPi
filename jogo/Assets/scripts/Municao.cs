using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{

    public float tempoVida;
    float tempo = 0;

    public Rigidbody2D rbMunicao;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rbMunicao.AddForce(new Vector2(1000,0));
        
    }

    // Update is called once per frame
    void Update()
    {
        
        tempo += Time.deltaTime;
        if ( tempo >= tempoVida)
        {
            Destroy(this.gameObject);
        }


    }
     

    


}
