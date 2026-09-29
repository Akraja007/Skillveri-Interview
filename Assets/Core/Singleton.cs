using UnityEngine;

namespace Skillveri
{
    [DefaultExecutionOrder(-10)]
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private bool canPersistent = true;
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning($"{name}: Instance already exists.");
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
            if (canPersistent)
                DontDestroyOnLoad(this);
        }
    }
}
