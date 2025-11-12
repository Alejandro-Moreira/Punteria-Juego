using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    [Header("Arma y Disparo")]
    public GameObject gunObject;
    public Transform firePoint;
    public GameObject fireBulletPrefab;
    public GameObject iceBulletPrefab;

    [Header("UI de habilidades")]
    public Transform skillContainer;

    private CharacterController controller;
    private float verticalRotation = 0f;
    private Dictionary<string, Image> skills = new Dictionary<string, Image>();

    private bool hasGun = false;
    private bool hasFire = false;
    private bool hasFreeze = false;

    private int selectedSkill = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // Configurar iconos de habilidades
        foreach (Transform skill in skillContainer)
        {
            skills.Add(skill.name, skill.GetComponent<Image>());
            skills[skill.name].color = new Color(1, 1, 1, 0.2f);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleCameraRotation();

        // Seleccionar habilidad
        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) && hasFire)
        {
            selectedSkill = 1;
            Debug.Log("Fire seleccionado");
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && hasFreeze)
        {
            selectedSkill = 2;
            Debug.Log("Freeze seleccionado");
        }

        // Disparo
        if (Input.GetMouseButtonDown(0) && hasGun && selectedSkill > 0)
        {
            Shoot();
        }
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    // INVENTARIO Y HABILIDADES
    public void AddSkill(string skillName)
    {
        Debug.Log($"Recogiste: {skillName}");

        if (skills.ContainsKey(skillName))
            skills[skillName].color = Color.white;

        if (skillName == "Gun")
        {
            hasGun = true;
            Debug.Log("Arma registrada en inventario");
        }
        else if (skillName == "Fire")
        {
            hasFire = true;
            Debug.Log("Habilidad Fire desbloqueada");
        }
        else if (skillName == "Freeze" || skillName == "Ice")
        {
            hasFreeze = true;
            Debug.Log("Habilidad Freeze desbloqueada");
        }
    }

    // EQUIPAR PICKUP (arma u otro objeto)
    public void EquipPickup(GameObject pickup)
{
    if (pickup == null) return;

    string itemName = pickup.name;
    Debug.Log("Equipando pickup: " + itemName);

    if (itemName == "Gun")
    {
        // Si ya hay un arma, eliminarla
        if (gunObject != null && gunObject != pickup)
        {
            Destroy(gunObject);
            gunObject = null;
        }

        Transform cam = Camera.main.transform;
        pickup.transform.SetParent(cam);

        // Ajustar posición y orientación vertical del arma
        pickup.transform.localPosition = new Vector3(0.4f, -0.5f, 0.8f); 
        pickup.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);  
        pickup.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);     

        // Desactivar físicas
        Collider col = pickup.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        Rigidbody rb = pickup.GetComponent<Rigidbody>();
        if (rb != null) Destroy(rb);

        // Asignar FirePoint
        Transform fp = pickup.transform.Find("FirePoint");
        if (fp != null)
        {
            firePoint = fp;
        }
        else
        {
            Debug.LogWarning("No se encontró FirePoint en el arma.");
        }

        gunObject = pickup;
        hasGun = true;

        if (skills.ContainsKey("Gun"))
            skills["Gun"].color = Color.white;

        AddSkill("Gun");
    }
    else
    {
        AddSkill(itemName);
        Destroy(pickup);
    }
}
// DISPARAR
    void Shoot()
    {
        GameObject bulletPrefab = null;

        if (selectedSkill == 1 && hasFire)
            bulletPrefab = fireBulletPrefab;
        else if (selectedSkill == 2 && hasFreeze)
            bulletPrefab = iceBulletPrefab;
        // Crear bala
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Disparo realizado (" + (selectedSkill == 1 ? "Fire" : "Freeze") + ")");
    }
}
