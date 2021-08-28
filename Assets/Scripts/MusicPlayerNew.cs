using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerNew : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        int musicPlayerAmmount = FindObjectsOfType<MusicPlayerNew>().Length;
        if(musicPlayerAmmount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
