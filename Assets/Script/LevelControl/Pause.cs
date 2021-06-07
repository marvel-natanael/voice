using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Show()
    {
        paused = true;
    }
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
