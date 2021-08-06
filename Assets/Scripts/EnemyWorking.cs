using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWorking : MonoBehaviour
{
    [SerializeField] string nextScene;
    Counter counter;

    private void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<Counter>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 2)
        {
            counter.wins++;
            if (counter.wins == 2)
            {
                counter.wins = 0;
                counter.looses = 0;
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        Destroy(gameObject);
    }

}
