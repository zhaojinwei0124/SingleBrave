using System;
using UnityEngine;
using Game.Base;

/// <summary>
/// 模拟影片剪辑类
/// </summary>
public class TDMovieClip : ITDMovieClip
{
	
	private UISprite m_cSprite;        //精灵实体
	private UIAtlas m_cAtlas;          //图集
	private ITDAnimation m_cTDAnimation;   //动画组件
	//private Transform m_cParent;        //父级
	
	public TDMovieClip(UIAtlas atlas)
	{
		//this.m_cParent = null;
		this.m_cAtlas = atlas;
		this.m_cTDAnimation = null;
        GameObject obj = new GameObject();
        this.m_cSprite = obj.AddComponent<UISprite>();
        this.m_cSprite.atlas = this.m_cAtlas;
        this.m_cSprite.MakePixelPerfect();
		Init();
	}
	
    /// <summary>
    /// 初始化
    /// </summary>
	private void Init ()
	{
		m_cTDAnimation  = new TDAnimation(m_cAtlas,m_cSprite);
		
        //if(m_cSprite != null)
        //{
        //    m_cParent = m_cSprite.transform;
        //}
	}

    /// <summary>
    /// 销毁
    /// </summary>
    public void Destroy()
    {
        GameObject.Destroy(this.m_cSprite);
        this.m_cSprite = null;
        this.m_cAtlas = null;
        //this.m_cParent = null;
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="name"></param>
    /// <param name="mode"></param>
    /// <param name="speed"></param>
	void ITDMovieClip.Play(string name, TDAnimationMode mode, float speed )
	{
		if(m_cTDAnimation != null)
		{
            m_cTDAnimation.Play(name, mode, speed);
		}
	}

    /// <summary>
    /// 逻辑更新
    /// </summary>
	bool ITDMovieClip.Update ()
	{
		if(m_cTDAnimation != null){
			m_cTDAnimation.Update();
		}

        return true;
	}

    /// <summary>
    /// 停止动画
    /// </summary>
	void ITDMovieClip.Stop ()
	{
		m_cTDAnimation.Stop();
	}

    /// <summary>
    /// 设置相对坐标
    /// </summary>
    /// <param name="position"></param>
	void ITDMovieClip.SetLocalPos (Vector3 position)
	{
        this.m_cSprite.transform.localPosition = position;
	}

    /// <summary>
    /// 设置父级
    /// </summary>
    /// <param name="parent"></param>
	void ITDMovieClip.SetParent (Transform parent)
	{
        //this.m_cParent = parent;
        this.m_cSprite.transform.parent = parent;
        this.m_cSprite.MakePixelPerfect();
	}

    /// <summary>
    /// 是否正在播放
    /// </summary>
    /// <returns></returns>
	bool ITDMovieClip.IsPlay()
	{
		return m_cTDAnimation.IsPlay();
	}

    /// <summary>
    /// 获取透明度
    /// </summary>
    /// <returns></returns>
    float ITDMovieClip.GetAlpha()
    {
        return this.m_cSprite.alpha;
    }

    /// <summary>
    /// 渲染深度
    /// </summary>
    /// <param name="depth"></param>
    void ITDMovieClip.SetDepth(int depth)
    {
        m_cSprite.depth = depth;
    }

    /// <summary>
    /// 设置透明度
    /// </summary>
    /// <param name="alpha"></param>
    void ITDMovieClip.SetAlpha(float alpha)
    {
        this.m_cSprite.alpha = alpha;
    }

    /// <summary>
    /// 是否正在播放某动作
    /// </summary>
    /// <param name="aniName"></param>
    bool ITDMovieClip.IsPlay(string aniName)
    {
        return this.m_cTDAnimation.IsPlay(aniName);
    }
		

}


