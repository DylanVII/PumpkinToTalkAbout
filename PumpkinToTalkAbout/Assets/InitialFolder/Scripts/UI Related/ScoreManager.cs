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

    public RawImage ghostIcon;

    private GameObject eventManager;
    Ghost ghostscript;

    // Start is called before the first frame update
    void Start()
    {
        ghostscript = GetComponent<Ghost>();
        eventManager = GameObject.FindGameObjectWithTag("EventManager");
        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Pumpkins Left: " + remainingPumpkins;
    }

    // Update is called once per frame
    void Update()
    {
        //pointScored();
        AllPumpkinsCollected();
    }


    public void pointScored()
    {
        if (Input.GetKeyDown("p"))
        {
            collectedPumpkins += 1;
            remainingPumpkins -= 1;
        }

        collectedPumpkins += 1;
        remainingPumpkins -= 1;
        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Pumpkins Left: " + remainingPumpkins;

    }

    public void AllPumpkinsCollected()
    {
        if (remainingPumpkins <= 0 || Input.GetKeyDown("p"))
        {

            eventManager.GetComponent<EventManager>().AnalyseGhosts();
            eventManager.GetComponent<EventManager>().UsedPitchfork();


            Destroy(eventManager);
            Debug.Log("Data Sent");

            SceneManager.LoadScene("GhostWin");
        }
           

    }

    void Caught()
    {
        if (ghostscript.canMove == false)
        {
            Debug.Log("sexy");
            ghostIcon.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pumpkin")
        {
            eventManager.GetComponent<EventManager>().AddToPumpkinScoreCount();

            pointScored();
        }

    }
}
