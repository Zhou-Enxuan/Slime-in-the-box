using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource theme;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        theme = this.gameObject.AddComponent<AudioSource>();
        theme.loop = true;

    }

    private void Start()
    {
        theme.Play();
    }

}
