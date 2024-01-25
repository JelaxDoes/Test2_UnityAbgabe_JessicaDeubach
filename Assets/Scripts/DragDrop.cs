using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isBeingDragged = false;
    private Rigidbody rb;
    private Camera mainCamera;
    private AudioSource audioSource;
    private GameManager GameManager;

    public bool IsWashed { get; private set; } = false;

    public Color washedColor = Color.red; // Farbe, wenn der Apfel gewaschen wurde
    public AudioClip washSound; // Sound, wenn der Apfel gewaschen wird
    public AudioClip placeInBasketSound; // Sound, wenn der Apfel im Korb platziert wird
    public AudioClip notWashedSound; // Sound, wenn der Apfel nicht gewaschen wurde

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        GameManager = FindObjectOfType<GameManager>();

        mainCamera = Camera.main;

        // Füge eine AudioSource-Komponente hinzu
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnMouseDown()
    {
        isBeingDragged = true;
        rb.isKinematic = false;
    }

    void OnMouseUp()
    {
        isBeingDragged = false;
        rb.isKinematic = true;

        if (!IsWashed)
        {
            Debug.Log("The apple needs to be washed before placing it in the basket.");

            // Spiele den Sound ab, wenn der Apfel nicht gewaschen wurde
            if (notWashedSound != null)
            {
                audioSource.clip = notWashedSound;
                audioSource.Play();
                GameManager.IncreaseScore(-1);

            }
        }
        else
        {
            Debug.Log("Great!");
           
                audioSource.clip = placeInBasketSound;
                audioSource.Play();
                GameManager.IncreaseScore(10);
        }
    }

    void Update()
    {
        if (isBeingDragged)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, transform.position);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 targetPosition = ray.GetPoint(distance);
                targetPosition.y = Mathf.Clamp(targetPosition.y, 0.5f, 5f);
                rb.MovePosition(targetPosition);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            if (IsWashed)
            {
                Debug.Log("Apple placed in the basket!");

                
            }
            else
            {
                Debug.Log("The apple needs to be washed before placing it in the basket.");

                
            }
        }
        else if (other.CompareTag("WaterBasin"))
        {
            Debug.Log("Apple entered water basin");
            WashApple();
        }
    }

    void WashApple()
    {
        IsWashed = true;

        // Hier wird das Material direkt am MeshFilter des Child-Objekts aktualisiert
        MeshFilter childMeshFilter = GetComponentInChildren<MeshFilter>();
        if (childMeshFilter != null && childMeshFilter.sharedMesh != null)
        {
            Material material = childMeshFilter.GetComponent<Renderer>().material;
            material.color = washedColor;
            childMeshFilter.GetComponent<Renderer>().material = material;
        }

        Debug.Log("The apple is now washed and has changed color!");

        // Spiele den Sound ab, wenn der Apfel gewaschen wird
        if (washSound != null)
        {
            audioSource.clip = washSound;
            audioSource.Play();
        }
    }
}

