using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptPersonaje1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public Vida vidaPersonaje;
    public int saludReal = 100;
    private Vector2 _mousePosition;

    private bool _isAming = false;
    private Camera _mainCamera;

    private int HashAnimationIsAming = Animator.StringToHash("IsAiming");
    void Start()
    {
        anim = GetComponent<Animator>();
        _mainCamera = Camera.main;
        vidaPersonaje.maxSalud = saludReal;
        
        //lo posicionamos en el centro
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //obtener la posición del mouse en tiempo real
        _mousePosition.Set(Input.mousePosition.x,Input.mousePosition.y);
        if (Input.GetButtonDown("Fire2"))
        {
            _isAming = !_isAming;
            anim.SetBool(HashAnimationIsAming,_isAming);
        }
        
        if (Input.GetButtonDown("Fire1") && _isAming )
        {
            //vamos a disparar desde el centro de la cámara.
            var ray =  _mainCamera.ScreenPointToRay(_mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var enemy = hit.collider.GetComponent<ScriptNavMesh>();
                if (enemy)
                {
                    enemy.MatarObjeto();
                }
            }
        }
        
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
}
