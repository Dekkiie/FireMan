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
    public AudioSource audios;
    public AudioClip audios2;

    public static RayCast rc; 

    bool gastandoAgua,muerto;
    public void Awake()
    {
        rc = this;
    }
    private void Start()
    {
        audios = GetComponent<AudioSource>();
        particula.Stop();
        gastandoAgua = false;
        muerto = false;

        agua = maxAgua;
        MaxCantidadAgua(maxAgua);
    }
    public void Tocar()
    {
        audios.volume = Mathf.Clamp(audios.volume, 0, 1);
        if (!muerto)
        {
           
            if (Input.touchCount > 0)
            {
                audios.volume += Time.deltaTime;
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
                audios.volume -= Time.deltaTime;
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
                vida = 0;
                agua = 0;
                muerto = true;
                particula.Stop();
                menuMuerte.SetActive(true);
                Debug.Log("Muerto");
                GameManager.gm.restarVida += 0.003f;
                audios.volume -= Time.deltaTime;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fuego"))
        {
            Muerte();
            Destroy(collision.gameObject);

        }
    }

    public void Muerte()
    {
        vida--;
        
        Gastar();
    }
}
