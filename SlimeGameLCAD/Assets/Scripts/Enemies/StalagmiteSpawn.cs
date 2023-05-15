using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteSpawn : MonoBehaviour
{
    [SerializeField] private Transform StalagmiteSpawnPoint;
    [SerializeField] private GameObject[] stalagmites;

    public void DropStalagmite()
    {
        stalagmites[0].transform.position = StalagmiteSpawnPoint.position;

    }

    private int FindStalagmites()
    {
        for (int i = 0; i < stalagmites.Length; i++)
        {
            if (!stalagmites[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
