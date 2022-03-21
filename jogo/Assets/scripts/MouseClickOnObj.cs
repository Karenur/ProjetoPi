using UnityEngine;

public class MouseClickOnObj : MonoBehaviour
{
    /*
        *** USAR ESSE SCRIPT NA CAMERA ***

        ** OBJ que for atingido pelo rayCast precisa ter um Collider2D exemplo: boxCollider2D, 
        circleCollider2D e etc, para poder ser movido na cena pelo mouse/touch.
        
        ** Também é preciso criar uma Layer no Inspector para identificar qual obj de interação,
        com o mouse. Exemplo: Layer -> Drag.
        Depois adicionar Layer aos objs que forem movidos pelo mouse.
    */

    [Tooltip("OBJ que pode ser movido na cena")]
    [SerializeField] private Transform obj;       // obj que vai ser movido na cena
    private bool _drag;                         // indica que pode mover o obj
    private Vector2 _mouse;                     // atributos do mouse
    private RaycastHit2D hit;                   // recebe ray que vai atingir gameObject
    private Vector2 _offset;                    // Offset entre player e mouse

    [Header("Layer de Interação")]
    [SerializeField] private LayerMask _layer;   // layer que vai ser detectada pelo rayCast

    void Start()
    {

    }

    void Update()
    {

        _mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // pega posição do mouse no espaço da tela
        hit = Physics2D.Raycast(_mouse, Vector2.zero, 0f, _layer);

        follow();   // metodo que faz obj seguir mouse/touch

    }

    void follow()
    {

        if (Input.GetMouseButton(0) && hit && !_drag)
        {

            _drag = true;                                               // pode mover mouse/touch com o obj

            obj = hit.transform;                                        // atribui obj atingido pelo rayCast para a referencia

            // subtração para criar offset, onde o ponto sobre o obj é a referencia para ser arrastada pelo mouse
            float _x = obj.transform.position.x - _mouse.x;
            float _y = obj.transform.position.y - _mouse.y;

            _offset = new Vector2(_x, _y);

        }

        if (_drag)
        {
            obj.transform.position = _mouse + _offset;  // permite mover obj na cena
            //Debug.Log(hit.collider.name);
        }

        if (Input.GetMouseButtonUp(0) && _drag)
        {         // se não tiver clicando solta o obj
            obj = null;
            _drag = false;
            _offset = new Vector2(0f, 0f);
        }
    }

}