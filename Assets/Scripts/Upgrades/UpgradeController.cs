using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeController : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.right = GameManager.Instance.playerController.transform.position - transform.position;
    }
    void FixedUpdate()
    {
        _rigidbody2D.AddRelativeForce(Vector2.right * speed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    public void AddPlayerRange()
    {
        GameManager.Instance.playerController.rangeLevel += 1;
        Destroy(gameObject);
    }

    public void AddPlayerPower()
    {
        GameManager.Instance.playerController.powerLevel += 1;
        Destroy(gameObject);
    }
    
    public void AddPlayerDamage()
    {
        GameManager.Instance.playerController.damageLevel += 1;
        Destroy(gameObject);
    }
    public void AddFamiliar(FamiliarController familiarPrefab)
    {
        Instantiate(familiarPrefab, GameManager.Instance.familiarManager);
        Destroy(gameObject);
    }
}
