﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBlock : MonoBehaviour
{
#if UNITY_EDITOR
    public BlockData BlockData;

#endif
    [SerializeField] private ParticleSystem _particle = null;

    private void Start()
    {
        _particle = Instantiate(_particle, gameObject.transform.position, Quaternion.identity);
        _particle.transform.SetParent(gameObject.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _particle.Simulate(.0f, true, true);
        _particle.transform.position = collision.contacts[0].point;
        _particle.Play();
    }
}
