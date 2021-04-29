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
    public int PurchaseValue;
    private SunPoints sunman;



    public void Start()
    {
        gameManager = GameManager.instance;
        sunman = SunPoints.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (gameManager.Drag_Plant.GetComponent<PlantDragging>().card.PurchaseValue <= sunman.GetComponent<SunPoints>().sunPoint_value)
        {
            DragPeaInstance.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(GetComponent<SunPoints>().sunPoint_value);
        //if (gameManager.Drag_Plant.GetComponent<PlantDragging>().card.PurchaseValue <= sunman.GetComponent<SunPoints>().sunPoint_value)
        //{
            DragPeaInstance = Instantiate(Draging_Pea, canvas.transform);
            DragPeaInstance.transform.position = Input.mousePosition;
            DragPeaInstance.GetComponent<PlantDragging>().card = this;

            gameManager.Drag_Plant = DragPeaInstance;
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(sunman.sunPoint_value);//GetComponent<SunPoints>().sunPoint_value);
        if (gameManager.Drag_Plant.GetComponent<PlantDragging>().card.PurchaseValue <= sunman.sunPoint_value)//GetComponent<SunPoints>().sunPoint_value)
        {
            gameManager.PlacePlant(gameManager.Drag_Plant.GetComponent<PlantDragging>().card.PurchaseValue);
            gameManager.Drag_Plant = null;
            Destroy(DragPeaInstance);
            //sunman.GetComponent<SunPoints>()
            //sunman.ChangePoints(gameManager.Drag_Plant.GetComponent<PlantDragging>().card.PurchaseValue);
        }
        else
        {
            gameManager.Drag_Plant = null;
            Destroy(DragPeaInstance);
        }
    }
}
