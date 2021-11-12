using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Lvl_to_Load;
    public void Play(){
        SceneManager.LoadScene(Lvl_to_Load);
    }
    public void Quit(){
        Application.Quit();
    }
}
