using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    public float speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Move(Time.fixedDeltaTime);
    }
    private void Move(float delta)
    {
        transform.position += _direction * speed * delta;
    }
}
