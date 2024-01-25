using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            // Hier k�nntest du zus�tzliche Logik f�r die Platzierung des Apfels in der Schale hinzuf�gen
            Debug.Log("Apfel in der Schale!");
            Destroy(other.gameObject); // Entferne den Apfel, wenn er in die Schale gelegt wird
        }
    }
}
