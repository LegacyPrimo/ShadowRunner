using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField] private GameObject congratulationsMessage;
    [SerializeField] private GameObject creatorMessage;
    [SerializeField] private GameObject creditsMessage;

    // Start is called before the first frame update
    void Start()
    {
        congratulationsMessage.SetActive(true);
        Invoke("EnableCreatorMessage", 12f);
    }

    private void EnableCreatorMessage() 
    {
        congratulationsMessage.SetActive(false);
        creatorMessage.SetActive(true);
        Invoke("EnableCreditsMessage", 12f);
    }

    private void EnableCreditsMessage() 
    {
        creatorMessage.SetActive(false);
        creditsMessage.SetActive(true);
        Invoke("ResetToStart", 12f);
    }

    private void ResetToStart() 
    {
        SceneManager.LoadScene((int)SceneIndex.LoadManager);
    }
}
