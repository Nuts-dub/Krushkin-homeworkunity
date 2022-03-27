using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        //private void Update()
        //{
        //    if (Vector3.Distance(transform.position, _player.transform.position) < 6)
        //    {
        //        if (Input.GetMouseButtonDown(0))
        //            Fire();
        //    }
        //}

        void FixedUpdate()
        {
            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward,
                    direction,
                    _speedRotate * Time.fixedDeltaTime,
                    0f);

            if (Vector3.Distance(transform.position, _player.transform.position) < 6)
            {
                if (Input.GetMouseButtonDown(0))
                    Fire();
                transform.rotation = Quaternion.LookRotation(stepRotate);
            }
            
        }

        private void Fire()
        {
            var shieldObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform, 10, 3f);
        }
    }
}