using TMPro;
using UnityEngine;

namespace Example1
{
    public class PlayerGUI : MonoBehaviour
    {
        [SerializeField] private Gradient _healthGradient;
        [SerializeField] private Player _player;

        [SerializeField] private TMP_Text _healthText;
    
        void Update()
        {
            float healthPercentage = _player.Health / _player.MaxHealth;
            _healthText.text = _player.Health.ToString("N0");
            _healthText.color = _healthGradient.Evaluate(healthPercentage);
        }
    }
}
