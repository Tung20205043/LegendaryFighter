using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardNoticeUI : NoticeUI
{
    public static RewardNoticeUI Instance { get; private set; }

    protected override void OnclickOkButton() {
        base.OnclickOkButton();
        SpecialUnityEvent.Instance.spawnCoin?.Invoke();
    }

}
