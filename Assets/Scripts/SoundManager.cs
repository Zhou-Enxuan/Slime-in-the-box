using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public static AudioSource[] audioSources;
    public float audioSpeed;

    public static AudioClip MenuBgm;
    public static AudioClip MainBgm;

    public static AudioClip ButtonSound;

    private static int curBgm;

    public static bool isChangVolume = false;

    void Awake()
    {   
        if (instance != null)
        {
            GameObject.Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        audioSources = this.gameObject.GetComponents<AudioSource>();
        MenuBgm = Resources.Load<AudioClip>("Assets/Audio/Menu_bgm");
        MainBgm = Resources.Load<AudioClip>("Assets/Audio/Ingame_bgm");
        ButtonSound = Resources.Load<AudioClip>("Assets/Audio/button_press");
        curBgm = -1;
    }

    void Start() 
    {
        //playBgm(0);
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Menu") {
            playBgm(0);
        } else if (SceneManager.GetActiveScene().name == "Main") {
            playBgm(1);
        }

        if (isChangVolume) {
            ChangVolume(0);
        }
    }

    void ChangVolume(int clipnum) {
        audioSources[clipnum].volume = Mathf.Lerp(audioSources[clipnum].volume, 1 , Time.deltaTime * audioSpeed);
        if ( audioSources[clipnum].volume > 0.95) {
            audioSources[clipnum].volume = 1;
            isChangVolume = false;
        }
    }

    public static void playBgm(int num) {
        if (num != curBgm) {
            audioSources[0].Stop();
            audioSources[0].volume = 0;
            isChangVolume = true;
            switch (num) {
                case 0:
                    audioSources[0].clip = MenuBgm;
                    break;
                case 1:
                    audioSources[0].clip = MainBgm;
                    break;
            }
            audioSources[0].Play();
            curBgm = num;
        }
    } 

    public static void playSEOne(string name) {
        // Debug.Log("play se");
        switch (name) {
            case "button":
                audioSources[1].PlayOneShot(ButtonSound, 2f);
                break;
            case "win":
                audioSources[1].PlayOneShot(ButtonSound, 2f);
                break;
        }
    }
}
