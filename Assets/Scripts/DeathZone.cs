using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
     // Debug.Log($"new:{UIHundler.hundler.Score},old:{UIHundler.hundler.OldScore}");

        UIHundler.hundler.Save();
        

        Manager.GameOver();
    }
}
