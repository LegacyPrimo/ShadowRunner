using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject settingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableInstructionsPanel() 
    {
        instructionsPanel.SetActive(true);
        settingsPanel.SetActive(false);
        PlayerController.instance.playerState = PlayerState.idle;
    }

    public void DisableInstructionsPanel() 
    {
        instructionsPanel.SetActive(false);
        PlayerController.instance.playerState = PlayerState.running;
    }

    public void EnableSettingsPanel() 
    {
        settingsPanel.SetActive(true);
        PlayerController.instance.playerState = PlayerState.idle;
    }

    public void DisableSettingsPanel() 
    {
        settingsPanel.SetActive(false);
        PlayerController.instance.playerState = PlayerState.running;
    }
}
