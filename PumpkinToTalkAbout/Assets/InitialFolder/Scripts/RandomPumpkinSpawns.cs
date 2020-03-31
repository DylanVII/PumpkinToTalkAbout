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
        pumpkins[0].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[1].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[2].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[3].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        pumpkins[4].transform.position = pumpkinSpawns[Random.Range(0, pumpkinSpawns.Length)].transform.position;
        //Instantiate(pumpkins, pumpkinSpawns[Random.Range(0,4)].transform, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
