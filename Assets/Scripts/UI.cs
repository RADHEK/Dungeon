using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public int health;
    public Text healthText;
    public GameObject GameMenu;
    public GameObject PauseButton;
    public GameObject RestartButton;
    public GameObject ResumeButton;
    public GameObject QuitButton;

    void Start()
    {
        GameMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        ShowHealth();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 1) Pause();
            else  Resume();
        }
    }
    void ShowHealth()
    {
        health = GameObject.Find("Player").GetComponent<Player>().CurrentHealth;
        healthText.text = "HP  " + health;
    }
    public void Resume()
    {
        GameMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        GameMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }


}
