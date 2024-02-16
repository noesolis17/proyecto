using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSystem;
    private ParticleSystem particle;

    void Start()
    {        
        particle = objectSystem.GetComponent<ParticleSystem>();
        var emission = particle.emission;
        emission.enabled = true;
    }

    void Update()
    {

    }
}
