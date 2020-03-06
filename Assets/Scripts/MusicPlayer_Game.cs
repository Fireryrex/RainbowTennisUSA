using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer_Game : MonoBehaviour
{
    public AudioClip[] tracks;
    public AudioSource audioSource;
    private int currentTrack;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = GetRandomTrack();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetNextTrack();
            audioSource.Play();
            //so in this print statement, current track works more like a "last track" 
            //but as far as this script is concerned, current track IS the current track during operation
            print (currentTrack);
        }
    }

    private AudioClip GetRandomTrack()
    {
        int trackNum = Random.Range(0, tracks.Length);
        currentTrack = trackNum;
        return tracks[trackNum];
    }

    private AudioClip GetNextTrack()
    {
        if(currentTrack == tracks.Length - 1)
        {
            print("last track");
            currentTrack = 0;          
        }

        else
        {
            currentTrack++;
        }

        return tracks[currentTrack];

    }
}
