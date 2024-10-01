using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PursuerMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 1;

    private Rigidbody _rigidbody;
    private float permissibleDifference = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(_player);
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_player.position - transform.position).normalized;

        if ((_player.position - transform.position).sqrMagnitude < permissibleDifference)
            return;

        _rigidbody.MovePosition(transform.position + direction * (Time.deltaTime * _speed));
    }
}