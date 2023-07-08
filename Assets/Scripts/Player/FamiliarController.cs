using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarController : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float interested;
    public float anglesPerSecond;
    private Transform _parent;
    private PlayerController _player;
    private Vector3 _anchorPosition;
    void Start()
    {
        _parent = transform.parent;
        _player = GameManager.Instance.playerController;
    }

    // Update is called once per frame
    void Update()
    {
        float id = transform.GetSiblingIndex();
        float totalID = _parent.childCount;
        float t = id / totalID;
        float angle = GameManager.Instance.timer * anglesPerSecond + 360 * t;
        transform.SetLocalPositionAndRotation(
            _anchorPosition + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0) * 2f,
                Quaternion.Euler(0,0,angle - 90)
                );
    }
    void LateUpdate () {
        _anchorPosition = Vector3.MoveTowards(_anchorPosition, _player.transform.position, interested);
    }
}
