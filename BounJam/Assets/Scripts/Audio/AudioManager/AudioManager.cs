using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SfxSource;

    [SerializeField] private AudioClip musicClip; 
    
    [Header("Sfx")]
    [SerializeField] private bool musicPlaying;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        StartMusic();
    }

    private void StartMusic()
    {
        MusicSource.clip = musicClip;
        MusicSource.loop = true;

        MusicSource.Play();
    }
}
