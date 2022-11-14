using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarDireccion : MonoBehaviour
{
    private void Update()
    {
        RotarObjeto();
    }

    void RotarObjeto()
    {
        transform.up = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
}
