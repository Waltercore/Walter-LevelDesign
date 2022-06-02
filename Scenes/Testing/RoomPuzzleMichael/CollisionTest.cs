using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField] private GameObject _gm;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = _gm.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        Debug.Log("It has Collided");
    }
}
