using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;

    [Header("Footstep Sounds")]
    public AudioClip footstep;

    public AudioMixerGroup playerGroup; //The player mixer group

    AudioSource playerSource;           //Reference to the generated player Audio Source

    private void Awake()
    {
        //If an AudioManager exists and it is not this...
        if (current != null && current != this)
        {
            //...destroy this. There can be only one AudioManager
            Destroy(gameObject);
            return;
        }

        //This is the current AudioManager and it should persist between scene loads
        current = this;
        DontDestroyOnLoad(gameObject);

        playerSource = gameObject.AddComponent<AudioSource>() as AudioSource;
    }

    public static void PlayStepSound()
    {
        current.playerSource.clip = current.footstep;
        current.playerSource.Play();
    }
}
