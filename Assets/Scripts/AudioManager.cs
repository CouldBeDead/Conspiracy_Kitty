using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip music;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(music);

    }
}
