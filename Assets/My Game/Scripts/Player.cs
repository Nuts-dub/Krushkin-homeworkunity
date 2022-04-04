using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _anim;

        private Vector3 _direction;
        public float speed = 2f;
        public float speedRotate = 20f;
        private bool _isSprint;
        [SerializeField] private float _jumpForce = 10;

        public GameObject minePrefab;
        public Transform spawnPosition;
        private bool _isSpawnMine;
        public KeyCode keySpell1;
        public KeyCode keySpell2;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(keySpell1))
                _isSpawnMine = true;

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            _anim.SetBool("IsWalk", _direction != Vector3.zero);

            _isSprint = Input.GetButton("Sprint");

            if (Input.GetKeyDown(keySpell2))
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        private void FixedUpdate()
        {
            if (_isSpawnMine)
            {
                _isSpawnMine = false;
                SpawnMine();
            }
            Move(Time.fixedDeltaTime);

            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0));
        }
        private void SpawnMine()
        {
            var mineObj = Instantiate(minePrefab, spawnPosition.position, spawnPosition.rotation);
            var mine = mineObj.GetComponent<Mine>();
        }
        private void Move(float delta)
        {
            var fixedDirection = transform.TransformDirection(_direction.normalized);
            transform.position += fixedDirection * (_isSprint ? speed * 2 : speed) * delta;
        }
    }

}