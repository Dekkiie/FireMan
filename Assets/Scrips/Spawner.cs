using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float min;
    public float max;

    public float spawnTime;
    public float timer;
    
    public float yMin ,xMin;
    public float yMax,xMax;
    public GameObject[] mapa;
    public int cantidadFuegos, fuegosApagados;
    public static Spawner spw;

   public bool spawn;

    private void Start()
    {
        spawn = true;
        spw = this;
    }
    void Update()
    {
        if (GameManager.gm.gano) return;
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            if (spawn == true) 
            { 


                Vector3 randomSpawn = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
                Instantiate(mapa[Random.Range(0, mapa.Length)], randomSpawn, Quaternion.identity);
                timer = 0;
                spawnTime = Random.Range(min, max);

                GameManager.gm.restarVida += 0.001f; 
            }
        }
        DetenerSpawner();
    }

    public void DetenerSpawner()
    {
        
        if(fuegosApagados >= cantidadFuegos)
        {
            GameManager.gm.gano = true;
            spawn = false;

            GameManager.gm.LvlEnd();
        }

    }

}
