using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWSpawn : MonoBehaviour
{
    [SerializeField] GameObject DW;
    int width = 11, height = 11;
    [SerializeField] float chance = 0.5f;
    void Start()
    {
        for (int i = 0; i < width - 2; i++)
            if (Random.value < chance)
                Instantiate(DW, new Vector3(i + 2.5f, 0.5f, -5.5f), Quaternion.identity);
        for (int i = 0; i < width / 2; i++)
            if (Random.value < chance)
                Instantiate(DW, new Vector3(i * 2 + 2.5f, 0.5f, -6.5f), Quaternion.identity);
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height / 2; j++)
                if (Random.value < chance)
                    Instantiate(DW, new Vector3(i + 0.5f, 0.5f, - j * 2 - 7.5f), Quaternion.identity);
        for (int i = 0; i < width / 2 + 1; i++)
            for (int j = 0; j < height / 2 - 1; j++)
                if (Random.value < chance)
                    Instantiate(DW, new Vector3(i * 2 + 0.5f, 0.5f, - j * 2 - 8.5f), Quaternion.identity);

    }
}
