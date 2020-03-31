using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchTimer : MonoBehaviour
{
    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public Text timerText;

    float timeLeft;

    public GameObject eventThing;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Time left " + timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = maxTime - timePassing;

        TimerFunction();

        timerText.text = "Time left " + timeLeft;
    }

    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= maxTime)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        //Do your stuff here.
        eventThing.GetComponent<EventManager>().AnalyseGhosts();
        eventThing.GetComponent<EventManager>().UsedPitchfork();


        Debug.Log("End me please");
        Destroy(eventThing);


        SceneManager.LoadScene("FarmerWin");

        //Only use if timer needs to be reset
        //timePassing = 0;
    }
}
