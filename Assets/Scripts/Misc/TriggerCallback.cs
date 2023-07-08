using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCallback : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public UnityEvent OnStay;
    [SerializeField] private string tagCompare;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(tagCompare))
            OnEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(tagCompare))
            OnExit.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag(tagCompare))
            OnStay.Invoke();
    }

}
