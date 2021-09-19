using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBombWork : MonoBehaviour
{
    [SerializeField] GameObject explod;
    [SerializeField] Collider newCollider;
    [SerializeField] bool d_enableTimer = true;
    private Bomberman owner;
    bool collideWithPlayer = false;
    float timeOfTrigger = 0.5f, timer = 3.0f;
    RespawnProvider Bombs;
    private static HashSet<ExpBombWork> bombSet = new HashSet<ExpBombWork>();    

    public void SetOwner(Bomberman _owner) {
        owner = _owner;
    }

    private void Awake()
    {
        Bombs = GameObject.Find("XR Rig").GetComponent<RespawnProvider>();
    }

    private void OnEnable()
    {
        bombSet.Add(this);
    }
    
    private void OnDisable()
    {
        bombSet.Remove(this);
    }

    public static ExpBombWork FindClosestBomb(Vector3 location)
    {
        ExpBombWork result = null;
        float closestDist = float.PositiveInfinity;

        var e = bombSet.GetEnumerator();

        while (e.MoveNext())
        {
            float dist = (e.Current.transform.position - location).sqrMagnitude;
            if (dist < closestDist)
            {
                result = e.Current;
                closestDist = dist;
            }
        }
        return result;
    }

    public static HashSet<ExpBombWork> FindBombsWithinRange(Vector3 location, float range)
    {
        HashSet<ExpBombWork> result = new HashSet<ExpBombWork>();

        var e = bombSet.GetEnumerator();
        while (e.MoveNext())
        {
            float dist = (e.Current.transform.position - location).sqrMagnitude;
            if (dist <= range * range)
            {
                result.Add(e.Current);
            }
        }

        return result;
    }

    public static bool IsThereBombs()
    {
        if (bombSet.Count == 0)
            return false;
        return true;
    }

    private void Update()
    {
        timeOfTrigger -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timeOfTrigger < 0 && !collideWithPlayer)
            newCollider.isTrigger = false;
        if (timer < 0 && d_enableTimer)
        {
            Bombs.bombsNumber++;
            if (owner != null)
            {
                Debug.Log("Bomb picked for " + owner.name);
                owner.PickBomb();
            }
            Instantiate(explod, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + " entered");
        if (other.gameObject.name == "XR Rig")
            collideWithPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name + " exited");
        if (other.gameObject.name == "XR Rig")
            collideWithPlayer = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Bombs.bombsNumber++;
        Debug.Log("Bomb picked for " + owner.name);
        Instantiate(explod, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        owner.PickBomb();
       
        Destroy(gameObject);
    }
}
