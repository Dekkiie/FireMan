using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float fuerzaChorro;

    public static GameManager gm;

    private void Awake()
    {
        gm = this;
    }

}
