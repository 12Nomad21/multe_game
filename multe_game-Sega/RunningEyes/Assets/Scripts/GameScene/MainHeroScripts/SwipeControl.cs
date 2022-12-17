using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Rigidbody2D _mainHeroRB2D;
    [SerializeField] private GameObject _mainHero;
    [Header("Gravity")]
    [SerializeField] private float _minGravityScale = -4f;
    [SerializeField] private float _maxGravityScale = 4f;
    [SerializeField] private bool _invertedGravity = false;
    [Header("Main hero settings in game")]
    [SerializeField] private Vector3 _normalPlayerPosition = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 _invertedPlayerPosition = new Vector3(0.5f, -0.5f, 0.5f);

    private void Update()
    {
        if(IsMainHeroOnGround._mainHeroOnGround){
            if(_invertedGravity){
                _mainHeroRB2D.gravityScale = _minGravityScale;
                _mainHero.transform.localScale = _invertedPlayerPosition;
            }
            else{
                _mainHeroRB2D.gravityScale = _maxGravityScale;
                _mainHero.transform.localScale = _normalPlayerPosition;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x)){
            _invertedGravity = false;

            if(eventData.delta.y > 0){
                _invertedGravity = true;
            }            
        }
    }    public void OnDrag(PointerEventData eventData){}
}
