using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementQueue : MonoBehaviour
{
    private MovementQueue movementQueue;
    public UIMovement uiMovement;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float jumpSpeed = 5f;

    private void Awake()
    {
        movementQueue = new MovementQueue();
        uiMovement.SetMovementQueue(movementQueue);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
            {

                var x = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                Debug.Log(x);
                movementQueue.AddMove(x);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
            {

                var x = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                Debug.Log(x);
                movementQueue.AddMove(x);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine("PlayBack");
        }
    }


    IEnumerator PlayBack()
    {
        List<Vector2> moveList = movementQueue.GetMoveList();
        for (int i = 0; i < moveList.Count; i++)
        {
            rb.velocity = new Vector2(moveSpeed * moveList[i].x, jumpSpeed * moveList[i].y);
            yield return new WaitForSeconds(1);
        }
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        movementQueue.ResetQueue();

    }
}
