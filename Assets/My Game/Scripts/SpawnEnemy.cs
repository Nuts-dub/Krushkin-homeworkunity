using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

namespace MyGames
{
    public class SpawnEnemy : MonoBehaviour
    {
        public GameObject slimePrefab;
        public Transform spawnPosition;

        void Start()
        {
            // ������� ������� �� ������� �� �� �����...
            for (int i = 0; i < 4; i++)   // ������ ������� ����� 4 �����
                EnemySpawn();
        }

        void Update()
        {

        }

        private void EnemySpawn()
        {
            var enemy = Instantiate(slimePrefab, spawnPosition.position, spawnPosition.rotation);
        }
    }

}