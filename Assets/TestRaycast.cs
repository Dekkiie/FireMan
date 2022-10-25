using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    public Transform origenRaycast;
    public LayerMask layerMask;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;

            Vector3 direccion = touchPos - origenRaycast.position;

            RaycastHit2D hit = Physics2D.Raycast(origenRaycast.position, direccion, direccion.magnitude, layerMask);

            Debug.DrawRay(origenRaycast.position, direccion, Color.green);

            if(hit.collider != null)
            {
                print("Choco con collider");
                hit.transform.gameObject.GetComponent<Fuego>().HechameAgua();
            }

        }
    }
}
