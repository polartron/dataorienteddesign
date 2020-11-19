using TMPro;
using UnityEngine;

namespace Example2
{
    public class PlayerGUIV2 : MonoBehaviour
    {
        [SerializeField] private Gradient _healthGradient;
        [SerializeField] private TMP_Text _healthText;

        public void SetHealth(float health, float maxHealth)
        {
            float healthPercentage = health / maxHealth;
            _healthText.text = health.ToString("N0");
            _healthText.color = _healthGradient.Evaluate(healthPercentage);
        }
    }
}
