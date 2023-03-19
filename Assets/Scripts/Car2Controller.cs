using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : MonoBehaviour
{
    public GameObject player, canvas,gameSound;
    public PlayerController playerController;
    public CanvasController canvasController;
    public float carSpeed;
    public AudioSource audioSource;
    public AudioClip crashSound;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        canvas = GameObject.FindGameObjectWithTag("GameController");
        canvasController = canvas.GetComponent<CanvasController>();
        gameSound = GameObject.FindGameObjectWithTag("GameSound");
        audioSource = gameSound.GetComponent<AudioSource>();

        Destroy(gameObject, 10);
    }


    void FixedUpdate()
    {
        transform.position += Vector3.back * carSpeed * Time.fixedDeltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            carSpeed = 15f;

        }
        else if (other.tag == "Player")
        {
            playerController.canMove = false;
            Time.timeScale = 0;
            canvasController.tryAgainScreen.SetActive(true);
            canvasController.gameScreen.SetActive(false);
            canvasController.carAudioSource.Stop();
            audioSource.PlayOneShot(crashSound, 0.5f);
        }
    }

}