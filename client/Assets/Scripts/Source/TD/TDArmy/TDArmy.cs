using System;
using UnityEngine;
using System.Collections.Generic;



//  TDArmy.cs
//  Rewriter: Lu Zexi
//  2012-01-06




/// <summary>
/// 2D渲染类军队
/// </summary>
public class TDArmy : TDObject
{
	private int m_iMovieClipMaxNum = 16;   //最大数
    private float[,] m_vecPoss; //站位位置
    
    public TDArmy(Transform parent, UIAtlas atlas, float[,] poss, int num,int depth)
        :base(parent,atlas)
    {
        this.m_iMovieClipMaxNum = num;
        this.m_vecPoss = poss;
        for (int i = 0; i < m_iMovieClipMaxNum; i++)
        {
            ITDMovieClip td_mc = new TDMovieClip(this.m_cAtlas);
            td_mc.SetParent(this.m_cTransform);
            td_mc.SetDepth(depth + i);
            AddTDMovieClip(td_mc);
            
        }

        for (int i = 0; i < poss.GetLength(0) && i < this.m_lstTDMoveClip.Count; i++)
        {
            this.m_lstTDMoveClip[i].SetLocalPos(new Vector3(poss[i, 0], poss[i, 1], 0));
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Initialize()
    { 
        //
    }

    /// <summary>
    /// 增加影片剪辑
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public override int AddMovieClipNum(int num)
    {
        for (int i = 0; i < this.m_vecPoss.GetLength(0) && i < this.m_lstTDMoveClip.Count; i++)
        {
            this.m_lstTDMoveClip[i].SetLocalPos(new Vector3(this.m_vecPoss[i, 0], this.m_vecPoss[i, 1], 0));
        }
        return num;
    }

    /// <summary>
    /// 获取影片剪辑最大数
    /// </summary>
    /// <returns></returns>
    public override int GetMovieClipMaxNum()
    {
        return this.m_iMovieClipMaxNum;
    }
	
}

