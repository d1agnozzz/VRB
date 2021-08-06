using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int wins = 0, looses = 0;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Counter").Length > 1)
            if (wins + looses == 0)
                Destroy(gameObject);
        DontDestroyOnLoad(transform.gameObject);
    }
}
