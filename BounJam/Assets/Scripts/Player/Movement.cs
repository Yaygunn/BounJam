using System.Collections;
using Unity.Mathematics;
using UnityEngine;

enum E_PlayerMoveState { rope, gocenter, decide}
public class Movement : MonoBehaviour
{
    public static Movement Instance {  get; private set; }

    private Vector2 _inputDirection;

    [field: SerializeField] private float Speed;

    [field: SerializeField] private float MoveCenterSpeed;

    [field:SerializeField] public Node currentNode {  get; private set; }
    [field:SerializeField] public BaseRope currentRope {  get; private set; }

    [SerializeField] private E_PlayerMoveState _playerMoveState;

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
            currentNode = null;
            transform.position = currentRope.transform.position;
            StartRopeMovement(currentRope);
        }
    }
    IEnumerator RopeMovement(BaseRope rope)
    {
        currentRope = rope;
        Vector2 RopeDirection = rope.GetRopeDirection();
        Vector2 MoveDirection;

        while (true)
        {
            if (math.dot(RopeDirection, _inputDirection) < 0)
            {
                MoveDirection = -RopeDirection;
            }
            else
            {
                MoveDirection = RopeDirection;
            }
            if(currentNode != null)
            {
                if(math.dot(MoveDirection, GetOtherNodeDirection()) < 0)
                {
                    StartNodeMovement(currentNode);
                }
            }
            RopeMove(MoveDirection);
            yield return null;
        }
    }
    private Vector2 GetOtherNodeDirection()
    {
        return currentRope.GetOtherNode(currentNode).transform.position - currentNode.transform.position;
    }

    public void StartRopeMovement(BaseRope rope)
    {
        _playerMoveState = E_PlayerMoveState.rope;
        StopAllCoroutines();
        StartCoroutine(RopeMovement(rope));
    }

    private void RopeMove(Vector2 direction)
    {
       
        Vector2 move = (direction * _inputDirection.magnitude * Speed * Time.deltaTime);
        Move(move);
    }

    private void Move(Vector2 moveAmount)
    {
        Vector3 pos = transform.position;
        pos += (Vector3)moveAmount;
        transform.position = pos;
    }
    private void GetInputDirection(Vector2 inputDirection)
    {
        _inputDirection = inputDirection;
    }
    
    public void StartNodeMovement(Node node)
    {
        currentRope = null;
        _playerMoveState = E_PlayerMoveState.gocenter;
        currentNode = node;
        StopAllCoroutines();
        StartCoroutine(NodeCenterMove(node));
    }

    private IEnumerator NodeCenterMove(Node node)
    {
        Vector3 direction = node.transform.position - transform.position;
        while (true)
        {
            if (math.dot(node.transform.position - transform.position, direction) < 0) 
            {
                transform.position = node.transform.position;
                StartNodeDecision();
            }
            Move(direction * MoveCenterSpeed * Time.deltaTime);
            yield return null;
        }
    }


    private void StartNodeDecision()
    {
        _playerMoveState = E_PlayerMoveState.decide;
        StopAllCoroutines();
        StartCoroutine(NodeDecision());
    }
    private IEnumerator NodeDecision()
    {
        while (true)
        {
            yield return null;
            if(_inputDirection != Vector2.zero)
            {
                BaseRope rope = currentNode.SelectRope(_inputDirection);
                if(rope != null)
                    StartRopeMovement(rope);
            }
        }
    }

    public void TryEmptyNode(Node node)
    {
        if(currentNode == node)
        {
            currentNode = null;
            print("EmptyCurrentNode");
        }
    }
}
