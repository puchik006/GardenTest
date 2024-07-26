using UnityEngine;
using UnityEngine.UI;

public class scr_UI_HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthLevel;
    [SerializeField] private Gradient _gradient;

    public void V_ChangeHealthBalue(float health)
    {
        _healthLevel.fillAmount = Mathf.Max(0, _healthLevel.fillAmount - health);
        V_UpdateHealthBarColor();
    }

    private void V_UpdateHealthBarColor()
    {
        _healthLevel.color = _gradient.Evaluate(_healthLevel.fillAmount);
    }
}
