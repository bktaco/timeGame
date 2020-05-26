using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementQueue : MonoBehaviour
{
    public UIMovement uiMovement;
    public GameObject target;

    private GameManager gameManager;
    private MovementQueue movementQueue;
    private Rigidbody2D rb;
    private float moveSpeed = 10f;
    private float jumpSpeed = 15f;
    private bool isRunning = false;

    private void Awake()
    {
        movementQueue = new MovementQueue();
        uiMovement.SetMovementQueue(movementQueue);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
            {

                var x = new Vector2(Input.GetAxisRaw("Horizontal") / 2, Input.GetAxisRaw("Vertical"));
                movementQueue.AddMove(x);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
            {

                var x = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                movementQueue.AddMove(x);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isRunning == false)
            {
                isRunning = true;
                StartCoroutine("PlayBack");
            }
            else
            {
                isRunning = false;
                SceneManager.LoadScene(gameManager.currentLevel);
                movementQueue.ResetQueue();
            }
            
        }
    }

    IEnumerator PlayBack()
    {
        List<Vector2> moveList = movementQueue.GetMoveList();
        for (int i = 0; i < moveList.Count; i++)
        {
            rb.velocity = new Vector2(moveSpeed * moveList[i].x, jumpSpeed * moveList[i].y);

            AudioManager.PlayStepSound();

            Vector3 charScale = transform.localScale;
            if (rb.velocity.x < 0)
            {
                charScale.x = -1;
                transform.localScale = charScale;
            }
            else
            {
                charScale.x = 1;
                transform.localScale = charScale;
            }
            yield return new WaitForSeconds(1);
        }
        var clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        if(target.GetComponent<Target>().Triggered())
        {
            SceneManager.LoadScene("Complete");
            
        }
        else
        {
            SceneManager.LoadScene(gameManager.currentLevel);

            movementQueue.ResetQueue();
        }
        
        

    }
}
