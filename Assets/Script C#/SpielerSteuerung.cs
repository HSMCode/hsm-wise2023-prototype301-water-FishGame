using UnityEngine;
using System.Collections;

public class SpielerSteuerung : MonoBehaviour
{
    public float sprungKraft = 10f;
    public Transform punktA;
    public Transform punktB;
    private bool istInDerLuft = false;
    private bool istAnPunktA = true;

    void Update()
    {
        // Überwache die Leertaste für den Sprung
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Unterbreche den aktuellen Sprung, wenn der Spieler bereits in der Luft ist
            if (istInDerLuft)
            {
                StopCoroutine(ResetLuftStatus());
                istInDerLuft = false;
            }

            // Springen zu Punkt A oder B basierend auf dem aktuellen Zustand
            Springen();
        }
    }

    void Springen()
    {
        // Bestimme den Ziel-Punkt basierend auf dem aktuellen Zustand
        Transform zielPunkt = istAnPunktA ? punktB : punktA;

        // Berechne die Richtung zum Ziel-Punkt
        Vector3 richtung = (zielPunkt.position - transform.position).normalized;

        // Setze die Geschwindigkeit auf null, um unerwünschte Kräfte zu vermeiden
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Füge eine Kraft in Richtung des Ziel-Punkts hinzu
        GetComponent<Rigidbody>().AddForce(richtung * sprungKraft, ForceMode.Impulse);

        // Setze istInDerLuft auf true, um zu verhindern, dass der Spieler erneut springt, während er in der Luft ist
        istInDerLuft = true;

       
        StartCoroutine(ResetLuftStatus());

        
        istAnPunktA = !istAnPunktA;
    }

    IEnumerator ResetLuftStatus()
    {
       
        yield return new WaitForSeconds(1f);
        istInDerLuft = false;
    }
}