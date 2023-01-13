using System.Collections;
using UnityEngine;

public class SpeedMoveSetting : MonoBehaviour
{
    [Header("Speed settings")]
    [SerializeField] private float _timeAddSpeed = 32.5f;
    [SerializeField] private float _zeroSpeed = 5f;
    [SerializeField] private float _maxSpeed = 30f;
    [SerializeField] private float _chandeSpeedOn = 0.5f;
    public static float _speedMove;
    private IEnumerator _changeSpeedCoroutinue;
    
    private void Start()
    {
        _changeSpeedCoroutinue = ChangeSpeed();
        StartCoroutine(_changeSpeedCoroutinue);
    }

    private IEnumerator ChangeSpeed()
    {
        while(_zeroSpeed < _maxSpeed){
            _speedMove = _zeroSpeed;

            yield return new WaitForSeconds(_timeAddSpeed);

            _zeroSpeed += _chandeSpeedOn;
        }
    }
}
