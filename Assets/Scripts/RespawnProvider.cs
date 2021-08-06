using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class RespawnProvider : MonoBehaviour
{
    [SerializeField] GameObject exploding;
    [SerializeField] float slowChance = 0.33f, LPChance = 0.33f, diseaseTime = 10.0f;
    public float slowDiseaseTime = 10.0f, LPDiseaseTime = 10.0f;
    public int bombsNumber = 1;
    public float bombsRadius = 0.1f;
    public bool slow = false, LP = false;
    float rand;
    Scene scene;
    ActionBasedContinuousMoveProvider continuousMoveProvider;
    BombsCreating Bombs1, Bombs2;
    Counter counter;

    private void Start()
    {
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        continuousMoveProvider = GameObject.Find("XR Rig").GetComponent<ActionBasedContinuousMoveProvider>();
        Bombs1 = GameObject.Find("LeftHand Controller").GetComponent<BombsCreating>();
        Bombs2 = GameObject.Find("RightHand Controller").GetComponent<BombsCreating>();
    }

    [System.Obsolete]
    private void Update()
    {
        if (slow)
        {
            slowDiseaseTime -= Time.deltaTime;
            if (slowDiseaseTime > 0 && continuousMoveProvider.moveSpeed > 0.15f)
                continuousMoveProvider.moveSpeed = 0.1f;
            else if (slowDiseaseTime < 0)
            {
                continuousMoveProvider.moveSpeed = 1.0f;
                slow = false;
            }
        }
        if (LP)
        {
            LPDiseaseTime -= Time.deltaTime;
            if (LPDiseaseTime > 0 && exploding.GetComponent<ParticleSystem>().startLifetime > 0.15f)
                exploding.GetComponent<ParticleSystem>().startLifetime = 0.1f;
            else if (LPDiseaseTime < 0)
            {
                exploding.GetComponent<ParticleSystem>().startLifetime = bombsRadius;
                LP = false;
            }
        }
        else if (exploding.GetComponent<ParticleSystem>().startLifetime != bombsRadius)
        {
            exploding.GetComponent<ParticleSystem>().startLifetime = bombsRadius;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        counter.looses++;
        if (counter.looses == 2)
        {
            counter.wins = 0;
            counter.looses = 0;
        }
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name.Contains("RUp"))
        {
            bombsRadius += 0.1f;
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.name.Contains("BUp"))
        {
            bombsNumber++;
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.name.Contains("Skull"))
        {
            rand = Random.Range(0.0f, 1.0f);
            LPDiseaseTime = -1.0f;
            slowDiseaseTime = -1.0f;
            Bombs1.diseaseTime = -1.0f;
            Bombs2.diseaseTime = -1.0f;
            if (rand < slowChance)
            {
                slow = true;
                slowDiseaseTime = diseaseTime;
            }
            else if (rand < slowChance + LPChance)
            {
                LP = true;
                LPDiseaseTime = diseaseTime;
            }
            else
            {
                Bombs1.diseaseTime = diseaseTime;
                Bombs2.diseaseTime = diseaseTime;
            }
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.name == "KillZone")
        {
            counter.looses++;
            if (counter.looses == 2)
            {
                counter.wins = 0;
                counter.looses = 0;
            }
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }    
    }
}
