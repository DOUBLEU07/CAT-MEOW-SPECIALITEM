using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_SG : MonoBehaviour
{
    public static AudioClip CatDied, DogDied, CatEnergyEaten, Victory;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        CatEnergyEaten = Resources.Load<AudioClip>("CatEnergyEaten");
        Victory = Resources.Load<AudioClip>("Victory");
        CatDied = Resources.Load<AudioClip>("CatDied");
        DogDied = Resources.Load<AudioClip>("DogDied");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        if (clip == "CatEnergyEaten")
        {
            audioSource.PlayOneShot(CatEnergyEaten);
        }
        else if (clip == "Victory")
        {
            audioSource.PlayOneShot(Victory);
        }
        else if (clip == "CatDied")
        {
            audioSource.PlayOneShot(CatDied);
        }
        else if (clip == "DogDied")
        {
            audioSource.PlayOneShot(DogDied);
        }

    }
}
