using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 하나의 사운드 Script 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class SoundScript : Script
    {
        /// <summary>
        /// 사운드 파일을 반복해서 재생할 것인지에 대한 여부입니다.
        /// </summary>
        public bool IsRepeat
        {
            get; private set;
        }

        /// <summary>
        /// 대상 사운드 파일입니다.
        /// </summary>
        public AudioClip Sound
        {
            get; private set;
        }

        /// <summary>
        /// 주어진 정보를 이용하여 SoundScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="toPlay">재생할 사운드 파일입니다.</param>
        /// <param name="isRepeat">이 사운드 파일을 반복하여 재생할 것인지에 대한 여부입니다. 기본 값은 False입니다.</param>
        public SoundScript(AudioClip toPlay, bool isRepeat = false)
        {
            base.ScriptCode = (int)ScriptTypeCode.SoundScript;
            base.IsStepScript = false;
            this.Sound = toPlay;
            this.IsRepeat = isRepeat;
        }
    }
}
