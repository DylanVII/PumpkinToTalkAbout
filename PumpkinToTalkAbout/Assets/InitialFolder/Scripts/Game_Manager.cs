using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private float gameTime;
    public float maxgameTime;
    public int score;

    public enum State { Starting, Playing,Gameover, Paused};
    public State state;


    public float pausingPlayer;

    void Start()
    {
        state = State.Starting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (State.Starting):
                gameTime = maxgameTime;
                score = 0;
                state = State.Playing;
                break;
            case (State.Playing):

                break;
            case (State.Gameover):

                break;
            case (State.Paused):

                break;

        }
    }
}
