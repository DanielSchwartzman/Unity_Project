using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartSceneTransition());
    }

    IEnumerator StartSceneTransition()
    {
        Animator anim = player.GetComponent<Animator>();
        anim.SetBool("SceneChange", true);
        yield return new WaitForSeconds(3);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
        anim.SetBool("SceneChange", false);
    }
}
