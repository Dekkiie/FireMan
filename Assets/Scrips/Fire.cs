using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float hp;
    private bool estaPrecionado;
    private bool estaApagado;
    [SerializeField] private float duracionFuego,cambioFase;
    public GameObject fuego, humo;
    public BoxCollider2D col;
    public Animator anim;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();

    }
    
    
    private void Update()
    {
        
       
        FuegoHit();
        
    }
    public void WaterDrop()
    {
        estaPrecionado = true;
    }
    public void FuegoHit()
    {
        if(estaApagado == false) { hp += GameManager.gm.fuegoSubiendo; }
        

        if(hp > duracionFuego && estaApagado == false)
        {
            hp = duracionFuego;
        }
        if(hp > cambioFase)
        {
            anim.Play("Fire_lvl_2");
        }
        
        if (estaPrecionado == true)
        {
            hp -= GameManager.gm.fuerzaChorro;

        }
        if (hp <= 0 && estaApagado == false)
        {
            hp = -1;
            //seapago 
            fuego.SetActive(false);
            //efectoVapor
            humo.SetActive(true);
            //desactivarCollider
            col.enabled = false;
            estaApagado = true;
        }
        estaPrecionado = false;
    }
}
