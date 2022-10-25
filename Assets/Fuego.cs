using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    public float hp = 100;
    bool leLlegoAgua;
    
    public void HechameAgua()
    {
        leLlegoAgua = true;
    }
    private void Update()
    {
       


        if(leLlegoAgua)
        {
            hp -= Time.deltaTime;
        }
        leLlegoAgua = false;
    }

}
