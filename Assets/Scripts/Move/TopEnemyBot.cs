using System;
using UnityEngine;

public class TopEnemyBot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PuckMoveAbility _puckObj;

    [SerializeField] private GameObject _topSide;
    [SerializeField] private GameObject _bottomSide;
    [SerializeField] private GameObject _leftSide;
    [SerializeField] private GameObject _rightSide;

    private float _maxTop = 0;
    private float _maxBottom = 0;
    private float _maxLeft = 0;
    private float _maxRight = 0;

    private AudioSource _hitSound;

    void Start()
    {
        _maxTop = _topSide.transform.position.y - _topSide.transform.localScale.y / 2 - this.transform.localScale.y / 2;
        _maxBottom = _bottomSide.transform.position.y + _bottomSide.transform.localScale.y / 2 + this.transform.localScale.y / 2;
        _maxLeft = _leftSide.transform.position.x + _leftSide.transform.localScale.x / 2 + this.transform.localScale.x / 2;
        _maxRight = _rightSide.transform.position.x - _rightSide.transform.localScale.x / 2 - this.transform.localScale.x / 2;

        _rb = GetComponent<Rigidbody2D>();
        _puckObj = FindAnyObjectByType<PuckMoveAbility>();
      
        _hitSound = GetComponent<AudioSource>();
    }

    void Update() 
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _maxLeft, _maxRight), Mathf.Clamp(transform.position.y, _maxBottom, _maxTop));
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = this.gameObject.transform.position;
        Vector2 puckPos = _puckObj.transform.position;
        Vector2 bitDirection = (puckPos - currentPos).normalized;
        float magnitudeVel = (puckPos - currentPos).magnitude;
        float touchMag = 2.5f;

        float distanceBetweenAB = Vector3.Distance(this.gameObject.transform.position, _puckObj.transform.position);

        _rb.AddForce(bitDirection * magnitudeVel * touchMag, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.GetComponent<PuckMoveAbility>())
        {
            Hit();
        }
    }

    public void Hit()
    {
        _hitSound.Play();
        _hitSound.volume = PlayerPrefs.GetFloat(KeyScore.AudioSave);
    } 

}
