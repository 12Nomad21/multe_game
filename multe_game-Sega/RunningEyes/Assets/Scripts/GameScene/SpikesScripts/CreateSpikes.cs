using System.Collections;
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

        _coroutine = CreateSpike();
        StartCoroutine(_coroutine);
    }

    private IEnumerator CreateSpike()
    {
        while(true){
            var _spike = this._pool.GetFreeElement();

            var _spikeRandomSpawnPosition = new Vector3(_xPosSpikeSpawn, _maxYPosSpawnSpike, 0);
            var _spikeRotation = new Quaternion(0, 0, 180, 0);

            int _rnd = Random.Range(0, 2);

            if(_rnd == 0){
                _spikeRandomSpawnPosition = new Vector3(_xPosSpikeSpawn, _minYPosSpawnSpike, 0);
                _spikeRotation = new Quaternion(0, 0, 0, 0);
            }

            _spike.transform.position = _spikeRandomSpawnPosition;
            _spike.transform.rotation = _spikeRotation;

            yield return new WaitForSeconds(Random.Range(_minSecondsWait, _maxSecondsWait));
        }
    }
}
