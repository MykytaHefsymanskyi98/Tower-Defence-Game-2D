using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // conf param
    [SerializeField] Slider volumeController;
    [SerializeField] Slider difficultyController;
    [SerializeField] float defaultVolume = 0.6f;
    [SerializeField] float defaultDifficulty = 0f;

    //references
    MusicPlayerNew musicPlayer;
    Level level;

    //states
    float minDeifficultyVar = 0f;
    float midDifficultyVar = 1f;
    float maxDifficultyVar = 2f;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayerNew>();
        volumeController.value = PlayerPrefsController.GetMasterVolume();
        level = FindObjectOfType<Level>();
        difficultyController.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeController.value);
        }
        else
        {
            Debug.Log("There is no musicPlayer component");
        }    
    }

    public void SetVolume()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeController.value);
        }
        else
        {
            Debug.Log("There is no musicPlayer component");
        }
    }
   
    public void SaveAndBack()
    {
        PlayerPrefsController.SetMasterVolume(volumeController.value);
        PlayerPrefsController.SetDifficulty(difficultyController.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void DeffaultButton()
    {
        volumeController.value = defaultVolume;
        difficultyController.value = defaultDifficulty;
    }

    //public void SetNewDifficulty()
    //{
    //    if (difficultyController.value <= minDeifficultyVar)
    //    {
    //        SetLightDifficulty();
    //    }

    //    if (difficultyController.value == midDifficultyVar)
    //    {
            
    //    }
    //}

    //private void SetLightDifficulty()
    //{
    //    level.SetScore(5f);
    //}

    //private void SetHardDifficulty()
    //{
    //    level.SetScore(3f);
    //}
}
