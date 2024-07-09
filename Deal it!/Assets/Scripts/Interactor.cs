using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    #region variables

    [SerializeField] private Dealer dealer;
    [SerializeField] private TextMeshProUGUI dealerText;
    [SerializeField] private TextMeshProUGUI clientText;
    [SerializeField] private float scanDistance = 5;

    /*[HideInInspector] */public int currentCocaine;

    private Client client;

    private bool canGrab;
    private bool canGive;

    #endregion

    #region update

    private void Update()
    {
        ScanForInteraction();
        UpdateText();
    }

    #endregion

    #region input

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        if (canGrab)
        {
            currentCocaine += dealer.batchAmount;
        }

        if (canGive)
        {
            if (currentCocaine < client.cocaineAsked)
            {
                return;
            }

            canGive = false;
            currentCocaine -= client.cocaineAsked;
            client.TurnOff();
            client = null;
        }
    }

    #endregion

    #region text

    private void UpdateText()
    {
        if (canGrab)
        {
            dealerText.gameObject.SetActive(true);
            clientText.gameObject.SetActive(false);
        }
        else if (canGive)
        {
            dealerText.gameObject.SetActive(false);
            clientText.gameObject.SetActive(true);
        }
        else
        {
            dealerText.gameObject.SetActive(false);
            clientText.gameObject.SetActive(false);
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
            Client hitClient = hit.transform.GetComponent<Client>();

            if (hitDealer != null)
            {
                canGive = false;
                canGrab = true;
            }
            else if (hitClient != null)
            {
                if (!hitClient.isMainClient)
                {
                    return;
                }

                client = hitClient;
                canGrab = false;
                canGive = true;
            }
            else
            {
                canGrab = false;
                canGive = false;
            }
        }
    }

    #endregion
}
