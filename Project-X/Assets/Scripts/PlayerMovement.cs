using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigBody;
    private Animator animatrix;
    private SpriteRenderer spriteRenderer;
    private float dirX = 0f;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float verticalForce = 14f;
    [SerializeField] private float horizontalForce = 7f;

    private enum PlayerState { idle, run, jump, fall }
    private PlayerState playerState = PlayerState.idle; 
    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        animatrix = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        mainCamera.transform.SetParent(GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigBody.velocity = new Vector2(dirX * horizontalForce, rigBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigBody.velocity = new Vector3(0, verticalForce, 0);
        }

        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        PlayerState current;
        
        if(dirX > 0f)
        {
            current = PlayerState.run;
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f)
        {
            current = PlayerState.run;           
            spriteRenderer.flipX = true;
        }
        else
        {
            current = PlayerState.idle;           
        }

        if(rigBody.velocity.y > 0.1f)
        {
            current = PlayerState.jump;
        }
        else if(rigBody.velocity.y < -0.1f)
        {
            current = PlayerState.fall;
        }

        animatrix.SetInteger("animState", (int)current);
    }
}
