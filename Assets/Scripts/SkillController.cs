using UnityEngine;

public class SkillController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Intentamos obtener el PlayerController
        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null)
        {
            Debug.LogWarning("PlayerController no encontrado en el Player.");
            return;
        }

        string itemName = gameObject.name;

        if (itemName == "Gun")
        {
            // Pasamos el objeto completo para que el player lo equipe (no lo destruimos aquí)
            player.EquipPickup(gameObject);
        }
        else
        {
            // Notificamos al player y destruimos el pickup (comportamiento anterior)
            player.AddSkill(itemName);
            Destroy(gameObject);
        }
    }
}
