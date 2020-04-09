using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //Pumpkin Count Related
    public int collectedPumpkins;
    public int remainingPumpkins;

    //Used for UI
    public Text collectedPumpkinsText;
    public Text remainingPumpkinsText;

    //Used to highlight ghost
    public RawImage ghostIcon;

    //Used to access x
    private GameObject eventManager;
    public Ghost ghostscript;

    // Start is called before the first frame update
    void Start()
    {

        eventManager = GameObject.FindGameObjectWithTag("EventManager");
        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Pumpkins Left: " + remainingPumpkins;
    }

    // Update is called once per frame
    void Update()
    {
        Caught();

        AllPumpkinsCollected();
    }


    public void pointScored()
    {
        //Dev control
        if (Input.GetKeyDown("p"))
        {
            collectedPumpkins += 1;
            remainingPumpkins -= 1;
        }

        //Changes value based on call
        collectedPumpkins += 1;
        remainingPumpkins -= 1;
        collectedPumpkinsText.text = "Collected Pumpkins " + collectedPumpkins;
        remainingPumpkinsText.text = "Pumpkins Left: " + remainingPumpkins;

    }

    //Called only if all pumpkins were collected
    public void AllPumpkinsCollected()
    {
        //Checks that there are no remaining pumpkins or by dev control
        if (remainingPumpkins <= 0 || Input.GetKeyDown("p"))
        {
            //Analytic related
            eventManager.GetComponent<EventManager>().AnalyseGhosts();
            eventManager.GetComponent<EventManager>().UsedPitchfork();

            //Destroys eventmanger to proc analytic to send data to server
            Destroy(eventManager);

            SceneManager.LoadScene("GhostWin");
        }
           

    }

    //Changes Ghost icon colour when hit
    void Caught()
    {
        if (!ghostscript.canMove)
        {
            
            ghostIcon.color = Color.red;
        }
        else if (ghostscript.canMove)
        {
            ghostIcon.color = Color.white;
        }
    }

    //Used to score the pumpkin and destroy it afte scoring
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pumpkin")
        {
            eventManager.GetComponent<EventManager>().AddToPumpkinScoreCount();

            pointScored();

            Destroy(other.gameObject);
        }

    }
}
