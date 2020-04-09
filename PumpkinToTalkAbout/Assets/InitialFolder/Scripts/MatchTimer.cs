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
        timerText.text = " " + timeLeft.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = maxTime - timePassing;

        TimerFunction();

        timerText.text = " " + timeLeft.ToString("f0");
    }

    //Checks for if the playtime has passed the maximum time and if so, do x
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
        //Analytic related
        eventThing.GetComponent<EventManager>().AnalyseGhosts();
        eventThing.GetComponent<EventManager>().UsedPitchfork();


        Destroy(eventThing);


        SceneManager.LoadScene("FarmerWin");

        //Only use if timer needs to be reset
        //timePassing = 0;
    }
}
