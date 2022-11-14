using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject bola;
    public Transform punto;
    public Animator anim;
    public AudioClip[] audios;
    public AudioSource aSource;

    public AudioClip boom;

    public void CometaSpawn()
    {
        
        Instantiate(bola,punto.position, Quaternion.identity);
    }
    public void NextAnim()
    {
        anim.Play("FireBall");
    }

    public void AudiosPlays()
    {
        aSource.PlayOneShot(audios[Random.Range(0,2)]);
    }

    public void DeathSound()
    {
        aSource.PlayOneShot(boom);
    }
        
}
