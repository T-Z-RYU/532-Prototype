using System;
using DG.Tweening;
using EPOOutline;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Outlinable outlinable;
    
    private bool _isNearPlayer;

    private void Start()
    {
        FloatUpDown();
    }

    private void FloatUpDown()
    {
        float floatDistance = 0.075f;
        float floatDuration = 0.25f;
        transform.DOLocalMoveY(transform.position.y + floatDistance, floatDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isNearPlayer = true;
            other.GetComponent<Player>().nearbyEntity = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isNearPlayer = false;
        }
    }

    private void Update()
    {
        if (_isNearPlayer)
        {
            outlinable.enabled = true;
        }
        else
        {
            outlinable.enabled = false;
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
