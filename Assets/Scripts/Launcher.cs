using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject _prefab;
    public GameObject _prefabSnow;
    private GameObject thing;
    private Vector3 forw;
    private bool flag;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        flag = false;
        thing = Instantiate(_prefab, Camera.main.transform.position, Quaternion.identity);
    }

    void Update()
    {
        //nota
        if (!flag)
        {
            thing.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 0.43f, Camera.main.transform.position.z + 0.6f);
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCoutn > 0)
#endif
        {
            forw = Camera.main.transform.forward;

            if (thing.TryGetComponent(out Rigidbody rb))
            {
                flag = true;
                rb.AddForce(forw * 200.0f);
            }
        }

        if (flag && thing.transform.position.y < -100)
        {
            flag = false;
        }

    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Instantiate(_prefabSnow, thing.transform.position, Camera.main.transform.rotation);
        Destroy(thing);
        flag = false;
        thing = Instantiate(_prefab, Camera.main.transform.position, Quaternion.identity);
    }
}
