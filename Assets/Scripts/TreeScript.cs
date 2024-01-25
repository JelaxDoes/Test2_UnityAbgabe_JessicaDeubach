using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

    public int numberOfVisibleApples = 5; // Anzahl der sichtbaren �pfel. Je nachdem wie viele �pfel es sind muss der zu erreichende Score im GameManager angepasst werden

    void Start()
    {
        ActivateRandomApples();
    }

    void ActivateRandomApples()
    {
        
        GameObject[] allApples = GameObject.FindGameObjectsWithTag("Apple");

        // Aktiviert zuf�llige Anzahl von �pfeln
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
            material.color = Random.ColorHSV(); // Setzt zuf�llige Farbe
            meshRenderer.material = material;
        }
    }
}

   

