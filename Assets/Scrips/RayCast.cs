using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform startPoint;
    public LayerMask layerMask;
    public ParticleSystem particula;
    public ParticleSystem.EmissionModule emisor;

    private void Start()
    {
        particula.Stop();
    }
    public void Tocar()
    {
        if(Input.touchCount > 0)
        {
            particula.Play();
            Touch touch = Input.GetTouch(0);

            Vector3 tPos = Camera.main.ScreenToWorldPoint(touch.position);
            tPos.z = 0;

            Vector3 dir = tPos - startPoint.position;

            RaycastHit2D hit = Physics2D.Raycast(startPoint.position, dir, dir.magnitude, layerMask);

            Debug.DrawRay(startPoint.position, dir, Color.green);

            if(hit.collider != null)
            {
                Debug.Log("Choco collider");
                hit.transform.gameObject.GetComponent<Fire>().WaterDrop();
            }
        }
        else
        {
            particula.Stop();
        }

    }

    private void Update()
    {
        Tocar();
    }
}
