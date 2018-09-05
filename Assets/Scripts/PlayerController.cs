using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookSensitivity = 3f;

    //I'll use these later hehe
    [Header("Jump Settings")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMulitplier = 2f;

    private PlayerMotor motor;
    
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove; //(1,0,0)
        Vector3 _moveVeritcal = transform.forward * _zMove; //(0,0,1)

        //Final movement vector
        Vector3 _velocity = (_moveHorizontal + _moveVeritcal).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector (Turning Around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (Turning Around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _camerarotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //Apply rotation
        motor.RotateCamera(_camerarotation);

       

        //Apply jump
       // motor.Jump(_jump);
    }
}
