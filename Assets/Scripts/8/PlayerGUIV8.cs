using TMPro;
using UnityEngine;

namespace Example8
{
    public class PlayerGUIV8 : MonoBehaviour
    {
        [SerializeField] private Gradient _healthGradient;
        [SerializeField] private TMP_Text _healthText;

        public void SetHealth(HealthState state)
        {
            float healthPercentage = state.Health / state.MaxHealth;
            _healthText.text = state.Health.ToString("N0");
            _healthText.color = _healthGradient.Evaluate(healthPercentage);
        }
    }
}