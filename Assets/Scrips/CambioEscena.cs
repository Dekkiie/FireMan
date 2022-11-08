using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string sigteEscena;
    public float tiempoEspera;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Cambiar()
    {
        SceneManager.LoadScene(sigteEscena);
    }

    public void EscenaInvokar()
    {
        anim.Play("Out");
        Invoke("Cambiar",tiempoEspera);
    }
}
