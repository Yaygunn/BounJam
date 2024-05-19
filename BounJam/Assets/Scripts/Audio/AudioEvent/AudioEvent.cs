using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Audio Events")]
public class AudioEvent : ScriptableObject
{
    public AudioClip[] clips;

    [Range(0f, 10f)]
    public float volume = 1;
    [Range(0f, 10f)]
    public float maxVolume = 1;

    [Range(0f, 2f)]
    public float minPitch = 1;
    [Range(0f, 2f)]
    public float maxPitch = 1;

    public void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume, maxVolume);
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }

}