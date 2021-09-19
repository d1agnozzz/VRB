using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour
{
    public static HashSet<Bomberman> bombers = new HashSet<Bomberman>();
    private int bombsCount;
    public GameObject bombPrefab;

    private void OnEnable()
    {
        bombers.Add(this);
        bombsCount = 2;
    }

    private void OnDisable()
    {
        bombers.Remove(this);
    }

    public void PlantBomb()
    {
        if (CanPlant())
        {
            BombsWork.Instantiate(this);
            BombPlanted();
        }
    }

    public void BombPlanted()
    {
        if (bombsCount > 0)
            bombsCount--;
    }

    public void PickBomb()
    {
        if (bombsCount < 2)
        {
            bombsCount++;
        }
    }

    public bool CanPlant()
    {
        return bombsCount != 0;
    }

    

    public static bool IsThereBombers()
    {
        if (bombers.Count == 0)
            return false;
        return true;
    }

    public static HashSet<Bomberman> FindBombersWithinRange(Vector3 location, float range)
    {
        HashSet<Bomberman> result = new HashSet<Bomberman>();

        var e = bombers.GetEnumerator();

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

    public static Bomberman FindClosestBomber(Vector3 location)
    {
        Bomberman result = null;

        var e = bombers.GetEnumerator();
        float closestDist = float.PositiveInfinity;
        while (e.MoveNext())
        {
            float dist = (e.Current.transform.position - location).sqrMagnitude;
            if (dist < closestDist && (e.Current.transform.position - location).sqrMagnitude >0.1)
            {
                result = e.Current;
                closestDist = dist;
            }
        }

        return result;
    }


}
