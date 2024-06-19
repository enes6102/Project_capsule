using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Capsule")
        {
            collision.transform.SetParent(null);
        }
    }
}
