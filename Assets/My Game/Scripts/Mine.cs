using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _damage = 20;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                Debug.Log("Hit!");
                takeDamage.Hit(_damage);
                Destroy(gameObject);
            }
        }
    }

}