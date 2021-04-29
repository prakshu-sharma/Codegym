using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SunPoints : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI sunpoint_text;
    public float sunPoint_value=100;
    public int Increasing_value = 1;
    bool isDay = true;
    public static SunPoints instance;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    private void Start()
    {
        sunpoint_text = gameObject.GetComponent<TextMeshProUGUI>();
        if (sunpoint_text == null)
        {
            Debug.Log("Not got");
        }
        else
        {
            Debug.Log("GOT");
        }
    }
    private void Update()
    {
        if (isDay)
        {
            sunPoint_value += Increasing_value * Time.deltaTime;
            sunpoint_text.text = sunPoint_value.ToString("0");
        }
    }
    public void ChangePoints(int Change)
    {
        sunPoint_value -= Change;
        sunpoint_text.text = sunPoint_value.ToString("0");
    }
}
