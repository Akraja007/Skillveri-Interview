using System;
using UnityEngine;


namespace Skillveri
{
    [RequireComponent(typeof(InteractionSensor))]
    public class Player : MonoBehaviour
    {
        public event Action<IntractableInfoSO> OnInteract;
        private InteractionSensor interactionSensor;

        void Start()
        {
            interactionSensor = GetComponent<InteractionSensor>();
        }

        void FixedUpdate()
        {
            if (interactionSensor.TryDetect(out IntractableInfoSO result))
            {
                OnInteract?.Invoke(result);
            }
        }
    }
}