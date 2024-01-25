using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

    public int numberOfVisibleApples = 5; // Anzahl der sichtbaren Äpfel. Je nachdem wie viele Äpfel es sind muss der zu erreichende Score im GameManager angepasst werden

    void Start()
    {
        ActivateRandomApples();
    }

    void ActivateRandomApples()
    {
        
        GameObject[] allApples = GameObject.FindGameObjectsWithTag("Apple");

        // Aktiviert zufällige Anzahl von Äpfeln
        int visibleApplesCount = 0;
        foreach (GameObject apple in allApples)
        {
            MeshRenderer meshRenderer = apple.GetComponentInChildren<MeshRenderer>();

            if (visibleApplesCount < numberOfVisibleApples && Random.Range(0f, 1f) < 0.5f)
            {
                apple.SetActive(true);
                SetRandomColor(meshRenderer);
                visibleApplesCount++;
            }
            else
            {
                apple.SetActive(false);
            }
        }
    }

    void SetRandomColor(MeshRenderer meshRenderer)
    {
        if (meshRenderer != null)
        {
            Material material = new Material(meshRenderer.sharedMaterial);
            material.color = Random.ColorHSV(); // Setzt zufällige Farbe
            meshRenderer.material = material;
        }
    }
}

   

