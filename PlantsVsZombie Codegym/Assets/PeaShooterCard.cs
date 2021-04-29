using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeaShooterCard : MonoBehaviour, IDragHandler ,IPointerDownHandler , IPointerUpHandler
{
    public GameObject Draging_Pea;
    public GameObject Planted_Pea;
    public Canvas canvas;
    private GameObject DragPeaInstance;
    private GameManager gameManager;
    //Start menu
    public void Start()
    {
        gameManager = GameManager.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        DragPeaInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DragPeaInstance = Instantiate(Draging_Pea, canvas.transform);
        DragPeaInstance.transform.position = Input.mousePosition;
        DragPeaInstance.GetComponent<PlantDragging>().card = this;

        gameManager.Drag_Plant = DragPeaInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.PlacePlant();
        gameManager.Drag_Plant = null;
        Destroy(DragPeaInstance);
    }
}
