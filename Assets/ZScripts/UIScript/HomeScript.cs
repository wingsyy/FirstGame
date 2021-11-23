using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeScript : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject ui;
    private void Awake()
    {
        MenuUI.gameObject.SetActive(false);
    }
    public void Stop()
    {
        MenuUI.gameObject.SetActive(true);
        Time.timeScale = 0;
            ui.gameObject.SetActive(false);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        ui.gameObject.SetActive(true);
        MenuUI.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Reverse()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
