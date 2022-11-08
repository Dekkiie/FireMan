using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject bola;
    public Transform punto;
    public void CometaSpawn()
    {
        
        Instantiate(bola,punto.position, Quaternion.identity);
    }
}
