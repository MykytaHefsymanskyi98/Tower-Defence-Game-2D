using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME = "master volume";
    const string DIFFICULTY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume is set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        }
        else
        {
            Debug.LogError("Master volume is not in the suitable range");
        }
    }

    public static void SetDifficulty(float difficultyLevel)
    {
        if (difficultyLevel >= MIN_DIFFICULTY && difficultyLevel <= MAX_DIFFICULTY)
        {
            Debug.Log("Difficulty level is set to " + difficultyLevel);
            PlayerPrefs.SetFloat(DIFFICULTY, difficultyLevel);
        }
        else
        {
            Debug.LogError("Difficulty level is not in the suitable range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY);
    }
}
