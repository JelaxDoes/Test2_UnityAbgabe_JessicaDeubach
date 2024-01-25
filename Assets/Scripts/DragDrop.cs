using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isBeingDragged = false;
    private Rigidbody rb;
    private Renderer appleRenderer;
    private Camera mainCamera;

    private bool isWashed = false;

    public Color washedColor = Color.red; // Farbe, wenn der Apfel gewaschen wurde

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        mainCamera = Camera.main;

        appleRenderer = GetComponent<Renderer>();
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

        if (!isWashed)
        {
            Debug.Log("The apple needs to be washed before placing it in the basket.");
        }
        else
        {
            Debug.Log("The apple is washed and can be placed in the basket.");
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
            if (isWashed)
            {
                Debug.Log("Apple placed in the basket!");
                Destroy(gameObject); // Hier könntest du das GameObject deaktivieren oder zerstören
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
        isWashed = true;
        appleRenderer.material.color = washedColor;
        Debug.Log("The apple is now washed and has changed color!");
    }
}
