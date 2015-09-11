using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AILibrary
{
    /// <summary>
    /// Xml 파일을 읽어오는 클래스를 구성하는 추상 클래스입니다.
    /// </summary>
    public abstract class XmlReader
    {
        /// <summary>
        /// 이 XmlReader가 참조하고 있는 Xml 파일을 가리킵니다.
        /// </summary>
        protected XDocument targetXmlFile;

        /// <summary>
        /// 주어진 정보를 이용하여 XmlReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlReader(string filePathOrContent, bool isPath)
        {
            if (isPath)
            {
                this.targetXmlFile = XDocument.Load(filePathOrContent);
            }
            else
            {
                this.targetXmlFile = XDocument.Parse(filePathOrContent);
            }
        }

        ///// <summary>
        ///// 이 인스턴스를 XmlMessageReader 인스턴스로 변환합니다.
        ///// </summary>
        ///// <param name="toConvert">바꾸려고 하는 인스턴스입니다.</param>
        //public static explicit operator XmlMessageReader(XmlInputReader toConvert)
        //{
        //    return new XmlMessageReader(toConvert.targetXmlFile.ToString(), false);
        //}

        /// <summary>
        /// 현재 참조하려고 하는 Xml 파일이 유효한 Xml 파일인지 검사합니다. 유효하지 않을 시 예외가 throw 됩니다.
        /// </summary>
        public abstract void CheckValidXmlContent();

    }
}
