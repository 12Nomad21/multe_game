using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpikes : MonoBehaviour
{
    private IEnumerator _coroutine;

    [Header("Pool settings")]
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private DisableSpikes _spikePrefab;

    private PoolMono<DisableSpikes> _pool;
    [Header("Spawn spike settings")]
    [SerializeField] private float _minYPosSpawnSpike = -3.5f;
    [SerializeField] private float _maxYPosSpawnSpike = 3.5f;
    [SerializeField] private float _xPosSpikeSpawn = 19f;
    [SerializeField] private float _minSecondsWait = 0.5f;
    [SerializeField] private float _maxSecondsWait = 1.5f;

    private void Start()
    {
        this._pool = new PoolMono<DisableSpikes>(_spikePrefab, _poolCount, this.transform); // инициализирование пула с этими параметрами
        this._pool._autoExpand = this._autoExpand; // будем указывать авторсширение пула через инспектор

        _coroutine = CreateSpike(_minYPosSpawnSpike, _maxYPosSpawnSpike, _xPosSpikeSpawn, _minSecondsWait, _maxSecondsWait);
        StartCoroutine(_coroutine);
    }

    // private void CreateSpikeFromInstantiate(){

    // }

    private IEnumerator CreateSpike(float minYPosSpawnSpike, float maxYPosSpawnSpike, float xPosSpikeSpawn, float minSecondsWait, float maxSecondsWait){
        // int _repeatCount = 0;
        // int _oldRnd = 3;

        while(true){
            var _spike = this._pool.GetFreeElement();

            int _rnd = Random.Range(0, 2);

            // if(_rnd == _oldRnd){
            //     _repeatCount++;
            // }

            // _oldRnd = _rnd;

            // if(_repeatCount >= 1){
            //     if(_rnd == 0){
            //         _rnd = 1;
            //     }
            //     else{
            //         _rnd = 0;
            //     }

            //     _repeatCount = 0;
            // }

            if(_rnd == 1){
                var _spikeRandomSpawnPosition = new Vector3(xPosSpikeSpawn, maxYPosSpawnSpike, 0);
                var _spikeRotation = new Quaternion(0, 0, 180, 0);

                _spike.transform.position = _spikeRandomSpawnPosition;
                _spike.transform.rotation = _spikeRotation;

                Debug.Log("ВЕРХ");
            }
            else{
                var _spikeRandomSpawnPosition = new Vector3(xPosSpikeSpawn, minYPosSpawnSpike, 0);

                _spike.transform.position = _spikeRandomSpawnPosition;
                _spike.transform.rotation = new Quaternion(0, 0, 0, 0);

                Debug.Log("НИЗ");
            }

            yield return new WaitForSeconds(Random.Range(minSecondsWait, maxSecondsWait));
        }
    }
}
