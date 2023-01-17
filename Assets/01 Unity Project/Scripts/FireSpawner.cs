using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;
    public float spawnTermMin = 0.5f;
    public float spawnTermMax = 3f;
    public Transform targetTransform;

    private float spawnTerm;
    private float timeAfterSpawn = 0f;


    // Start is called before the first frame update
    void Start()
    {
        spawnTerm = Random.Range(spawnTermMin, spawnTermMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        transform.LookAt(targetTransform);

        if (timeAfterSpawn >= spawnTerm)
        {
            GameObject fireGO = Instantiate(firePrefab, transform.position, Quaternion.Euler(Vector3.zero));
            fireGO.transform.LookAt(targetTransform);

            spawnTerm = Random.Range(spawnTermMin, spawnTermMax);
            timeAfterSpawn = 0f;
        }
    }
}