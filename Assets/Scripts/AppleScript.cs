using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
   

    void Start()
    {
        if (gameObject.activeSelf)
        {
            SetRandomColor();
          
        }
    }

    void SetRandomColor()
    {
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer != null)
        {
            Material material = new Material(meshRenderer.sharedMaterial);
            material.color = Random.ColorHSV();
            meshRenderer.material = material;
        }
    }

    }

   


