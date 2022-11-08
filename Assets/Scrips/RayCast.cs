using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public GameObject menuMuerte;
    public Slider slider;

    public float agua, maxAgua;

    public int vida;
     
    public Transform startPoint;
    public LayerMask layerMask;
    public ParticleSystem particula;
    public ParticleSystem.EmissionModule emisor;

    public static RayCast rc; 

    bool gastandoAgua,muerto;
    public void Awake()
    {
        rc = this;
    }
    private void Start()
    {
        particula.Stop();
        gastandoAgua = false;
        muerto = false;

        agua = maxAgua;
        MaxCantidadAgua(maxAgua);
    }
    public void Tocar()
    {
        if (!muerto)
        {
            if (Input.touchCount > 0)
            {
                gastandoAgua = true;
                particula.Play();
                Touch touch = Input.GetTouch(0);

                Vector3 tPos = Camera.main.ScreenToWorldPoint(touch.position);
                tPos.z = 0;

                Vector3 dir = tPos - startPoint.position;

                RaycastHit2D hit = Physics2D.Raycast(startPoint.position, dir, dir.magnitude, layerMask);

                Debug.DrawRay(startPoint.position, dir, Color.green);

                if (hit.collider != null)
                {
                    Debug.Log("Choco collider");
                    hit.transform.gameObject.GetComponent<Fire>().WaterDrop();
                }
            }
            else
            {
                gastandoAgua = false;
                particula.Stop();
            }
        }

    }
    public void CantidadAgua(float agua)
    {
        slider.value = agua;
    }

    public void MaxCantidadAgua(float agua)
    {
        slider.value = agua;
    }
    private void Update()
    {
        Tocar();
        Gastar();
    }

    public void Gastar()
    {
        if(gastandoAgua == true)
        {
            if (muerto == false)
            {
                agua -= Time.deltaTime;
                CantidadAgua(agua);
                if (agua <= 0)
                {
                    vida--;
                    agua = maxAgua;

                }
            }

            if(vida <= 0) 
            {
                agua = 0;
                muerto = true;
                particula.Stop();
                menuMuerte.SetActive(true);
                Debug.Log("Muerto");
                GameManager.gm.restarVida += 0.003f;
            }
        }

    }
}
