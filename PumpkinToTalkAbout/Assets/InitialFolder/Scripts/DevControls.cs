using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevControls : MonoBehaviour
{
    //Dev control to skip a level
    void Update()
    {
        
        if(Input.GetKeyDown("r"))
            Application.LoadLevel(Application.loadedLevel);
    }
}
