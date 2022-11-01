using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float fuerzaChorro;
    public float fuegoSubiendo;
    public static GameManager gm;
    public float vidaMax,vida;

    public TimeBar timebar;


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
        vida -= Time.deltaTime;
        timebar.SetHealthh(vida);

        if(vida <= 0)
        {
            Debug.Log("Edificio Quemado");
        }
    }


}
