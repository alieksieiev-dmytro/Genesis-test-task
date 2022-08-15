using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private GameObject errorMessage;
    
    public List<string> keys = new List<string>();

    private AsyncOperationHandle<IList<GameObject>> loadHandle;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void HandleOnCompleted(AsyncOperationHandle<IList<GameObject>> asyncOperationHandle)
    {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            var sceneLoad = SceneManager.LoadSceneAsync("Scene_2");
            sceneLoad.completed += operation =>
            {
                foreach (var go in asyncOperationHandle.Result)
                {
                    Instantiate(go, Vector3.zero, Quaternion.identity);
                }
            };
        }
        else
        {
            errorMessage.SetActive(true);
        }
    }

    public void LoadAssets()
    {
        loadHandle = Addressables.LoadAssetsAsync<GameObject>(keys, addressable => {}, Addressables.MergeMode.Union, true);
        loadHandle.Completed += HandleOnCompleted;
    }

    public void LoadLevel(float delay)
    {
        StartCoroutine(LoadLevel_Coroutine(delay));
    }

    private IEnumerator LoadLevel_Coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadAssets();
    }
}
