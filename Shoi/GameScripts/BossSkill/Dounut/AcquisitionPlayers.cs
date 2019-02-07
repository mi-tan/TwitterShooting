﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquisitionPlayers : MonoBehaviour {

    private AttackArea attackArea;

    private void Start()
    {
        attackArea = transform.parent.GetComponent<AttackArea>();
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log(other.name);
        PlayerProvider playerProvider = other.GetComponent<PlayerProvider>();
        // プレイヤー以外をここで除外
        if (playerProvider == null)
        {
            // Debug.Log(other.gameObject+"を除外");
            return;
        }
        // 取得するべきプレイヤーか判断するフラグ
        bool playerAddFlag = true;

        for (int i = 0; attackArea.GetAcquisitionPlayerList.Count > i; i++)
        {
            // もうすでに取得しているプレイヤーであれば除外
            if (attackArea.GetAcquisitionPlayerList[i].gameObject == other.gameObject)
            {
                // Debug.Log("もう登録されてるよ！");
                playerAddFlag = false;
                break;
            }
        }

        if (playerAddFlag)
        {
            // Debug.Log(other.gameObject + "を追加");
            // 追加
            attackArea.AddAcquisitonPlayerList = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerProvider playerProvider = other.GetComponent<PlayerProvider>();
        // プレイヤー以外をここで除外
        if (playerProvider != null)
        {
            attackArea.RemoveAcquisitonPlayerList = other.gameObject;
            // Debug.Log(other.gameObject + "を削除");
        }
        else
        {
            // Debug.Log(other.gameObject + "は削除できません");
        }
    }
}
