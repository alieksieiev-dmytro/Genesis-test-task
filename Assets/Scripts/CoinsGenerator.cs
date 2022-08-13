using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private float x1, x2, z1, z2;
    [SerializeField] private float y;
    [SerializeField] private Coin coinPrefab;
    
    private void Start()
    {
        SpawnNewCoin();
    }

    private Vector3 GenerateCoords()
    {
        float x = Random.Range(x1, x2);
        float z = Random.Range(z1, z2);

        return new Vector3(x, y, z);
    }

    private void SpawnNewCoin()
    {
        var go = Instantiate(coinPrefab, GenerateCoords(), coinPrefab.transform.rotation);
        go.OnPickingUp += SpawnNewCoin;
        go.OnPickingUp += UIManager.Instance.IncrementCoinCounter;
        go.OnDestroy += SpawnNewCoin;
    }
}
