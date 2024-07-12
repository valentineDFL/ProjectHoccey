using System;
using UnityEngine;

public class PuckMoveAbility : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private GameObject _topSide;
    [SerializeField] private GameObject _bottomSide;
    [SerializeField] private GameObject _leftSide;
    [SerializeField] private GameObject _rightSide;

    [SerializeField] private GameObject _TopGates;
    [SerializeField] private GameObject _BottomGates;

    private int _round = 0;
    private int _topSc = 0;
    private int _bottomSc = 0;

    private Vector2 _previusPos;

    private float _maxTop = 0;
    private float _maxBottom = 0;
    private float _maxLeft = 0;
    private float _maxRight = 0;

    private AudioSource _hitSound;

    private void Start()
    {   
        _maxTop = _topSide.transform.position.y - _topSide.transform.localScale.y / 2 + this.transform.localScale.y / 2;
        _maxBottom = _bottomSide.transform.position.y + _bottomSide.transform.localScale.y / 2 - this.transform.localScale.y / 2;
        _maxLeft = _leftSide.transform.position.x + _leftSide.transform.localScale.x / 2 + this.transform.localScale.x / 2;
        _maxRight = _rightSide.transform.position.x - _rightSide.transform.localScale.x / 2 - this.transform.localScale.x / 2;

        _round = PlayerPrefs.GetInt(KeyScore.Round);
        _topSc = PlayerPrefs.GetInt(KeyScore.ScoreTop);
        _bottomSc = PlayerPrefs.GetInt(KeyScore.ScoreBott);

        _rb = GetComponent<Rigidbody2D>();

        _hitSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _maxLeft, _maxRight), Mathf.Clamp(transform.position.y, _maxBottom, _maxTop));
        _previusPos = _rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Vector2 reflectCollision = Vector2.Reflect(_previusPos, collision.contacts[0].normal);

        float collSpeed = Vector2.Distance(_previusPos, _rb.velocity);

        if (!collision.gameObject.GetComponent<PlayerBottomMove>() && !collision.gameObject.GetComponent<TopEnemyBot>())
        {
            _rb.AddForce(reflectCollision * collSpeed * 1.6f);
        }
        Hit();
    }

    public void Hit()
    {
        _hitSound.Play();
        _hitSound.volume = PlayerPrefs.GetFloat(KeyScore.AudioSave);
    }
}
