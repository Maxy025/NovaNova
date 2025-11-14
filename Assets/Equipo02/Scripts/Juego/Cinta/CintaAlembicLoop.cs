using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class CintaAlembicLoop : MonoBehaviour
{
    public AlembicStreamPlayer player;
    public float speed; // Velocidad de reproducción de la animación (1 = normal)

    void Start()
    {
        if (player == null)
            player = GetComponent<AlembicStreamPlayer>();

        // Asegurarnos de que empieza al inicio
        player.CurrentTime = player.StartTime;
    }

    void Update()
    {
        if (player == null)
            return;

        Debug.Log(player.CurrentTime);

        // Avanzar el tiempo de la animación según la velocidad
        player.CurrentTime += speed * Time.deltaTime;

        // Si llega al final, reiniciar (loop)
        if (player.CurrentTime > 1)
        {
            Debug.Log("Se debe reiniciar la animación");
            player.CurrentTime = 0;
        }
    }

}
