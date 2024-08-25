using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private BoxCollider2D _boundries;
    [SerializeField] private Transform _CatThrowTransform;

    private Bounds _bounds;

    private float _leftBound;
    private float _rightBound;

    private float _startingLeftBound;
    private float _startingRightBound;

    private float _offset;

    private void Awake()
    {
        _bounds = _boundries.bounds;

        _offset = transform.position.x - _CatThrowTransform.position.x;

        _leftBound = _bounds.min.x + _offset;
        _rightBound = _bounds.max.x + _offset;

        _startingLeftBound = _leftBound;
        _startingRightBound = _rightBound;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position + new Vector3(UserInput.MoveInput.x * _moveSpeed * Time.deltaTime, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, _leftBound, _rightBound);

        transform.position = newPosition;
    }

    public void ChangeBoundry(float extraWidth)
    {
        _leftBound = _startingLeftBound;
        _rightBound = _startingRightBound;

        _leftBound += ThrowMochiController.instance.Bounds.extents.x + extraWidth;
        _rightBound -= ThrowMochiController.instance.Bounds.extents.x + extraWidth;
    }
}
