using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundSource;

    [SerializeField] private List<SoundData> soundCategories;

    private Dictionary<string, SoundData> sounds = new Dictionary<string, SoundData>();

    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip[] clips;

        public AudioClip GetRandom()
        {
            if (clips == null || clips.Length == 0) return null;
            int r = UnityEngine.Random.Range(0, clips.Length);
            return clips[r];
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (var data in soundCategories)
            {
                sounds[data.name] = data;
            }
        }
        else
        {
            Destroy(gameObject);
        }

        PlayBackgroundNoise("Background");
    }

    public static void PlayBackgroundNoise(string category)
    {
        if (instance == null) return;

        if (instance.sounds.TryGetValue(category, out SoundData data))
        {
            AudioClip clip = data.GetRandom();
            if (clip != null)
            {
                instance.backgroundSource.clip = clip;
                instance.backgroundSource.volume = 0.1f;
                instance.backgroundSource.loop = true;
                instance.backgroundSource.Play();
            }
        }
    }

    public static void Tower() => instance?.InternalPlay("Tower");
    public static void Tree() => instance?.InternalPlay("Tree");
    public static void Signal() => instance?.InternalPlay("Signal");
    public static void Water() => instance?.InternalPlay("Water");
    public static void Win() => instance?.InternalPlay("Win");
    public static void Random() => instance?.InternalPlay("Random");

    private void InternalPlay(string categoryName)
    {
        if (sounds.TryGetValue(categoryName, out SoundData data))
        {
            AudioClip clip = data.GetRandom();
            if (clip != null) audioSource.PlayOneShot(clip);
        }
    }
}
