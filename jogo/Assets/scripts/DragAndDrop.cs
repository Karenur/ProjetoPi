using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _transform;
    [SerializeField] private CanvasGroup _canvasGroup;
    

    //public Baralho baralho;
    public Vector2 posInicial;

    private void Start()
    {
        _transform = this.GetComponent<RectTransform>();
        _canvasGroup = this.GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;     


    }
    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        posInicial = _transform.anchoredPosition;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _transform.anchoredPosition = posInicial;
        
    }
}
