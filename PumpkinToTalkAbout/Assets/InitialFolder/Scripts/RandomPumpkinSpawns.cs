using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPumpkinSpawns : MonoBehaviour
{
    public GameObject[] pumpkinSpawns;
    public GameObject[] pumpkins;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the pumpkins to a random position amongst fixed locations
        pumpkins[0].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[1].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[2].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[3].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[4].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        
    }
}
