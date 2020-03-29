using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int collectedPumpkins;
    public int remainingPumpkins;

    public Text collectedPumpkinsText;
    public Text remainingPumpkinsText;

    private GameObject eventManager;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.FindGameObjectWithTag("EventManager");
        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Remaining Pumpkins " + remainingPumpkins;
    }

    // Update is called once per frame
    void Update()
    {
        //pointScored();
    }


    public void pointScored()
    {
        if (Input.GetKeyDown("p"))
        {
            collectedPumpkins += 1;
            remainingPumpkins -= 1;
        }

        Debug.Log("Something is being gay");
        collectedPumpkins += 1;
        remainingPumpkins -= 1;
        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Remaining Pumpkins " + remainingPumpkins;

    }

    public void AllPumpkinsCollected()
    {
        if (remainingPumpkins == 0)
            SceneManager.LoadScene("GhostsWin");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pumpkin")
        {
            eventManager.GetComponent<EventManager>().AddToPumpkinScoreCount();
            Debug.Log("Something is being gay");
            pointScored();
        }

    }
}
