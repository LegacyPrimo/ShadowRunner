using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioSource menuClickAudioSource;
    [SerializeField] private FloatValue deathCounter;

    private void Awake()
    {
        menuClickAudioSource = GetComponent<AudioSource>();
    }

    public void LoadStartScene() 
    {
        menuClickAudioSource.Play();
        deathCounter.runtimeValue = 0;
        StartCoroutine(DelayStartSequence());
    }

    private IEnumerator DelayStartSequence() 
    {
        yield return new WaitForSeconds(1f);
        LoadSceneManager.instance.LoadLevel();
    }
}
