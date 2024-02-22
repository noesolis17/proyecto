using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab, _prefabSnow, _parent, _effect;
    private GameObject thing;
    private Vector3 forw;
    private bool flag;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Ball();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
#else
        if (Input.touchCoutn > 0)
#endif
        {
            forw = Camera.main.transform.forward;
            if (thing.TryGetComponent(out Rigidbody rb))
            {
                thing.GetComponent<Rigidbody>().useGravity = true;
                rb.AddForce(forw * 200.0f);
            }
        }

        if (thing.transform.position.y < -100)
        {
            Ball();
        }

        if (thing.GetComponent<BallSystem>().flag)
        {
            _effect = Instantiate(_effect, thing.transform.position, Quaternion.identity);
            _effect.GetComponent<ParticleSystem>().Play();
        }

        if (!_effect) if (!_effect.GetComponent<ParticleSystem>().isPlaying) Destroy(_effect);

    }
    void Ball()
    {
        if (!thing) Destroy(thing);
        thing = Instantiate(_prefab, _parent.transform);
        thing.transform.position = new Vector3(0, -0.3f, 0.5f);
        thing.GetComponent<Rigidbody>().useGravity = false;
    }
}
