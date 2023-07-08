using System;
using UnityEngine;

namespace Player
{
    public class IceFamiliar : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<EnemyController>().frozenCount++;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            other.GetComponent<EnemyController>().frozenCount--;
        }
    }
}