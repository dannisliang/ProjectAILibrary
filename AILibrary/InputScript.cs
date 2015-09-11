using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 하나의 입력 Script 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class InputScript : Script
    {
        private List<string> messageCase;
        private List<string> linkedScript;

        /// <summary>
        /// 사용자의 입력을 받는 스크립트의 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="linkedScript">각 입력과 대응되어 연결되는 파일의 경로를 가리킵니다.</param>
        /// <param name="messageCase">모든 입력 경우을 가리킵니다.</param> 
        public InputScript(string[] linkedScript, params string[] messageCase)
        {
            base.ScriptCode = (int)ScriptTypeCode.InputScript;
            base.IsStepScript = true;
            this.CaseNumber = messageCase.Length;
            this.messageCase = new List<string>(messageCase);
            this.linkedScript = new List<string>(linkedScript);
        }

        /// <summary>
        /// 모든 입력 케이스의 내용을 가져옵니다.
        /// </summary>
        public string[] MessageCases
        {
            get { return this.messageCase.ToArray(); }
        }

        /// <summary>
        /// 각 입력들과 연결되는 파일들의 경로를 가져옵니다.
        /// </summary>
        public string[] LinkedScript
        {
            get { return this.linkedScript.ToArray(); }
        }

        /// <summary>
        /// 이 스크립트에서 입력받는 입력 종류의 개수를 가져옵니다.
        /// </summary>
        public int CaseNumber
        {
            get;
            private set;
        }
    }
}
