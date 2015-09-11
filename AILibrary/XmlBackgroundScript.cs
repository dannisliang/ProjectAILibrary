using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Background 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlBackgroundScript : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlBackgroundReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlBackgroundScript(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {

        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트의 이미지(Sprite)를 읽어옵니다. Xml 엘리먼트의 값을 통해 Resources 폴더 하위에 있는 Images 폴더에서 가져옵니다.
        /// </summary>
        /// <param name="scriptID">가져오고자 하는 이미지가 들어있는 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 스크립트 이미지입니다.</returns>
        public Sprite GetSprite(int scriptID)
        {
            if (this.IsNeedThisScript(8, scriptID))
            {
                return Resources.Load<Sprite>("Images/" + base.GetLevelTwoElementValueFromXml("Background", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 배경 화면 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트에서 현재 UI를 덮어서 적용되는 것인지 여부를 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 결과입니다.</returns>
        public bool GetIsWrappingUI(int scriptID)
        {
            if (this.IsNeedThisScript(8, scriptID))
            {
                return bool.Parse(base.GetLevelTwoElementValueFromXml("Wrap", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 배경 화면 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 BackgroundScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 BackgroundScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(8, scriptID))
            {
                return new BackgroundScript(this.GetSprite(scriptID), this.GetIsWrappingUI(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 배경 화면 스크립트에 해당하지 않는 스크립트입니다.");
        }
    }
}
