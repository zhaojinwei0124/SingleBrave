using UnityEngine;
using System.Collections;
using Game.Base;


//  ITDAnimation.cs
//  Author: Lu Zexi
//  2012-11-29

/// <summary>
/// 2D动画组件接口
/// </summary>
public interface ITDAnimation {
	
	bool Update();                                              //逻辑更新
	void Play(string name, TDAnimationMode mode , float speed); //播放某动作
    void Play(string name, TDAnimationMode mode);               //播放某动作
	void Stop();                                                //停止播放动作
	bool IsPlay();                                              //是否正在播放动作
    bool IsPlay(string aniName);                                //是否正在播放某动作
}

