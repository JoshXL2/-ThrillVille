using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    public Transform[] seats;
    public float radius = 100f;
    public float speed = 20f;

    public Vector3 seatRotationOffset;

    float angle;

    void Update()
    {
        angle += speed * Time.deltaTime;

        for (int i = 0; i < seats.Length; i++)
        {
            float currentAngle = angle + (360f / seats.Length) * i;
            float rad = currentAngle * Mathf.Deg2Rad;

            seats[i].position = transform.position + new Vector3(
                Mathf.Cos(rad) * radius,
                Mathf.Sin(rad) * radius,
                0f
            );

            seats[i].rotation = Quaternion.Euler(seatRotationOffset);
        }
    }
}