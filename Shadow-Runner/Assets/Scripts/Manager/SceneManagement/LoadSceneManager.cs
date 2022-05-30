using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    [SerializeField] private GameObject loadingPanel;


    private List<AsyncOperation> scenesCurrentlyLoading = new List<AsyncOperation>();

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndex.TitleCard, LoadSceneMode.Additive);
    }

    public void LoadLevel()
    {
        loadingPanel.SetActive(true);
        scenesCurrentlyLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndex.TitleCard));
        scenesCurrentlyLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndex.Level1, LoadSceneMode.Additive));
        StartCoroutine(CheckSceneProgress());
    }

    public IEnumerator CheckSceneProgress() 
    {
        for (int i = 0; i < scenesCurrentlyLoading.Count; i++) 
        {
            while (!scenesCurrentlyLoading[i].isDone) 
            {
                yield return new WaitForSeconds(3f);
            }
        }

        loadingPanel.SetActive(false);
        SceneManager.UnloadSceneAsync((int)SceneIndex.LoadManager);
    }
}
