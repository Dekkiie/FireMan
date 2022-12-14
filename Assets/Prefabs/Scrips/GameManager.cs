using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float fuerzaChorro;
    public float fuegoSubiendo;
    public static GameManager gm;
    public float vidaMax,vida,delayMenu,delayMenuLost,restarVida;

    public TextMeshProUGUI cantF, totalF,vidaas;

    GameObject[] fuegos;

    public TimeBar timebar;

    public bool killFire,gano;

    public GameObject killer,menuVictoria,menuDerrota,fuego,tuto;

    public Animator anim;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        gm = this;
        killFire = true;
    }
    private void Start()
    {


        vida = vidaMax;
        timebar.SetMaxHealth(vidaMax);
    }
    private void Update()
    {
        Tiempo();

        cantF.text = Spawner.spw.cantidadFuegos.ToString();
        totalF.text = Spawner.spw.fuegosApagados.ToString();
        vidaas.text = RayCast.rc.vida.ToString();



    }
    public void Tiempo()
    {

        if (killFire == true) 
        {
            vida -= restarVida;
            timebar.SetHealthh(vida);

            if (vida <= 0)
            {
                fuego.SetActive(true);
                vida = 0;
                
                Invoke("MenuDerrota",delayMenuLost);
                
            }
        }
        if (restarVida <= 0)
        {
            restarVida = 0.003f;
        }
    }

    
    public void LvlEnd()
    {
        Debug.Log("Victoria");
        Invoke("MostrarMenuVictoria", delayMenu);
        killFire = false;

        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Fuego");
        for (int i = 0; i < objetos.Length; i++)
        {
            Destroy(objetos[i]);
        }
        killer.SetActive(true);
        
    }
    public void MenuDerrota()
    {
        menuDerrota.SetActive(true);
    }
    public void MostrarMenuVictoria()
    {
        menuVictoria.SetActive(true);
    }
    public void ComenzarJuego()
    {
        SceneManager.LoadScene("Tutorial");

    }
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    public void Salir()
    {
        anim.Play("entra");
    }
    public void MenuBack()
    {
        anim.Play("sale");
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
