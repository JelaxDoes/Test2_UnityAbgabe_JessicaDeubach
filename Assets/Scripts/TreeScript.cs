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
        // Durchlaufe alle Kinder des Baumes
        foreach (Transform child in transform)
        {
            // �berpr�fe, ob das Kind ein Apfel ist
            if (child.CompareTag("Apple"))
            {
                // Aktiviere zuf�llige Anzahl von �pfeln
                child.gameObject.SetActive(Random.Range(0, 100) < numberOfVisibleApples);

                // Wenn aktiviert, wird die Farbe im Apple-Skript festgelegt
            }
        }
    }
}

   

