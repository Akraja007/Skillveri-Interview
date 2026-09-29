using UnityEngine;

namespace Skillveri
{
    public class StateMachine : MonoBehaviour
    {
        private IState _currentState;

        private void Update()
        {
            _currentState?.OnUpdate();
        }

        public void Transition(IState newState)
        {
            if (newState == null) return;

            _currentState?.OnExit();

            _currentState = newState;

            _currentState.OnEnter();
        }
    }
}
