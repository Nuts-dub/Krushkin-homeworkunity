using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyGames
{
    public class Patrul : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent;
        public Transform[] waypoints;

        int _CurrentWayPointIndex;

        void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            NavMeshAgent.SetDestination(waypoints[0].position);
        }

        private void Update()
        {
            if (NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
            {
                _CurrentWayPointIndex = (_CurrentWayPointIndex + 1) % waypoints.Length;
                NavMeshAgent.SetDestination(waypoints[_CurrentWayPointIndex].position);
            }
        }
    }
}