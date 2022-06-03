using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GenerateCoins : MonoBehaviour
{
    public Rigidbody CarRBody;
    public GameObject CoinPrefab;
    public int MaxCoins = 5;
    void Start()
    {
        StartCoroutine(waiter());
    }

    private Tuple<float, float> GetRandomPosition()
    {
        var x = Random.Range(CarRBody.transform.position.x - 2, CarRBody.transform.position.x - 7);
        var z = Random.Range(CarRBody.transform.position.z + 2, CarRBody.transform.position.z + 7);
        // var z = CarRBody.transform.position.z;

        return new Tuple<float, float>(x, z);
    }

    IEnumerator waiter()
    {
        while (true)
        {
            if (Storage.CurrentMoneyCount < MaxCoins)
            {
                var pos = GetRandomPosition();
                Instantiate(CoinPrefab, new Vector3(pos.Item1, CarRBody.transform.position.y - 2, pos.Item2), CarRBody.transform.rotation);
                Storage.CurrentMoneyCount++;
                
            }

            yield return new WaitForSeconds(4);
        }

    }

}
