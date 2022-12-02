using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Rigidbody2D _MainHeroRB2D;
    [Header("Gravity")]
    [SerializeField] private float _minGravityScale = -4f;
    [SerializeField] private float _maxGravityScale = 4f;
    [SerializeField] private bool _mainHeroToUp = false;
    [SerializeField] private bool _mainHeroToDown = false;

    private void Update() {
        if(IsMainHeroOnGround._mainHeroOnGround){
            if(_mainHeroToUp){
                _MainHeroRB2D.gravityScale = _minGravityScale;
            }
            else if(_mainHeroToDown){
                _MainHeroRB2D.gravityScale = _maxGravityScale;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x)){
            if(eventData.delta.y > 0){
                _mainHeroToUp = true;
                _mainHeroToDown = false;
            }
            else{
                _mainHeroToDown = true;
                _mainHeroToUp = false;
            }
        }
    }    public void OnDrag(PointerEventData eventData){}
}
