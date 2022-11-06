using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float fuerzaChorro;
    public float fuegoSubiendo;
    public static GameManager gm;
    public float vidaMax,vida;

    GameObject[] fuegos;

    public TimeBar timebar;

    public bool killFire;

    public GameObject killer;


    private void Awake()
    {
        gm = this;
    }
    private void Start()
    {
        vida = vidaMax;
        timebar.SetMaxHealth(vidaMax);
    }
    private void Update()
    {
        Tiempo();

    }
    public void Tiempo()
    {
        if (killFire == true) 
        {
            vida -= Time.deltaTime;
            timebar.SetHealthh(vida);

            if (vida <= 0)
            {
                Debug.Log("Edificio Quemado");
            }
        }
        
    }
    public void LvlEnd()
    {
        killFire = true;
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Fuego");
        for (int i = 0; i < objetos.Length; i++)
        {
            Destroy(objetos[i]);
        }
        killer.SetActive(true);
        
    }

}
