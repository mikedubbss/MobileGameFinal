using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip coincollecting;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        //coincollecting = Resources.Load<AudioClip>("coincollect");
        //audioSrc = GetComponent<AudioSource>();
        if (GetComponent<AudioSource>() == null) audioSrc = gameObject.AddComponent<AudioSource>();
        {
            coincollecting = Resources.Load<AudioClip>("coincollect");
            audioSrc = GetComponent<AudioSource>();
            //audioSrc = Resources.Load<AudioClip>("coincollect");
        }
    }

    // Update is called once per frame
    public static void playSound()
    {
        audioSrc.PlayOneShot(coincollecting);
    }
}
