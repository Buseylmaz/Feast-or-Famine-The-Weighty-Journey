using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PassPanel: MonoBehaviour
{
    [Header("Scene Manager")]
    public GameObject[] panels; 
    private int currentPanelIndex = 0;


    private void Awake()
    {
        GetComponent<AudioManager>();
    }

    void Start()
    {
        ActivatePanel(0);
    }

    public void ActivatePanel(int panelIndex)
    {
        //SFX-Button
        AudioManager.Instance.PlaySFX("Click");
        //


        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        panels[panelIndex].SetActive(true);
        currentPanelIndex = panelIndex;
    }


    //Go to the next one of the current panel
    public void NextPanel()
    {
        int nextIndex = (currentPanelIndex + 1) % panels.Length;
        ActivatePanel(nextIndex);
    }

    //Go to the previous one of the current panel
    public void PreviousPanel()
    {
        int previousIndex = (currentPanelIndex - 1 + panels.Length) % panels.Length;
        ActivatePanel(previousIndex);
    }


    
}
