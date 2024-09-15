using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    PlayerScript playerScript;
    public GameObject player;
    public GameObject Coin;
    AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
        AudioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.Play();
        playerScript.addCoin();
        StartCoroutine(RmObj());
    }

    IEnumerator RmObj()
    {
        yield return new WaitForSeconds(1);
        Coin.SetActive(false);
    }
}
