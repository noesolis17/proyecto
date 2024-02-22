using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 15;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (life == 0) Destroy(this); else life -= 5;
    }
}
