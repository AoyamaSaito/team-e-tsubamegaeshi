using UnityEngine;

public class FlickTest : MonoBehaviour
{

    private Vector3 _touchStartPos;
    private Vector3 _touchEndPos;

    public enum SwipeDirection
    {
        NONE,
        TAP,
        UP,
        RIGHT,
        DOWN,
        LEFT,
    }
    [SerializeField]
    private SwipeDirection _nowSwipe = SwipeDirection.NONE;


    private void Update()
    {
        Flick();
    }

    /// <summary>
    /// �t���b�N���͎�t
    /// </summary>
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GetDirection();
        }
    }

    /// <summary>
    /// �t���b�N��������
    /// </summary>
    void GetDirection()
    {
        float directionX = _touchEndPos.x - _touchStartPos.x;
        float directionY = _touchEndPos.y - _touchStartPos.y;
        string Direction;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //�E�����Ƀt���b�N
                Direction = "Right";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.RIGHT);
            }

            else if (-30 > directionX)
            {
                //�������Ƀt���b�N
                Direction = "Left";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.LEFT);
            }
        }

        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //������Ƀt���b�N
                Direction = "Up";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.UP);
            }
            else if (-30 > directionY)
            {
                //�������̃t���b�N
                Direction = "Down";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.DOWN);
            }
        }
        else
        {
            //�^�b�`�����o
            Direction = "touch";
            Debug.Log(Direction);
        }


    }

    /// <summary>
    /// ��ԕύX����1�񂾂��Ă΂�鏈��
    /// </summary>
    /// <param name="next"></param>
    public void ChangeState(SwipeDirection next)
    {
        // �ȑO�̏�Ԃ�ێ�
        var prev = _nowSwipe;
        // ���̏�ԂɕύX����
        _nowSwipe = next;
        Debug.Log($"�G�l�~�[�X�e�[�g�ύX {prev} -> {next}");
        switch (_nowSwipe)
        {
            case SwipeDirection.NONE:
                {

                }
                break;
            case SwipeDirection.UP:
                {

                }
                break;
            case SwipeDirection.DOWN:
                {

                }
                break;
            case SwipeDirection.RIGHT:
                {

                }
                break;
            case SwipeDirection.LEFT:
                {

                }
                break;
            case SwipeDirection.TAP:
                {

                }
                break;
        }
    }
}
