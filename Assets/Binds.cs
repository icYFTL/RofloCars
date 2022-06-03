using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Binds : MonoBehaviour
{
    public GameObject Car;
    public Text CanBoostTbx;
    public Text ScoreTbx;

    private DateTime? _boostStart;
    private DateTime? _banStarted;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Car.transform.position = new Vector3(226.7f, 2.0f, 244.7f);
            Car.transform.rotation = Quaternion.identity;
        }

        if (Storage.CurrentScore < 5 && CanBoostTbx.color != Color.red && CanBoostTbx.color != Color.yellow)
        {
            CanBoostTbx.color = Color.red;
        }

        if (Storage.CurrentScore >= 5 && _boostStart == null && _banStarted == null)
            CanBoostTbx.color = Color.green;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_boostStart == null && !_banStarted.HasValue && Storage.CurrentScore >= 5)
            {
                Storage.CurrentScore -= 5;
                ScoreTbx.text = $"Score: {Storage.CurrentScore}";
                Storage.AccelerationMultiplier += 50;
                _boostStart = DateTime.Now;
                CanBoostTbx.color = Color.yellow;
            }
            else
            {
                Debug.Log(Storage.CurrentScore);
            }
        }

        if (_boostStart.HasValue)
        {
            if (DateTime.Now > _boostStart + TimeSpan.FromSeconds(30))
            {
                _boostStart = null;
                Storage.AccelerationMultiplier -= 50;
                _banStarted = DateTime.Now;
                CanBoostTbx.color = Color.red;
            }
        }

        if (_banStarted.HasValue)
        {
            if (DateTime.Now > _banStarted + TimeSpan.FromSeconds(30))
            {
                _banStarted = null;
                CanBoostTbx.color = Color.green;
            }
        }
    }
}
