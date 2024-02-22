using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject objectSystem;
    public bool flag;

    void Start()
    {
        flag = false;
    }

    void Update()
    {

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        flag = true;
    }
}
