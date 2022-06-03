using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderScript : MonoBehaviour
{
    private Text _scoreObject;
    private DateTime _lifeStart;

    private void Start()
    {
        _scoreObject = GameObject.FindWithTag("ScoreTbx").GetComponent<Text>();
        _lifeStart = DateTime.Now;
    }

    private void Update()
    {
        if (DateTime.Now > _lifeStart + TimeSpan.FromSeconds(15))
        {
            Storage.CurrentMoneyCount -= 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        Storage.CurrentMoneyCount -= 1;
        Storage.CurrentScore++;
        _scoreObject.text = $"Score: {Storage.CurrentScore}";
        Destroy(gameObject);
    }
}
