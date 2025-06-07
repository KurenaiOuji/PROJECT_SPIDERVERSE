using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;   
    public Camera MainCamera;

    [Header("Audio")]
    public AudioSource musicSource;
    public AudioClip presentMusic;
    public AudioClip pastMusic;
    public AudioClip futureMusic;

    private void OnEnable()
    {
        EspejoManager.OnChangeTime += ChangeTime;
    }
    private void OnDisable()
    {
        EspejoManager.OnChangeTime -= ChangeTime;
    }

    void ChangeTime(int layer)
    {
        MainCamera.cullingMask = layer;

        switch (layer)
        {
            case 65: //Presente
                player.layer = 6;
                if (musicSource && presentMusic)
                    PlayMusic(presentMusic);
                break;
            case 129: //Pasado
                player.layer = 7;
                if (musicSource && pastMusic)
                    PlayMusic(pastMusic);
                break;
            case 257: //Futuro
                player.layer = 8;
                if (musicSource && futureMusic)
                    PlayMusic(futureMusic);
                break;
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;

        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }
}
