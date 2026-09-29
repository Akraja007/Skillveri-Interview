using System.Collections.Generic;
using UnityEngine;

namespace Skillveri
{
    public interface IPathFindStrategy
    {
        List<Vector3> FindPath(Vector3 start, Vector3 target);
    }
    public class PatrolState : IState
    {
        private readonly Transform _agent;
        private readonly Transform[] _patrolPoints;
        private readonly IPathFindStrategy _pathFindStrategy;

        private List<Vector3> _path;
        private int _currentPathIndex;

        private const float ReachDistance = 0.2f;
        private const float moveSpeed = 5f;

        public PatrolState(
            Transform agent,
            Transform[] patrolPoints,
            IPathFindStrategy pathFindStrategy)
        {
            _agent = agent;
            _patrolPoints = patrolPoints;
            _pathFindStrategy = pathFindStrategy;
        }

        public void OnEnter()
        {
            _currentPathIndex = 0;

            if (_patrolPoints == null || _patrolPoints.Length == 0)
                return;

            CreatePath();
        }

        public void OnUpdate()
        {
            if (_path == null || _path.Count == 0)
                return;

            Vector3 target = _path[_currentPathIndex];
            Vector3 targetDir = target - _agent.position;

            MoveAndRotate(target, targetDir);
            CheckTargetReached(target);
        }

        private void CheckTargetReached(Vector3 target)
        {
            if (Vector3.Distance(_agent.position, target) <= ReachDistance)
            {
                _currentPathIndex++;

                if (_currentPathIndex >= _path.Count)
                {
                    CreateNextPatrolPath();
                }
            }
        }

        private void MoveAndRotate(Vector3 target, Vector3 targetDir)
        {
            if (targetDir.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDir);

                Vector3 targetPos = Vector3.MoveTowards(
                    _agent.position,
                    target,
                    moveSpeed * Time.deltaTime);

                _agent.SetPositionAndRotation(
                    targetPos,
                    targetRotation);
            }
        }

        public void OnExit()
        {
            _path = null;
        }

        private void CreatePath()
        {
            Vector3 target = _patrolPoints[0].position;

            _path = _pathFindStrategy.FindPath(
                _agent.position,
                target);
        }

        private void CreateNextPatrolPath()
        {
            int nextPoint = Random.Range(0, _patrolPoints.Length);

            _path = _pathFindStrategy.FindPath(
                _agent.position,
                _patrolPoints[nextPoint].position);

            _currentPathIndex = 0;
        }
    }
}
