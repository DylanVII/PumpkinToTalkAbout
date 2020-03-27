using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int collectedPumpkins;
    public int remainingPumpkins;

    public Text collectedPumpkinsText;
    public Text remainingPumpkinsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointScored();
    }


    public void pointScored()
    {
        if (Input.GetKeyDown("p"))
        {
            collectedPumpkins += 1;
            remainingPumpkins -= 1;
        }

        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Remaining Pumpkins " + remainingPumpkins;

    }
}
