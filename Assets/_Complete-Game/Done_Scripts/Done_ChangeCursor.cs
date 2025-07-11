using System.Collections;
using UnityEngine;

/// <summary>
/// 鼠标追踪
/// </summary>
public class Done_ChangeCursor : MonoBehaviour
{
	public Texture2D UserCursor;
	public Texture2D UserClickCursor;
	private bool isClicked = false;

	void Start ()
	{
        //在游戏界面内隐藏系统光标
		Cursor.visible = false;
	}

    /// <summary>
    /// 时时判断鼠标点击状态，便于切换图像
    /// </summary>
	void Update ()
	{
		if (Input.GetMouseButton (0))
		{
			isClicked = true;
		}
		else
		{
			isClicked = false;
		}
	}

	void OnGUI ()
	{
        //获取鼠标当前位置
		Vector2 mouse_pos = Input.mousePosition;

        //鼠标点击与否显示相应的图片
		if (isClicked == false)
		{
            GUI.DrawTexture(new Rect(mouse_pos.x -40f, Screen.height - mouse_pos.y -60f , 100, 100), UserCursor);
        }
		else
		{
            GUI.DrawTexture(new Rect(mouse_pos.x - 40f, Screen.height - mouse_pos.y -60f, 100, 100), UserClickCursor);
        }
	}

}
