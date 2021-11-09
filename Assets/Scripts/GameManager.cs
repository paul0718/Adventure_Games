using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject quitBtn;
    public string levelToLoad;

    private void Start()
    {
        Resume();
#if UNITY_WEBGL
        quitBtn.SetActive(false);
#endif
        
    }

    
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PublicVars.paused)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                PublicVars.paused = true;
                Time.timeScale =0;

            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        PublicVars.paused = false;
        Time.timeScale =1;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }

    public void Quit()
    {
        Application.Quit();

    }

    //for going to start page
    public void next_level()
    {

        SceneManager.LoadScene("StartPage");
    }

    //start page to level one
    public void first_level()
    {

        SceneManager.LoadScene("FireLvl1");
    }

        //start page to level one
    public void starter_level()
    {

        SceneManager.LoadScene("StartPage");
    }

}
