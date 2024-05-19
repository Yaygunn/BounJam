using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SfxSource;

    [SerializeField] private AudioEvent musicClip; 
    
    [Header("Sfx")]
    [SerializeField] private AudioEvent hoverOn;
    [SerializeField] private AudioEvent hoverof;
    [SerializeField] private AudioEvent success;
    [SerializeField] private AudioEvent fail;


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

    public void GetResource()
    {

    }

    public void FailSound()
    {
        fail.Play(SfxSource);
    }
    public void Success()
    {
        success.Play(SfxSource);
    }

    public void HoverOn()
    {
        hoverOn.Play(SfxSource);
    }
    public void Hoverof()
    {
        hoverof.Play(SfxSource);
    }
    private void StartMusic()
    {
        musicClip.Play(MusicSource);
        MusicSource.loop = true;

        
    }
}
