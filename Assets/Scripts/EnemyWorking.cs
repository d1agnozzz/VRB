using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorking : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }

}
