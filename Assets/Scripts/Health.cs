using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _healthChangValue = 10;

    private float _currentHealth;

    public float CurrentHealth=> _currentHealth;
    public int MaxHealth=> _maxHealth;

    public UnityAction <float> ChangeHealthBar;
  
    private void Start()
    {
        _currentHealth = _maxHealth;
        ChangeHealthBar?.Invoke(_currentHealth);
    }

    public void Damage()
    {
        _currentHealth=Mathf.Clamp( _currentHealth - _healthChangValue, 0, _maxHealth);
        ChangeHealthBar?.Invoke(_currentHealth);
    }

    public void Recovery()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _healthChangValue, 0, _maxHealth);
        ChangeHealthBar?.Invoke(_currentHealth);
    }
}
