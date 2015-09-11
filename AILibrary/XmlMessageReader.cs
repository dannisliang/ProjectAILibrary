using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Message 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlMessageReader : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlMessageReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlMessageReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트의 메시지를 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">가져오고자 하는 메시지가 들어있는 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 스크립트 메시지입니다.</returns>
        public string GetMessage(int scriptID)
        {
            if (this.IsNeedThisScript(1, scriptID))
            {
                return base.GetLevelTwoElementValueFromXml("Message", scriptID);
            }

            throw new InvalidOperationException("이 스크립트는 메시지 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트의 캐릭터 이름을 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">가져오고자 하는 메시지가 들어있는 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 스크립트 메시지입니다.</returns>
        //[Obsolete("현재 딱히 인물의 이름을 불러오는 스크립트가 존재하지 않으므로, 사용하지 않습니다.")]
        public string GetCharacter(int scriptID)
        {
            if (this.IsNeedThisScript(1, scriptID))
            {
                return base.GetLevelTwoElementValueFromXml("Character", scriptID);
            }

            throw new InvalidOperationException("이 스크립트는 메시지 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트의 이미지(Sprite)를 읽어옵니다. Xml 엘리먼트의 값을 통해 Resources 폴더 하위에 있는 Images 폴더에서 가져옵니다.
        /// </summary>
        /// <param name="scriptID">가져오고자 하는 이미지가 들어있는 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 스크립트 이미지입니다.</returns>
        public Sprite GetSprite(int scriptID)
        {
            if (this.IsNeedThisScript(1, scriptID))
            {
                return Resources.Load<Sprite>("Images/" + base.GetLevelTwoElementValueFromXml("Sprite", scriptID));
            }
            
            throw new InvalidOperationException("이 스크립트는 메시지 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 MessageScript 인스턴스를 만듭니다. 반환된 인스턴스는 기본 대화 인물의 이름을 가져옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 MessageScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(1, scriptID))
            {
                return new MessageScript(this.GetMessage(scriptID), this.GetSprite(scriptID));
            }
            
            throw new InvalidOperationException("이 스크립트는 메시지 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 MessageScript 인스턴스를 만듭니다. 반환된 인스턴스는 스크립트에서 대화 인물의 이름도 포함하여 가져옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 MessageScript 인스턴스입니다.</returns>
        public Script GetFullScript(int scriptID)
        {
            if (this.IsNeedThisScript(1, scriptID))
            {
                return new MessageScript(this.GetCharacter(scriptID), this.GetMessage(scriptID), this.GetSprite(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 메시지 스크립트에 해당하지 않는 스크립트입니다.");
        }
    }
}