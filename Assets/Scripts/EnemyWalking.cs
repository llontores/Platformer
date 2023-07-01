using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private SpriteRenderer _sr;
    private Transform[] _points;
    private int _counter;
    private int _leftEdge;
    private int _rightEdge;

    private void Start()
    {
        _leftEdge = 0;
        _rightEdge = 1;
        _sr = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
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

        if (_counter == _leftEdge)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX= false;
        }
    }
}
