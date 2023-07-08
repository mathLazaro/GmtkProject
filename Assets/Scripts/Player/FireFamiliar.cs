using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFamiliar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ShotController shotPrefab;
    public float fireRate = 0.2f;
    private float _fireTimer = 0;
    private FamiliarController _mainFamiliar;
    private PlayerController _player;
    void Start()
    {
        _mainFamiliar = GetComponent<FamiliarController>();
        _player = GameManager.Instance.playerController;
    }

    // Update is called once per frame
    void Update()
    {
        _fireTimer -= Time.deltaTime;
        if (_fireTimer <= 0)
        {
            ShotController shot = Instantiate(shotPrefab,transform);
            shot.SetProperties(Vector2.zero, 0, 10, 1 + 0.7f * _player.damageLevel, (0.5f + 0.25f * _player.rangeLevel));
            _fireTimer = fireRate;
            //shot.transform.localScale *= 0.5f;
        }
        
    }
}
