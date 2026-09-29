using System;
using UnityEngine;

namespace Skillveri
{
    [RequireComponent(typeof(SphereSensor))]
    public class Enemy : MonoBehaviour
    {

        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private Player player;
        private StateMachine _stateMachine;
        private IdleState _idleState;
        private AttackState _attackState;
        private PatrolState _patrolState;

        private void Awake()
        {
            _stateMachine = GetComponent<StateMachine>();
        }

        private void Start()
        {
            IPathFindStrategy pathFindStrategy = new SimplePathFindStrategy();

            _idleState = new IdleState();

            _patrolState = new PatrolState(
                transform,
                patrolPoints,
                pathFindStrategy);

            _attackState = new AttackState(transform, GetComponent<SphereSensor>());
            _stateMachine.Transition(_patrolState);
        }

        public void SwitchToIdle()
        {
            _stateMachine.Transition(_idleState);
        }

        public void SwitchToAttack()
        {
            _stateMachine.Transition(_attackState);
        }

        public void SwitchToPatrol()
        {
            _stateMachine.Transition(_patrolState);
        }
    }
}
