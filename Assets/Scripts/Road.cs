using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = 0.7071f;

    public void CreateNewRoadPart()
    {
        Debug.Log("Creating new");
        Vector3 spawnPos = Vector3.zero;

        //define spawn chance (spawn either left or right)
        float spawnChance = Random.Range(0, 100);
        if (spawnChance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        //update position when spawning new road object
        lastPos = g.transform.position;

        //activate/spawn crystal with 20% chance 
        float crystalSpawnChance = Random.Range(1, 10);
        if (crystalSpawnChance >= 8) 
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void StartBuildingRoad()
    {
        InvokeRepeating("CreateNewRoadPart", 0.5f, 0.45f);
    }
    
}
