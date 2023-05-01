using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Health _health;
    [SerializeField] private int _speed = 10;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.ChangeHealthBar += OnChangeHealthBar;
    }

    private void OnDisable()
    {
        _health.ChangeHealthBar -= OnChangeHealthBar;
    }

    private IEnumerator ChangeSlider(float targetValue)
    {

        while (targetValue != _healthBarSlider.value)
        {
            _healthBarSlider.value = Mathf.Lerp(_healthBarSlider.value, targetValue, _speed*Time.deltaTime);

            yield return null;
        }
    }

    private void OnChangeHealthBar(float targetValue)
    {
        float normalizeTargetValue = targetValue / 100f;

        if (_coroutine!=null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine= StartCoroutine(ChangeSlider(normalizeTargetValue));
    }
}
