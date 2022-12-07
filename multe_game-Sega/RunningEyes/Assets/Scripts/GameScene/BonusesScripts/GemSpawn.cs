using System.Collections;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    private IEnumerator _coroutine;

    [Header("Pool settings")]
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private DisableGems _gemPrefab;

    private PoolMono<DisableGems> _pool;
    [Header("Spawn gem settings")]
    [SerializeField] private float _minYPosSpawnGem = -3.5f;
    [SerializeField] private float _maxYPosSpawnGem = 3.5f;
    [SerializeField] private float _xPosGemSpawn = 19f;
    [SerializeField] private float _zPosGemSpawn = 2f;
    [SerializeField] private float _minSecondsWait = 10f;
    [SerializeField] private float _maxSecondsWait = 30f;

    private void Start()
    {
        this._pool = new PoolMono<DisableGems>(_gemPrefab, _poolCount, this.transform); // инициализирование пула с этими параметрами
        this._pool._autoExpand = this._autoExpand; // будем указывать авторсширение пула через инспектор

        _coroutine = CreateGem();
        StartCoroutine(_coroutine);
    }

    private IEnumerator CreateGem()
    {
        while(true){
            yield return new WaitForSeconds(Random.Range(_minSecondsWait, _maxSecondsWait));

            var _gem = this._pool.GetFreeElement();

            var _gemRandomSpawnPosition = new Vector3(_xPosGemSpawn, _maxYPosSpawnGem, _zPosGemSpawn);
            var _gemRotation = new Quaternion(0, 0, 180, 0);

            int _rnd = Random.Range(0, 2);

            if(_rnd == 0){
                _gemRandomSpawnPosition = new Vector3(_xPosGemSpawn, _minYPosSpawnGem, _zPosGemSpawn);
                _gemRotation = new Quaternion(0, 0, 0, 0);
            }

            _gem.transform.position = _gemRandomSpawnPosition;
            _gem.transform.rotation = _gemRotation;
        }
    }
}
