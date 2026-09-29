using UnityEngine;

namespace Skillveri
{
    public class InteractionSensor : MonoBehaviour, ISensor<IntractableInfoSO>
    {
        [SerializeField] private float rayLength = 3;
        [SerializeField] private LayerMask layerMask;

        [SerializeField] private bool visualize;
        private RaycastHit[] _raycastHits = new RaycastHit[1];
        void Start()
        {

        }

        public bool TryDetect(out IntractableInfoSO result)
        {
            Ray ray = new(transform.position, transform.forward);

            int hitCount = Physics.RaycastNonAlloc(ray, _raycastHits, rayLength, layerMask);

            if (hitCount > 0)
            {
                result = _raycastHits[0].collider.GetComponent<IIntractable<IntractableInfoSO>>().Interact();
                return true;
            }

            result = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            if (!visualize) return;

            Gizmos.DrawLine(
                transform.position,
                transform.position + transform.forward * rayLength
            );
        }
    }
}
