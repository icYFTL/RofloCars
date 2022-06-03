using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptButtonKek : MonoBehaviour
{
    public void StartScene(){
        Application.LoadLevel("SampleScene");
    }

    public void Options(GameObject window){
        window.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }
}