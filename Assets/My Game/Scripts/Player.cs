using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Player : MonoBehaviour
    {
        private Vector3 _direction;
        public float speed = 2f;

        public GameObject minePrefab;
        public Transform spawnPosition;
        private bool _isSpawnMine;
        public KeyCode keySpell1;

        void Update()
        {
            if (Input.GetKeyDown(keySpell1))
                _isSpawnMine = true;

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
        }
        private void FixedUpdate()
        {
            if (_isSpawnMine)
            {
                _isSpawnMine = false;
                SpawnShield();
            }
            Move(Time.fixedDeltaTime);
        }
        private void SpawnShield()
        {
            var mineObj = Instantiate(minePrefab, spawnPosition.position, spawnPosition.rotation);
            var mine = mineObj.GetComponent<Mine>();
        }
        private void Move(float delta)
        {
            transform.position += _direction * speed * delta;
        }
    }

}