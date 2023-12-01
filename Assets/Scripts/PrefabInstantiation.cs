using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiation : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(6, 3, 0), Quaternion.identity);
    }
}
