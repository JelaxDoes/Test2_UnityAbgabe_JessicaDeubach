using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

    public int numberOfVisibleApples = 5; // Anzahl der sichtbaren �pfel

    void Start()
    {
        ActivateRandomApples();
    }

    void ActivateRandomApples()
    {
        // Finde alle �pfel im Spiel
        GameObject[] allApples = GameObject.FindGameObjectsWithTag("Apple");

        // Aktiviere zuf�llige Anzahl von �pfeln
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
            material.color = Random.ColorHSV(); // Setze zuf�llige Farbe
            meshRenderer.material = material;
        }
    }
}

   

