using UnityEngine;

public class WheelOfFortune : MonoBehaviour
{
    public Transform wheel; // ������ �� ���������
    public AnimationCurve rotationCurve; // ������ ��� ��������� � ����������

    private float startAngle = 0f; // ������������ ��������� ����
    private float endAngle = 90f; // �������� ���� (0 ��������)

    private float totalTime = 2f; // ����� ����� ��������
    private float elapsedTime = 0f; // ��������� �����
    private bool _isGrounded;
    private const float JumpForce = 7;
    [SerializeField] private Rigidbody2D rigidbody2D;
    void Start()
    {
        startAngle = startAngle - 90;
        endAngle = endAngle - 90;
        elapsedTime = totalTime;
    }
    void Update()
    {
        #region Checking

        //if (Input.GetMouseButtonDown(0) && _isGrounded)
        //{
        //    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);

        //}

        if (Input.GetMouseButtonDown(0) && elapsedTime == totalTime)
        {
            startAngle = startAngle + 90f;
            endAngle = endAngle + 90f;
            elapsedTime = 0f;
        }
        #endregion
        #region RotationMethod
        if (elapsedTime < totalTime)
        {
            float progress = elapsedTime / totalTime; // �������� �� 0 �� 1
            float curveValue = rotationCurve.Evaluate(progress); // ������ �������� ������

            // ���������� ���� �������� �� ������ ������
            float currentAngle = Mathf.Lerp(startAngle, endAngle, curveValue);

            // ���������� �������� 
            wheel.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            elapsedTime += Time.deltaTime; // ���������� ���������� �������
        }
        if (elapsedTime > totalTime)
        {
            elapsedTime = totalTime;
            wheel.rotation = Quaternion.Euler(0f, 0f, endAngle);
        }
        #endregion
    }
}
