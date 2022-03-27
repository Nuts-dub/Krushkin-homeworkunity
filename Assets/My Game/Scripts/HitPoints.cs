using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public class HitPoints : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("HitPoints!");
                Destroy(gameObject);
            }
        }
    }

}