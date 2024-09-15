using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    AudioSource AudioSource;
    int speed = 5;
    float angularSpeed = 50;
    public Text UI;
    public GameObject aCamera;

    private int Health = 100;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        AudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();  
        UI = GetComponent<PlayerScript>().UI;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = speed * Time.deltaTime, dz = speed * Time.deltaTime;
        float yRotation = Input.GetAxis("Mouse X") * Time.deltaTime * angularSpeed;
        float xRotation = Input.GetAxis("Mouse Y") * Time.deltaTime * angularSpeed;
        transform.Rotate(new Vector3(0, yRotation, 0));
        aCamera.transform.Rotate(new Vector3(-xRotation,0,0));

        dz *= Input.GetAxis("Vertical");
        dx *= Input.GetAxis("Horizontal");

        Vector3 motion = new Vector3 (dx*5, -0.5f, dz*5);
        if((dx != 0 || dz != 0)&&(!AudioSource.isPlaying))
        {
            AudioSource.Play();
        }
        motion = transform.TransformDirection(motion);
        controller.Move(motion);
    }

    public void getHit()
    {
        Health -= 10;
        if(Health <= 0)
        {
            SceneManager.LoadScene(2);
        }
        DisplayInfo();
    }

    public void addCoin()
    {
        ValueToKeep.Instance.addCoins(10);
        DisplayInfo();
    }

    private void DisplayInfo()
    {
        UI.text = "Health : " + Health.ToString()+"\nCoins : "+ValueToKeep.Instance.getCoins();
    }
}
