using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuccessScreen : MonoBehaviour
{
    public Button button;
    public Text UI;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        UI = GetComponent<SuccessScreen>().UI;
        UI.text = "Congratulation you have found the way back and returned with " + ValueToKeep.Instance.getCoins() + " Coins!";
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(0);
    }

}
