using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 하나의 버튼 Script 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class ButtonScript : Script
    {
        private List<string> buttonMessage;
        private List<string> linkedScript;

        /// <summary>
        /// 선택지를 주는 스크립트일 경우의 인스턴스를 초기화합니다. 만약 분기점을 주는 스크립트가 아니라면 이 생성자를 사용하지 마십시오.
        /// </summary>
        /// <param name="linkedScript">버튼과 연결되는 파일의 경로를 가리킵니다.</param>
        /// <param name="buttonMessage">버튼의 내용을 가리킵니다.</param> 
        public ButtonScript(string[] linkedScript, params string[] buttonMessage)
        {
            base.ScriptCode = (int)ScriptTypeCode.ButtonScript;
            base.IsStepScript = true;
            this.ButtonNumber = buttonMessage.Length;
            this.buttonMessage = new List<string>(buttonMessage);
            this.linkedScript = new List<string>(linkedScript);
        }

        /// <summary>
        /// 모든 버튼의 내용을 가져옵니다.
        /// </summary>
        public string[] ButtonMessage
        {
            get { return this.buttonMessage.ToArray(); }
        }

        /// <summary>
        /// 버튼과 연결되는 파일들의 경로를 가져옵니다.
        /// </summary>
        public string[] LinkedScript
        {
            get { return this.linkedScript.ToArray(); }
        }

        /// <summary>
        /// 이 스크립트에서 사용할 버튼의 개수를 가져옵니다.
        /// </summary>
        public int ButtonNumber
        {
            get;
            private set;
        }
    }
}
