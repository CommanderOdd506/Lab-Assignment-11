using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoginSimulator : MonoBehaviour
{
    private static string[] firstNames = { "Todd", "Jesh", "Daniel", "Tyler", "Trevor", "Parker", "Grace", "Jared", "Stephanie", "Alex", "Danny", "Xavier", "Mykaleigh", "Olivia", "Peter", "Wendy", "Pitbull", "Karen", "Mitch", "Max" };
    private static string[] lastNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private Queue<string> loginQueue;
    public int startingPlayers = 6;

    public float addInterval;
    public float subtractInterval;

    //Duplicate Name Detector variables

    string[] namesArray = new string[15];
    HashSet<string> seen = new HashSet<string>();
    HashSet<string> duplicates = new HashSet<string>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeQueue();
        InitializeArray();
    }

    void InitializeQueue()
    {
        loginQueue = new Queue<string> ();
        for (int i = 0; i < startingPlayers; i++)
        {
            string name = GetRandomName ();
            loginQueue.Enqueue (name);
        }

        List<string> queueList = loginQueue.ToList();
        Debug.Log("Initial login queue created: " + string.Join(", ", queueList));

        InvokeRepeating(nameof(AddNewPlayer), 2.0f, addInterval);
        InvokeRepeating(nameof(LoginPlayer), 2.0f, subtractInterval);
    }



    string GetRandomName()
    {
        string firstname = firstNames[Random.Range(0, firstNames.Length)];
        string lastname = lastNames[Random.Range(0, lastNames.Length)];
        return firstname + " " + lastname + ".";
    }



    void AddNewPlayer()
    {
        string name = GetRandomName();
        loginQueue.Enqueue(name);
        Debug.Log(name + " is trying to login and added to the login queue.");
    }

    void LoginPlayer()
    {
        if (loginQueue.Count > 0)
        {
            string name = loginQueue.Dequeue();
            Debug.Log(name + " is now inside the game. And queue length is now " +  loginQueue.Count + ".");
        }
        else
        {
            Debug.Log("Login server is idle. No players are waiting.");
        }
    }
 

    //
    // DUPLICATE NAME DETECTOR
    // 

    void InitializeArray()
    {
        for (int i = 0; i < 15; i++)
        {
            string name = firstNames[Random.Range(0, firstNames.Length)];
            namesArray[i] = name;

        }
        Debug.Log(string.Join(", ", namesArray));
        SortDuplicateNames();
    }

    void SortDuplicateNames()
    {
        for (int i = 0; i < namesArray.Length; i++)
        {
            if (seen.Add(namesArray[i]))
            {

            }
            else
            {
                duplicates.Add(namesArray[i]);
            }
        }

        if(duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: " + string.Join(", ", duplicates));
        }
        else 
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}
