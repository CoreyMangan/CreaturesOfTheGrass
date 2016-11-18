using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float verSpeed;
    public float horSpeed;
    private float rotSpeed;
    public float gravity;
    public Camera fpsCam;

    Vector3 moveDir = Vector3.zero;

    private CharacterController cc;
    public float sprintSpeed = 0f;
    private float mouseX;
    private float mouseY;
    private float rotRange = 60f;

	void Start () {
        cc = GetComponent<CharacterController>();

        //Hide mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	
	}

    void Update () {
        //Show mouse
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }

        //Movement
        float moveVer = Input.GetAxis("Vertical") * verSpeed + sprintSpeed;
        float moveHor = Input.GetAxis("Horizontal") * horSpeed;
        moveDir = new Vector3(moveHor, 0, moveVer);
        moveDir = transform.TransformDirection(moveDir);

        //Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 15f;
        }
        else
        {
            sprintSpeed = 0f;
        }

        //moveDir.y -= gravity;
        cc.Move(moveDir * Time.deltaTime);

        //Rotation
        mouseX = Input.GetAxis("Mouse X") * rotSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;

        mouseY = Mathf.Clamp(mouseY, -rotRange, rotRange);

        transform.Rotate(0, mouseX, 0);
        fpsCam.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);

        if(Input.GetKeyDown(KeyCode.P))
        {
            rotSpeed = 0;
        }
        else
        {
            rotSpeed = 5;
        }
	}
}
