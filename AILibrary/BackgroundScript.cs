using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 잠시 멈추는 행동을 하는 스크립트 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class BackgroundScript : Script
    {
        /// <summary>
        /// 주어진 정보를 이용하여 BackgroundScript 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="spriteToUse">사용할 Sprite 파일을 가리킵니다.</param>
        /// <param name="isWrappingUI">이 스크립트가 현재 UI를 덮어서 적용되는 것인지 결정합니다.</param>
        public BackgroundScript(Sprite spriteToUse, bool isWrappingUI)
        {
            base.ScriptCode = (int)ScriptTypeCode.BackgroundScript;
            base.IsStepScript = false;
            this.BackgroundSprite = spriteToUse;
            this.IsWrappingUI = isWrappingUI;
        }

        /// <summary>
        /// 배경으로 사용할 Sprite를 가져옵니다.
        /// </summary>
        public Sprite BackgroundSprite
        {
            get;
            private set;
        }

        /// <summary>
        /// 이 스크립트가 현재 UI를 덮어서 적용되는 것인지 여부를 가져옵니다.
        /// </summary>
        public bool IsWrappingUI
        {
            get;
            private set;
        }
    }
}
