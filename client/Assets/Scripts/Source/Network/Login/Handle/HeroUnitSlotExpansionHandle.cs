﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Base;
using Game.Network;

//单位槽扩张句柄
//Author sunyi
//2013-12-27
public class HeroUnitSlotExpansionHandle : HTTPHandleBase
{
    /// <summary>
    /// 获取Action
    /// </summary>
    /// <returns></returns>
    public override string GetAction()
    {
        return PACKET_DEFINE.UNIT_EXPANSION_REQ;
    }

    /// <summary>
    /// 执行句柄
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public override bool Excute(HTTPPacketBase packet)
    {
        HeroUnitSlotExpansionPktAck ack = (HeroUnitSlotExpansionPktAck)packet;

        GAME_LOG.LOG("code :" + ack.m_iErrorCode);
        GAME_LOG.LOG("desc :" + ack.m_strErrorDes);

        GUI_FUNCTION.LOADING_HIDEN();

        if (ack.m_iErrorCode != 0)
        {
            GUI_FUNCTION.MESSAGEL(null, ack.m_strErrorDes);
            return false;
        }

        Role.role.GetBaseProperty().m_iDiamond = ack.m_iDiamondCount;
        Role.role.GetBaseProperty().m_iMaxHeroCount = ack.m_iMaxHeroCount;

        GUIBackFrameTop top = (GUIBackFrameTop)GameManager.GetInstance().GetGUIManager().GetGUI(GUI_DEFINE.GUIID_BACKFRAMETOP);
        top.UpdateDiamond(Role.role.GetBaseProperty().m_iDiamond);

        GUIUnitSlotExpansion unit = (GUIUnitSlotExpansion)GameManager.GetInstance().GetGUIManager().GetGUI(GUI_DEFINE.GUIID_UNITSLOTEXPANSION);
        unit.Hiden();

        GUIStore store = (GUIStore)GameManager.GetInstance().GetGUIManager().GetGUI(GUI_DEFINE.GUIID_STORE);
        store.Show();

        return true;
    }
}
