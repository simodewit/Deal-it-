using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    #region variables

    [SerializeField] private TextMeshProUGUI dealerText;
    [SerializeField] private TextMeshProUGUI clientText;
    [SerializeField] private float scanDistance = 5;

    [HideInInspector] public int currentCocaine;

    private Client client;
    private Dealer dealer;

    #endregion

    #region update

    private void Update()
    {
        ScanForInteraction();
    }

    #endregion

    #region input

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        if (clientText.enabled)
        {
            if(client.cocaineAsked > currentCocaine)
            {
                return;
            }

            client.TurnOff();
            currentCocaine -= client.cocaineAsked;
        }
        else if (dealerText.enabled)
        {
            currentCocaine += dealer.batchAmount;
        }
    }

    #endregion

    #region scanning

    private void ScanForInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, scanDistance))
        {
            Dealer hitDealer = hit.transform.GetComponent<Dealer>();
            if (hitDealer != null)
            {
                dealer = hitDealer;
                clientText.enabled = false;
                dealerText.enabled = true;
                return;
            }

            Client hitClient = hit.transform.GetComponent<Client>();
            if (hitClient != null)
            {
                if (!hitClient.isMainClient)
                {
                    return;
                }

                client = hitClient;

                clientText.enabled = true;
                dealerText.enabled = false;
            }
        }
    }

    #endregion
}
