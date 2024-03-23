using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    [Header("Panel")]
    public GameObject startPanel; 
    public GameObject[] otherPanels;


    private void Awake()
    {
        GetComponent<AudioManager>();
    }

    void Start()
    {
        ActivatePanel(startPanel);
    }

    public void ActivatePanel(GameObject panelToActivate)
    {
        //SFX-Button
        AudioManager.Instance.PlaySFX("Click");
        //


        foreach (GameObject panel in otherPanels)
        {
            panel.SetActive(false);
        }

        panelToActivate.SetActive(true);
    }
}
