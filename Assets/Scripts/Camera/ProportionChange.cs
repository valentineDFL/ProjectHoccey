using UnityEngine;

public class ProportionChange : MonoBehaviour
{

    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;
    private Camera _camera;
    private float _cameraHalfWidthUnits = 0;
    private float _oneOfFourWall = 0;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _oneOfFourWall = _leftWall.transform.localScale.x / 4;
        _cameraHalfWidthUnits = _camera.orthographicSize * Screen.width / Screen.height;
        
        _leftWall.transform.position = new Vector2(-_cameraHalfWidthUnits - _oneOfFourWall, _leftWall.transform.position.y);
        _rightWall.transform.position = new Vector2(_cameraHalfWidthUnits + _oneOfFourWall, _rightWall.transform.position.y);
    }
}
