using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGames
{
    public class HealthBar : MonoBehaviour, ITakeDamage
    {
        public Image bar;
        public float fill;

        private float _durability = 100f;

        void Update()
        {
            fill = _durability/100;
            bar.fillAmount = fill;
        }

        public void Hit(float damage)
        {
            _durability -= damage;

            if (_durability <= 0)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0f;
            }
        }
    }
}