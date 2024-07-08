using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    #region variables

    [SerializeField] private ClientManager manager;
    [SerializeField] private GameObject arrowPanel;
    [SerializeField] private int maxCocaine = 10;

    [HideInInspector] public int cocaineAsked;
    [HideInInspector] public bool isMainClient;

    #endregion

    #region update

    private void Update()
    {
        ActivateArrow();
    }

    #endregion

    #region turn on/off

    public void TurnOn()
    {
        isMainClient = true;
        cocaineAsked = Random.Range(1, maxCocaine);
    }

    public void TurnOff()
    {
        isMainClient = false;
        manager.NewClient();
    }

    #endregion

    #region activate arrow

    private void ActivateArrow()
    {
        arrowPanel.SetActive(isMainClient);
    }

    #endregion
}
