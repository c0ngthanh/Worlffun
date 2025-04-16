using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource audioSource;
    private AudioClip[] soundClips = new AudioClip[2]; // Array to hold sound clips

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundClips[0] = Resources.Load<AudioClip>("Sound/CombatUI/Player"); 
        soundClips[1] = Resources.Load<AudioClip>("Sound/CombatUI/Enemy"); 
    }

    public void PlaySound(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < soundClips.Length)
        {
            audioSource.PlayOneShot(soundClips[clipIndex]);
        }
        else
        {
            Debug.LogWarning("Sound clip index out of range: " + clipIndex);
        }
    }
}
