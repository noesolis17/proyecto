using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int life;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        life = 15;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("SnowBall"))
        {
            life -= 5; if (life < 10) anim.SetBool("melt", true); if (life == 0) Destroy(this);
        }
    }
}
