using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShotController : MonoBehaviour
{
    private float _velocity;
    private float _damage;
    private float _time;
    private float _timer;
    void Awake()
    {
        _velocity = 0;
        _damage = 0;
        _time = 1;
        _timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        EnemyController enemy = col.GetComponent<EnemyController>();
        enemy.Damage(_damage);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * _velocity * Time.fixedDeltaTime);
        _timer += Time.fixedDeltaTime;
        if (_timer >= _time)
        {
            Destroy(gameObject);
        }
    }

    public void SetProperties(Vector2 position, float angle = 0f, float velocity = 5f, float damage = 1f, float time = 1f)
    {
        //angle *= -Mathf.Deg2Rad;
        transform.SetLocalPositionAndRotation(new Vector3(position.x, position.y, 0), Quaternion.Euler(0,0,angle));
        _velocity = velocity;
        _damage = damage;
        _time = time;
        transform.SetParent(null,true);
    }
}
