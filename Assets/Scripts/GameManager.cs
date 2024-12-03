using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Clock clock;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindAnyObjectByType<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clock.time <= 0)
        {
            gameOver = true;
        }
        if (gameOver == true)
        {

        }
    }
}
