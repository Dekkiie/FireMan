using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float hp;
    private bool estaPrecionado;
    private bool estaApagado;


    private void OnMouseDown()
    {
        estaPrecionado = true;
    }
    private void OnMouseUp()
    {
        estaPrecionado = false;
    }
    private void Update()
    {
        if (estaPrecionado == true)
        {
            hp -= GameManager.gm.fuerzaChorro;

        }
        if(hp <= 0 && estaApagado == false)
        {
            //efectoVapor
            //seapago 
            //desactivarSpriteFuego
            estaApagado = true;
        }
    }
}
