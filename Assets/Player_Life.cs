using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    public Player jugador;
    private bool isPaused;

    public float life = 100;
    public Image lifebar;
    [SerializeField] private GameObject gameOverUI;
    public bool flag ;
    void Start() {
        isPaused = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0]; //disco
        flag = false;
    }
    void Update()
    {
        life = Mathf.Clamp(life, 0,100); // Min and Max of life
        lifebar.fillAmount = life / 100;
 

        if (life <= 0) {
            jugador.a.SetTrigger("dying");

            if (!flag)
            {
                sonido();
            }
            //Destroy(gameObject, 1);
            EndGame();
        }
       

    }
    public void sonido() {
        audioSource.clip = clips[0];
        audioSource.Play();

        flag = true;
    }
    public void EndGame() {
        gameOverUI.SetActive(true);

        /*if (isPaused)
        {
            
            isPaused = false;

        }
        else {
            Time.timeScale = 0;

            isPaused = true;
        }*/


    }




}
