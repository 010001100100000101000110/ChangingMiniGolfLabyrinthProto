using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioClip keyCollected;
    [SerializeField] AudioClip resourceCollected;
    [SerializeField] AudioClip finishReached1;
    [SerializeField] AudioClip finishReached2;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayKeyCollectedSound()
    {
        audioSource.PlayOneShot(keyCollected);
    }

    public void PlayResourceCollectedSound()
    {
        audioSource.PlayOneShot(resourceCollected);
    }

    public void PlayFinishReachedSound()
    {
        audioSource.PlayOneShot(finishReached1);
    }
}
