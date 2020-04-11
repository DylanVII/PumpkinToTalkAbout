using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource s;
    public static AudioClip stabSound, catchSound, throwSound, clinkSound;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<AudioSource>();

        stabSound = Resources.Load<AudioClip>("Stab");
        throwSound = Resources.Load<AudioClip>("throw");
        catchSound = Resources.Load<AudioClip>("catch");
        clinkSound = Resources.Load<AudioClip>("clink");
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            s.pitch *= .9f;
        } else if (!PauseMenu.GameIsPaused)
        {
            s.pitch = 1f;
        }

        if (PauseMenu.BackToMenu)
        {
            s.pitch = 1f;
        }
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Stab":
                s.PlayOneShot(stabSound);
                break;
            case "throw":
                s.PlayOneShot(throwSound);
                break;
            case "catch":
                s.PlayOneShot(catchSound);
                break;
            case "clink":
                s.PlayOneShot(clinkSound);
                break;
        } 

    }
}
