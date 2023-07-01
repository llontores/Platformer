using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _counter;
    private int _leftEdgeIndex = 1;
    private int _rightEdgeIndex = 1;
    private Transform _leftEdge;
    private Transform _rightEdge;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _leftEdge = _points[_leftEdgeIndex];
        _rightEdge = _points[_rightEdgeIndex];
    }

    private void Update()
    {
        Transform target = _points[_counter];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _counter++;

            if(_counter >= _points.Length)
            {
                _counter = 0;
            }
        }

        if (transform.position == _leftEdge.position)
            _spriteRenderer.flipX = true;       
        else
            _spriteRenderer.flipX= false;
    }
}
