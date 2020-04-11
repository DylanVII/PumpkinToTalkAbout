using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource s;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<AudioSource>();


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
}
