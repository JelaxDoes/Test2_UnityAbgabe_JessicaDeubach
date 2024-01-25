using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float fallDelay = 5f; // Verzögerung, nach der der Apfel fallen soll

    void Start()
    {
        Invoke("Fall", fallDelay); // Ruft die Methode "Fall" nach der Verzögerung auf
    }

    void Fall()
    {
        // Aktiviert Physik
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    // Äpfel fallen runter aber fallen durch den Boden. Icvh hab versucht das auszubessern aber es ging nicht. Deshalb hab ich die Zeit nachder die runter fallen erhöht 
}

