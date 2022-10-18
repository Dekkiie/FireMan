using System.Collections;
using System.Collections.Generic;
//using UnityEditor.DeviceSimulation;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWater();
    }

    public void SpawnWater()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                Instantiate(water, touchPos, Quaternion.identity);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                Destroy(water);
            }
        }
    }
}
