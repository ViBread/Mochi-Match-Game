using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
