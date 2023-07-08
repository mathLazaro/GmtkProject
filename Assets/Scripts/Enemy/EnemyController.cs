using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent<EnemyController> onDeath;
    [SerializeField] private float speed;
    [SerializeField] private Transform healthbar;
    private float _life = 10f;
    private float _maxlife = 10f;
    private float _hbscale;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _hbscale = healthbar.localScale.x;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.right = GameManager.Instance.princessController.transform.position - transform.position;
        
        healthbar.localScale = new Vector3(_hbscale * _life/_maxlife, healthbar.localScale.y, healthbar.localScale.z);
        if (_life <= 0)
        {
            onDeath.Invoke(this);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        _rigidbody2D.AddRelativeForce(Vector2.right * speed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Princess")) Destroy(gameObject);
    }

    public void SetLife(float life, bool setMax = true)
    {
        if (setMax)
        {
            _maxlife = life;
        }

        _life = life;
    }

    public float Damage(float value)
    {
        _life -= value;
        return _life;
    }
}