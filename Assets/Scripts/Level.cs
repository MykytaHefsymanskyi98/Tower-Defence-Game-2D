using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //conf param
    [SerializeField] Text scoreText;
    [SerializeField] GameObject leftEdge;
    [Header("Canvas")]
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject pauseLabel;
    [SerializeField] GameObject musicPlayerForLabel;
    //[SerializeField] AudioClip[] audioForCanvas;

    //states
    float startScore = 3f;
    float score;
    float scoreDelta = 1f;
    float gameSpeed = 1f;
    int numberOfFoes = 0;
    int currentSceneIndex;
    bool pauseActive = false;

    //references
    Timer timer;
    SceneLoader sceneLoader;
    
    // Start is called before the first frame update
    void Start()
    {
        score = startScore - PlayerPrefsController.GetDifficulty();
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        DisplayScoreText();
        timer = FindObjectOfType<Timer>();
        Debug.Log("Difficulty currently is " + PlayerPrefsController.GetDifficulty());
        pauseLabel.SetActive(false);
        sceneLoader = FindObjectOfType<SceneLoader>();
        currentSceneIndex = sceneLoader.GetSceneIndex();
    }

    // Update is called once per frame
    void Update()
    {
        AttackersPresent();
        Pause();
    }

    public void DisplayScoreText()
    {
        scoreText.text = GetScore().ToString();
    }

    public void DecreaseScore()
    {
        score -= scoreDelta;
        DisplayScoreText();
        if(score <= 0)
        {
            DisplayLoseCanvas();
        }
    }

    private void AttackersPresent()
    {
        var attackers = FindObjectsOfType<Attacker>();
       
        if(numberOfFoes <= 0 && timer.IsTimerFinish())
        {
            StartCoroutine(HandleLevelCompleteCoroutine());      
        }
    }
    public void AddFoes()
    {
        numberOfFoes++;
    }

    public void DestroyFoes()
    {
        numberOfFoes--;
    }

    IEnumerator HandleLevelCompleteCoroutine()
    {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4);
            sceneLoader.NextScene();
    }

    private void DisplayLoseCanvas()
    {
        Time.timeScale = 0;
        loseLabel.SetActive(true);
        musicPlayerForLabel.GetComponent<AudioSource>().Play();     
    }

    public float GetScore()
    {
        return score;
    }

    public float SetScore(float newScore)
    {
        return score = newScore;
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && currentSceneIndex != 0 && currentSceneIndex != 1 && currentSceneIndex != 8 && currentSceneIndex != 9 && !pauseActive)
        {
            Time.timeScale = 0f;
            pauseLabel.gameObject.SetActive(true);
            pauseActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && currentSceneIndex != 0 && currentSceneIndex != 1 && currentSceneIndex != 8 && currentSceneIndex != 9 && pauseActive)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        pauseLabel.gameObject.SetActive(false);
        Time.timeScale = gameSpeed;
        pauseActive = false;
    }

    public void MainMenu()
    {
        if(FindObjectOfType<SceneLoader>())
        {
            FindObjectOfType<SceneLoader>().LoadMainMenu();
        }
        else
        {
            return;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
