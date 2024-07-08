using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private Client[] clients;

    private int currentClient;

    private void Start()
    {
        NewClient();
    }

    public void NewClient()
    {
        int ramdomizedValue = Random.Range(0, clients.Length);

        if (ramdomizedValue == currentClient)
        {
            NewClient();
            return;
        }

        currentClient = ramdomizedValue;
        clients[ramdomizedValue].TurnOn();
    }
}
