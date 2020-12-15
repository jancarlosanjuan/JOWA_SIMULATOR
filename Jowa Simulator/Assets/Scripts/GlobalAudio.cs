using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudio : MonoBehaviour
{
    [SerializeField] private bool isMute = false;
    [SerializeField] private List<AudioClip> soundContainer;
   
    private AudioSource soundPlayer;
    //SINGLETON DO NOT EDIT 
    private static GlobalAudio _instance;
    public static GlobalAudio Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalAudio>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GlobalAudio>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;

        }
        else if (_instance != this)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            this.gameObject.AddComponent<AudioSource>();
        }
    }

    public void playSound(string soundName, float volume)
    {
        if (!isMute)
        {
            int index = 0;
            bool found = false;
            for (int i = 0; i < soundContainer.Count; i++)
            {
                if (soundContainer[i].name == soundName)
                {
                    index = i;
                    found = true;
                }
            }

            if (!found)
            {
         //       Debug.Log("SOUND: " + soundName + "is not found!");
                return;
            }

            this.GetComponent<AudioSource>().PlayOneShot(soundContainer[index], volume);
         //   Debug.LogWarning("Is this working TOOOO");
         //   Debug.LogError(soundContainer[index].name);
            //   soundPlayer.PlayOneShot(soundContainer[index], volume);
        }
        
    }

    public bool isSoundPlaying()//string soundName
    {
        /*for(int i = 0; i < soundContainer.Count; i++)
        {
            if(soundContainer[i].name == soundName)
            {
                return this.gameObject.GetComponent<AudioSource>().isPlaying;
            }
        }

        return false;
        */
        return this.gameObject.GetComponent<AudioSource>().isPlaying;
    }
}
