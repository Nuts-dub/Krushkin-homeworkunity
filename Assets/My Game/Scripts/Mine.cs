using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _damage = 20;
        public Transform spawnPosition;
        public GameObject _explosion;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
            {
                Ray ray = new Ray(spawnPosition.position, transform.forward);
                RaycastHit _hit;
                if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
                {
                    Collider[] _col = Physics.OverlapSphere(_hit.point, 500);
                    foreach(var col in _col)
                    {
                        if(col.attachedRigidbody)
                        {
                            col.attachedRigidbody.AddForce(-(_hit.point - col.transform.position).normalized * 1000);
                        }
                    }
                }
                Debug.Log("Hit!");
                takeDamage.Hit(_damage);

                Instantiate(_explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);

                Destroy(gameObject);
            }
        }
    }

}