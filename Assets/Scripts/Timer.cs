using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("Time duration of level")]
    [SerializeField] float timeLevel = 30;

    float timeDelta = 10f;
    private void Start()
    {
        timeLevel += timeDelta * PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / timeLevel;

        
        if(IsTimerFinish())
        {
            var attackersSpawners = FindObjectsOfType<AttackerSpawner>();
            foreach(AttackerSpawner newattackerSpawner in attackersSpawners)
            {
                newattackerSpawner.NotSpawn();
               
            
            }
        }
    }

    public bool IsTimerFinish()
    {
        bool timerFinish = (Time.timeSinceLevelLoad >= timeLevel);
        return timerFinish;
    }
}
