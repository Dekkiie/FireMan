using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float hp;
    private bool estaPrecionado;
    private bool estaApagado;
    public GameObject fuego, humo;
    public BoxCollider2D col;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }
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
            //seapago 
            fuego.SetActive(false);
            //efectoVapor
            humo.SetActive(true);
            //desactivarCollider
            col.enabled = false;
            estaApagado = true;
        }
    }
}
