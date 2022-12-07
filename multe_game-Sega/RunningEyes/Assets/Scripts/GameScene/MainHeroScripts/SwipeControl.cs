using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Rigidbody2D _mainHeroRB2D;
    [SerializeField] private GameObject _mainHero;
    [Header("Gravity")]
    [SerializeField] private float _minGravityScale = -4f;
    [SerializeField] private float _maxGravityScale = 4f;
    [SerializeField] private bool _mainHeroToUp = false;
    [SerializeField] private bool _mainHeroToDown = false;
    [Header("Main hero settings in game")]
    [SerializeField] private Vector3 _normalPlayerPosition = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 _invertedPlayerPosition = new Vector3(0.5f, -0.5f, 0.5f);

    private void Update()
    {
        if(IsMainHeroOnGround._mainHeroOnGround){
            if(_mainHeroToUp){
                _mainHeroRB2D.gravityScale = _minGravityScale;
                _mainHero.transform.localScale = _invertedPlayerPosition;
            }
            else if(_mainHeroToDown){
                _mainHeroRB2D.gravityScale = _maxGravityScale;
                _mainHero.transform.localScale = _normalPlayerPosition;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x)){
            _mainHeroToDown = true;
            _mainHeroToUp = false;

            if(eventData.delta.y > 0){
                _mainHeroToUp = true;
                _mainHeroToDown = false;
            }            
        }
    }    public void OnDrag(PointerEventData eventData){}
}
