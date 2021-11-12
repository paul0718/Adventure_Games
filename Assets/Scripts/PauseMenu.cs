using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _canvas;

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeOption(){
        _canvas.GetComponent<GameManager>().Resume();
    }
}
