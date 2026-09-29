using TMPro;
using UnityEngine;

namespace Skillveri
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private TextMeshProUGUI nameTextMesh;
        [SerializeField] private TextMeshProUGUI infoTextMesh;

        void OnEnable()
        {
            player.OnInteract += PaintUI;
        }

        void OnDisable()
        {
            player.OnInteract -= PaintUI;
        }

        public void PaintUI(IntractableInfoSO infoData)
        {
            nameTextMesh.text = $"name: {infoData.Name}";
            infoTextMesh.text = $"info: {infoData.Info}";
        }
    }
}
