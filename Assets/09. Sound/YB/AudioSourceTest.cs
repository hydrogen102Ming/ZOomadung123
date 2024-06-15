using UnityEngine;

public class AudioSourceTest : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
