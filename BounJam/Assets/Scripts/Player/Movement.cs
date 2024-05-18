using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance {  get; private set; }

    private Vector2 _inputDirection;

    [field: SerializeField] private float Speed;
    [field:SerializeField] public BaseNode currentNode {  get; private set; }
    [field:SerializeField] public BaseRope currentRope {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InputGameplay.Instance.E_Move += GetInputDirection;

        StartOperation();
    }
    private void OnDestroy()
    {
        InputGameplay.Instance.E_Move -= GetInputDirection;
    }

    private void StartOperation()
    {
        if(currentRope != null)
        {
            transform.position = currentRope.transform.position;
            StartRopeMovement(currentRope);
        }
    }
    IEnumerator RopeMovement(BaseRope rope)
    {
        currentRope = rope;
        Vector2 RopeDirection = rope.GetRopeDirection();

        while (true)
        {
            print("RopeDirection = " + RopeDirection + " input direction" + _inputDirection);
            if (math.dot(RopeDirection, _inputDirection) < 0)
            {
                RopeMove(-RopeDirection);
            }
            else
            {
                RopeMove(RopeDirection);
            }

            yield return null;
        }
    }

    public void StartRopeMovement(BaseRope rope)
    {
        StartCoroutine(RopeMovement(rope));
    }
    public void StopRopeMovement()
    {
        currentRope = null;
        StopAllCoroutines();
    }

    private void RopeMove(Vector2 direction)
    {
        Vector3 pos = transform.position;
        pos += (Vector3)(direction * _inputDirection.magnitude * Speed * Time.deltaTime);
        transform.position = pos;
    }
    private void GetInputDirection(Vector2 inputDirection)
    {
        _inputDirection = inputDirection;
    }
    
}
