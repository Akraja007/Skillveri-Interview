using UnityEngine;

namespace Skillveri
{
    public class SphereSensor : MonoBehaviour, ISensor<Transform>
    {
        [SerializeField] private float radius = 5f;
        [SerializeField] private LayerMask detectionLayer;

        public bool TryDetect(out Transform result)
        {
            Collider[] colliders = Physics.OverlapSphere(
                transform.position,
                radius,
                detectionLayer
            );

            foreach (Collider collider in colliders)
            {
                if (collider.transform == transform)
                    continue;

                result = collider.transform;
                return true;
            }

            result = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawWireSphere(
                transform.position,
                radius
            );
        }
    }
}
