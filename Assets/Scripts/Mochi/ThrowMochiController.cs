using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowMochiController : MonoBehaviour
{
    public static ThrowMochiController instance;

    public GameObject CurrentMochi { get; set; }
    [SerializeField] private Transform _mochiTransform;
    [SerializeField] private Transform _parentAfterThrow;
    [SerializeField] private MochiSelector _selector;

    private PlayerController _playerController;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    public Bounds Bounds { get; private set; }
    private const float EXTRA_WIDTH = 0.02f;

    public bool CanThrow { get; set; } = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();

        SpawnAMochi(_selector.PickRandomMochiForThrow());
    }

    private void Update()
    {
        if (UserInput.IsThrowPressed && CanThrow)
        {
            SpriteIndex index = CurrentMochi.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentMochi.transform.rotation;

            GameObject go = Instantiate(MochiSelector.instance.Mochi[index.Index], CurrentMochi.transform.position, rot);
            go.transform.SetParent(_parentAfterThrow);

            Destroy(CurrentMochi);

            CanThrow = false;
        }
    }

    public void SpawnAMochi(GameObject mochi)
    {
        GameObject go = Instantiate(mochi, _mochiTransform);
        CurrentMochi = go;
        _circleCollider = CurrentMochi.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;

        _playerController.ChangeBoundry(EXTRA_WIDTH);
    }
}
