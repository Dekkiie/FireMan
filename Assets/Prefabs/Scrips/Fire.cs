using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float hp;
    private bool estaPrecionado;
    private bool estaApagado,cambio;
    [SerializeField] private float duracionFuego,cambioFase;
    public GameObject fuego, humo;
    public BoxCollider2D col;
    public Animator anim;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        cambio = false;

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
            cambio = true;
            //GameManager.gm.restarVida += 0.002f;
            anim.Play("Fire_lvl_2");
        }
        
        if (estaPrecionado == true)
        {
            hp -= GameManager.gm.fuerzaChorro;

        }
        if (hp <= 0 && estaApagado == false)
        {
            if (cambio == true) 
            {
                GameManager.gm.restarVida -= 0.005f;
            }
            GameManager.gm.restarVida -= 0.004f;
            hp = -1;
            //seapago 
            fuego.SetActive(false);
            //efectoVapor
            humo.SetActive(true);
            //desactivarCollider
            col.enabled = false;
            estaApagado = true;
            Spawner.spw.fuegosApagados++;
        }
        estaPrecionado = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("END"))
        {
            Destroy(gameObject);
            Debug.Log("aaaaa");
        }
    }
}
