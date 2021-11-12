using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    // public GameObject quitBtn;
    public string levelToLoad;

    private void Start()
    {
        Resume();
// #if UNITY_WEBGL
//         quitBtn.SetActive(false);
// #endif
        
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
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        PublicVars.paused = false;
        

    }

    public void Pause(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        PublicVars.paused = true;
        
    }


    // //for going to start page
    // public void next_level()
    // {

    //     SceneManager.LoadScene("StartPage");
    // }

    // //start page to level one
    // public void first_level()
    // {

    //     SceneManager.LoadScene("FireLvl1");
    // }

    //     //start page to level one
    // public void starter_level()
    // {

    //     SceneManager.LoadScene("StartPage");
    // }

}
