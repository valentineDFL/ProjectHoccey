using System;
using UnityEngine;

public class PlayerBottomMove : MonoBehaviour
{
    private Vector2 _positionStart = new Vector2(0, -4.4f);
    private Vector2 _previusPos;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _leftSide;
    [SerializeField] private GameObject _rightSide;
    [SerializeField] private GameObject _bottomSide;
    [SerializeField] private GameObject _topSide;

    private float _maxLeft = 0;
    private float _maxRight = 0;
    private float _maxTop = 0;
    private float _maxBottom = 0;
    private AudioSource _hitSound;

    [SerializeField] private float Speed = 14;

    void Start()
    {
        _maxLeft = _leftSide.transform.position.x + _leftSide.transform.localScale.x / 2 + this.transform.localScale.x / 2;
        _maxRight = _rightSide.transform.position.x - _rightSide.transform.localScale.x / 2 - this.transform.localScale.x / 2;
        _maxTop = _topSide.transform.position.y - _topSide.transform.localScale.y / 2 - this.transform.localScale.y / 2;
        _maxBottom = _bottomSide.transform.position.y + _bottomSide.transform.localScale.y / 2 + this.transform.localScale.y / 2;

        _rb = GetComponent<Rigidbody2D>();

        _hitSound = GetComponent<AudioSource>();
        _rb.position = _positionStart;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _maxLeft, _maxRight), Mathf.Clamp(transform.position.y, _maxBottom, _maxTop));
        _previusPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        PlayerChangePosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PuckMoveAbility>() != null)
        {
            Vector2 currentPlayerPos = this.transform.position;
            float newCurrent = (currentPlayerPos - _previusPos).magnitude;
            collision.rigidbody.AddForce((this.transform.position - collision.transform.position).normalized * Speed * newCurrent);
            Hit();
        }

    }

    public void Hit()
    {
        _hitSound.volume = PlayerPrefs.GetFloat(KeyScore.AudioSave);
        _hitSound.Play();
    }

    public void PlayerChangePosition()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (worldPosition.y <= _maxTop / 4)
            {
                _rb.MovePosition(Vector2.MoveTowards(transform.position, worldPosition, Speed * Time.fixedDeltaTime));
            }
        }
    }
}
