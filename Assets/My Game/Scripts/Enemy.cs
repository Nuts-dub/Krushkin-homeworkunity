using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyGames
{
    public class Enemy : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _speedRotate;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _cooldown;
        [SerializeField] private bool _isFire;

        private float _durability = 10f;

        void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        void FixedUpdate()
        {
            var direction = _player.transform.position - transform.position;
            var stepRotate = Vector3.RotateTowards(transform.forward,
                    direction,
                    _speedRotate * Time.fixedDeltaTime,
                    0f);
            Ray ray = new Ray(_spawnPosition.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 6))
                if (hit.collider.CompareTag("Player"))
                {
                    if (_isFire)
                        Fire();
                    transform.rotation = Quaternion.LookRotation(stepRotate);
                }
        }

        public void Init(float durability)
        {
            _durability = durability;
            Destroy(gameObject, 10f);
        }

        public void Hit(float damage)
        {
            _durability -= damage;

            if (_durability <= 0)
                Destroy(gameObject);
        }

        private void Fire()
        {
            _isFire = false;
            var shieldObj = Instantiate(_bulletPrefab, _spawnPosition.position, _spawnPosition.rotation);
            var shield = shieldObj.GetComponent<Bullet>();
            shield.Init(_player.transform, 10, 3f);

            Invoke(nameof(Reloading), _cooldown);
        }

        private void Reloading()
        {
            _isFire = true;
        }
    }
}