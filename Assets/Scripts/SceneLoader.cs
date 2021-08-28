using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //states
    int currentSceneIndex;

    public void NextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadThisScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine ("MainMenuCoroutine");     
        }
    }

    IEnumerator MainMenuCoroutine()
    {
        yield return new WaitForSeconds(4);
        NextScene();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public int GetSceneIndex()
    {
        return currentSceneIndex;
    }
}
