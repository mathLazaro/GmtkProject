using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private ShotController shotPrefab;
    [Range(0,10)] public int rangeLevel; //range dos tiro
    [Range(0,10)] public int damageLevel; //vida dos tiro
    [Range(0,10)] public int powerLevel; //quantidade de tiro
    
    //private Action ShootAction;
    private Rigidbody2D _rigidbody2D;

    private float _physicsSpeed;
    private float _fireTimer = 0f;
    /*
    private void OnEnable() 
    {
        ShootAction += 
        ShootAction += Shoot;
    }

    private void OnDisable()
    {
        ShootAction -= AudioController.Instance.PlayFireAudio;
        ShootAction -= Shoot;
    }*/

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0,0,rotSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"),Space.Self);
        _physicsSpeed = Input.GetAxisRaw("Vertical") * speed;
        _fireTimer -= Time.deltaTime;
        if (_fireTimer <= 0 && Input.GetButton("Fire1"))
        {
            _fireTimer = fireRate;
            //ShootAction?.Invoke();
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddRelativeForce(Vector2.up * _physicsSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void Shoot()
    {
        AudioController.Instance.PlayFireAudio();
        ShotController shot = Instantiate(shotPrefab,transform);
        shot.SetProperties(Vector2.zero, 0, 30, 1 + 0.7f * damageLevel, (0.5f + 0.25f * rangeLevel)/3);
        if (powerLevel > 0)
        {
            for (int i = 1; i < (powerLevel + 1); i++)
            {
                ShotController _shot = Instantiate(shotPrefab,transform);
                _shot.SetProperties(Vector2.zero, i * 37, 30, (1 + 0.7f * damageLevel)*0.3f, (0.5f + 0.25f * rangeLevel)/3);
                _shot = Instantiate(shotPrefab,transform);
                _shot.SetProperties(Vector2.zero, -i * 37, 30, (1 + 0.7f * damageLevel)*0.3f, (0.5f + 0.25f * rangeLevel)/3);
            }
        }
    }
}
