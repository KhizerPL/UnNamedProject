using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Inspector Vars
    [SerializeField] float _sensivity;
    [SerializeField] Camera _Camera;

    #endregion


    #region Public Vars
    public float Sensivity { get { return _sensivity;} /*set { _sensivity = value; }*/  } //just for you guys ;)

    #endregion


    #region Private Vars
    Vector2 _StartMovePos, _CurrentTouchPos, _LastMovePosition;
    bool _isCamMoving = false;

    #endregion


    #region Interfaces
    public void OnBeginDrag(PointerEventData eventData)
    {
        _StartMovePos = eventData.position;
        _CurrentTouchPos = eventData.position;
        _LastMovePosition = eventData.position;
        _isCamMoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _CurrentTouchPos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isCamMoving = false;
    }
    #endregion


    #region Unity Methods
    void Update()
    {
        if (_isCamMoving)
        {
            _Camera.transform.position = new Vector3(_Camera.transform.position.x + (_LastMovePosition.x - _CurrentTouchPos.x)* _sensivity, _Camera.transform.position.y, _Camera.transform.position.z + (_LastMovePosition.y - _CurrentTouchPos.y)* _sensivity);
            _LastMovePosition = _CurrentTouchPos;
        }
    }


    #endregion
}
