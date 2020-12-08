using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectButton : MonoBehaviour
{

    public GameObject SelectPanel;

    public GameObject Stbutton;
    public GameObject TitelText;

    public void ChangeScene()
    {
        SelectPanel.SetActive(true);
        Stbutton.SetActive(false);
        TitelText.SetActive(false);
    }

    public void SelctGame(string name)
    {
        switch (name)
        {

            case "1":
                Static.CleraTime = 3.0f;
                Static.TitelText = "3秒で止めろ";
                SceneManager.LoadScene("GameScene");
                break;

            case "2":
                Static.CleraTime = 5.0f;
                Static.TitelText = "5秒で止めろ";
                SceneManager.LoadScene("GameScene");
                break;

            case "3":
                Static.CleraTime = 10.0f;
                Static.TitelText = "10秒で止めろ";
                SceneManager.LoadScene("GameScene");
                break;
        }
    }

}
