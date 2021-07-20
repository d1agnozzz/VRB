using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBelt : MonoBehaviour
{
    [SerializeField] Transform parent;
    void Update()
    {
        transform.position = new Vector3(parent.position.x, parent.position.y/2, parent.position.z);
    }

}
