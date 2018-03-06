using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;
    public AudioSource adSource;
    public AudioClip[] adClips;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            StartCoroutine(PlayAudioSequentially());
        }
    }

    IEnumerator PlayAudioSequentially()
    {
        yield return null;

        for (int i = 0; i < adClips.Length; i++)
        {
            adSource.clip = adClips[i];
            adSource.Play();
            while (adSource.isPlaying)
            {
                yield return null;
            }
        }
    }
}
