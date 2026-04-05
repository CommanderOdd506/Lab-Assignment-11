using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSimulator : MonoBehaviour
{
    private static string[] firstNames = { "Todd", "Jesh", "Daniel", "Tyler", "Trevor", "Parker", "Grace", "Jared", "Stephanie", "Alex", "Danny", "Xavier", "Mykaleigh", "Olivia", "Peter", "Wendy", "Pitbull", "Karen", "Mitch", "Max" };
    private static string[] lastNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private Queue loginQueue;
    public int startingPlayers = 6;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(firstNames.Length);
        InitializeQueue();

    }

    void InitializeQueue()
    {
        for (int i = 0; i < startingPlayers; i++)
        {

        }
    }

    void EnqueueRandomPlayer()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
