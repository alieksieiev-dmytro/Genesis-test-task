using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
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
            SceneManager.LoadScene("Scene_2");

            foreach (var go in asyncOperationHandle.Result)
            {
                Instantiate(go, Vector3.zero, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError($"AssetReference {asyncOperationHandle.DebugName} failed to load.");
        }
    }

    public void LoadAssets()
    {
        loadHandle = Addressables.LoadAssetsAsync<GameObject>(keys, addressable => {}, Addressables.MergeMode.Union, false);
        loadHandle.Completed += HandleOnCompleted;
    }
}
