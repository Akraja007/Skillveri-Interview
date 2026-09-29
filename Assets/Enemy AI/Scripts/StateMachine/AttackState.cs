using UnityEngine;

namespace Skillveri
{
    public class AttackState : IState
    {
        private readonly ISensor<Transform> _sensor;
        private readonly Transform _agent;

        private Transform _target;
        private float moveSpeed = 10;
        private float attackRange = 3;
        public AttackState(Transform agent, ISensor<Transform> sensor)
        {
            _agent = agent;
            _sensor = sensor;
        }

        public void OnEnter()
        {
        }

        public void OnUpdate()
        {
            if (_sensor.TryDetect(out _target))
            {
                Vector3 targetDir = _target.position - _agent.position;
                if (targetDir.sqrMagnitude > attackRange * attackRange)
                {
                    MoveAndRotate(_target.position, targetDir);
                }
                else
                    AttackAnimate();
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
            _target = null;
        }

        private void AttackAnimate()
        {
            Debug.Log($"Attack: {_target.name}");
        }
    }
}
