using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem ps;
    float timer = 0f;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = ps.main.startLifetime.constantMax;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            gameObject.SetActive(false);
        }
    }
}
