using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{

    public float tempo;
    [SerializeField] private Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1000,0));
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
       if(tempo >= 5)
        {
            Destroy(this.gameObject);
        }


    }
     

    


}
