using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionDelDedo : MonoBehaviour
{
    public Vector3 posicionDedo;
    bool seApreto;

    private void Update()
    {
        if (seApreto)
        {
            if (Input.touchCount > 0)
            {
                posicionDedo = Input.GetTouch(0).position;
                posicionDedo.z = Mathf.Abs(Camera.main.transform.position.z);
                Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(posicionDedo);
                transform.position = posicionDedo;
            }
        }

        
    }
    private void OnMouseDown()
    {
        seApreto = true;
    }
    private void OnMouseUp()
    {
        seApreto = false;
    }
}
