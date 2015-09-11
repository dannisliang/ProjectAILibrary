using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Button 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlButtonReader : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlButtonReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlButtonReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 대상 스크립트에서 필요한 버튼의 개수를 가져옵니다. 버튼이 필요한 스크립트가 아닐 시 예외가 throw됩니다.
        /// </summary>
        /// <param name="scriptID">구하고자 하는 버튼 개수가 담겨있는 스크립트 ID입니다.</param>
        /// <returns>이 스크립트에서 필요한 버튼의 개수입니다.</returns>
        public int GetButtonNumber(int scriptID)
        {
            if (this.IsNeedThisScript(0, scriptID))
            {
                return int.Parse(base.GetLevelTwoElementValueFromXml("ButtonNumber", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 버튼 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 버튼에 쓰여질 메시지를 가져옵니다. 버튼이 필요한 스크립트가 아닐 시 예외가 throw됩니다.
        /// </summary>
        /// <param name="scriptID">가져오고자 하는 메시지가 있는 스크립트 ID입니다.</param>
        /// <returns>버튼에 쓰여질 메시지 배열입니다.</returns>
        public string[] GetButtonMessage(int scriptID)
        {
            if (this.IsNeedThisScript(0, scriptID))
            {
                string[] gottenMessage = base.GetLevelTwoElementValueFromXml("ButtonMessage", scriptID).Split('/');
                CheckHasWrongLength(gottenMessage, scriptID);
                return gottenMessage;
            }

            throw new InvalidOperationException("이 스크립트는 버튼 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 버튼과 연결된 파일의 경로들을 가져옵니다. 버튼이 필요한 스크립트가 아닐 시 예외가 throw됩니다.
        /// </summary>
        /// <param name="scriptID">가져오고자 하는 메시지가 있는 스크립트 ID입니다.</param>
        /// <returns>버튼과 연결된 파일의 경로들입니다.</returns>
        public string[] GetButtonLinkedScript(int scriptID)
        {
            if (this.IsNeedThisScript(0, scriptID))
            {
                string[] gottenMessage = base.GetLevelTwoElementValueFromXml("ButtonLinkTo", scriptID).Split('/');
                CheckHasWrongLength(gottenMessage, scriptID);
                return gottenMessage;
            }

            throw new InvalidOperationException("이 스크립트는 버튼 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 ButtonScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 ButtonScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(0, scriptID))
            {
                return new ButtonScript(this.GetButtonLinkedScript(scriptID), this.GetButtonMessage(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 버튼 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 불러온 결과물이 Xml 파일에 기재된 버튼의 개수가 같은지 검사합니다. 같지 않을 경우 예외가 throw됩니다.
        /// </summary>
        /// <param name="toCheck">확인할 문자열의 배열입니다.</param>
        /// <param name="scriptID">확인할 스크립트가 들어있는 ID입니다.</param>
        private void CheckHasWrongLength(string[] toCheck, int scriptID)
        {
            if (toCheck.Length != this.GetButtonNumber(scriptID))
            {
                throw new InvalidOperationException("구해진 메시지의 개수가 설정된 버튼 개수와 다릅니다.");
            }
        }
    }
}
