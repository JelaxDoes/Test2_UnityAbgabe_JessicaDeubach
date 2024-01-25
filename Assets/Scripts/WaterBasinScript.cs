using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBasinScript : MonoBehaviour
{
    private int dippedApplesCount = 0;
    public Color greenColor = Color.green;
    public Color defaultColor = Color.blue;
    public GameObject waterObject;
    private Material waterMaterial;

    void Start()
    {
        waterMaterial = waterObject.GetComponent<Renderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            dippedApplesCount++;

            // Ändert die Farbe des Wassers, wenn drei Äpfel eingetaucht sind
            if (dippedApplesCount == 3)
            {
                waterMaterial.color = greenColor;
                Debug.Log("Water turned green!");
            }
        }
    }

    void OnMouseDown()
    {
        waterMaterial.color = defaultColor;
        Debug.Log("Water has been cleaned");
    }
}
