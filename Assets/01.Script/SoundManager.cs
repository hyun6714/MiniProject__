using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource BGMSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.DeleteAll();
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        SetBgmVolume(savedVolume);
    }

    public void SetBgmVolume(float volume)
    {
        BGMSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume",volume);
        PlayerPrefs.Save();
    }

    public float GetBgmVolume()
    {
        return BGMSource.volume;
    }
}
