using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Enemy : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private Player _player;

        private float _durability = 10f;
        void Start()
        {
            _player = FindObjectOfType<Player>();
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
    }
}