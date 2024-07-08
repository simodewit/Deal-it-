using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private Client[] clients;

    private void Start()
    {
        NewClient();
    }

    public void NewClient()
    {
        int ramdomizedValue = Random.Range(0, clients.Length);
        clients[ramdomizedValue].TurnOn();
    }
}
