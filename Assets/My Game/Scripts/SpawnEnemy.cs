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
        public int spawnCount;

        void Start()
        {
            // пытался сделать по таймеру но не вышло...
            for (int i = 0; i < spawnCount; i++)   // просто создаст разом 4 клона
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