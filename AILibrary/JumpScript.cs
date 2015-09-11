using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 다른 Script로 이동하는 스크립트 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class JumpScript : Script
    {
        /// <summary>
        /// 주어진 정보를 이용하여 JumpScript 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="linkedScript">이 스크립트에서 연결될 스크립트입니다.</param>
        public JumpScript(string linkedScript)
        {
            base.ScriptCode = (int)ScriptTypeCode.JumpScript;
            base.IsStepScript = false;
            this.TargetScript = linkedScript;
        }

        /// <summary>
        /// 목표가 되는 스크립트를 가져옵니다.
        /// </summary>
        public string TargetScript
        {
            get; private set;
        }
    }
}
