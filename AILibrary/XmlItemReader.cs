using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 아이템 정보가 들어있는 Xml 파일을 읽어 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlItemReader : XmlReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlItemReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlItemReader(string filePathOrContent, bool isPath)
            : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 현재 참조하려고 하는 Xml 파일이 유효한 Xml 파일인지 검사합니다. 유효하지 않을 시 예외가 throw 됩니다.
        /// </summary>
        public override void CheckValidXmlContent()
        {
            if (this.targetXmlFile.Root.Name != "Item")
            {
                throw new NotSupportedException("잘못된 Xml 파일에 접근하려고 합니다. (Item)");
            }
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 정보를 WorkBook 인스턴스로 return 합니다.
        /// </summary>
        /// <returns>WorkBook 인스턴스입니다.</returns>
        public WorkBook GetItemAsWorkBook()
        {
            if (Item.ItemFromDictionary(this.GetID()) != null)
            {
                return (WorkBook) Item.ItemFromDictionary(this.GetID());
            }

            return new WorkBook(this.GetID(), this.GetItemName(), this.GetSprite(), this.GetItemDescription());
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 정보를 PartialData 인스턴스로 return 합니다.
        /// </summary>
        /// <returns>PartialData 인스턴스입니다.</returns>
        public PartialData GetItemAsPartialData()
        {
            if (Item.ItemFromDictionary(this.GetID()) != null)
            {
                return (PartialData)Item.ItemFromDictionary(this.GetID());
            }

            return new PartialData(this.GetID(), this.GetItemName(), this.GetSprite(), this.GetItemDescription());
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 정보를 UnknownData 인스턴스로 return 합니다.
        /// </summary>
        /// <returns>UnknownData 인스턴스입니다.</returns>
        public UnknownData GetItemAsUnknownData()
        {
            if (Item.ItemFromDictionary(this.GetID()) != null)
            {
                return (UnknownData)Item.ItemFromDictionary(this.GetID());
            }

            return new UnknownData(this.GetID(), this.GetItemName(), this.GetSprite(), this.GetItemDescription());
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 정보를 DataAddress 인스턴스로 return 합니다.
        /// </summary>
        /// <returns>DataAddress 인스턴스입니다.</returns>
        public DataAddress GetItemAsDataAddress()
        {
            if (Item.ItemFromDictionary(this.GetID()) != null)
            {
                return (DataAddress)Item.ItemFromDictionary(this.GetID());
            }
            return new DataAddress(this.GetID(), this.GetItemName(), this.GetSprite(), this.GetItemDescription());
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템에 대한 설명을 가져옵니다.
        /// </summary>
        /// <returns>아이템의 이름입니다.</returns>
        public string GetItemDescription()
        {
            IEnumerable<string> descriptionValue = from itemElem in this.targetXmlFile.Root.Elements()
                                            where itemElem.Name == "Description"
                                            select itemElem.Value;

            return descriptionValue.ToArray<string>()[0];
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 이름을 가져옵니다.
        /// </summary>
        /// <returns>아이템의 이름입니다.</returns>
        public string GetItemName()
        {
            IEnumerable<string> nameValue = from itemElem in this.targetXmlFile.Root.Elements()
                                            where itemElem.Name == "Name"
                                            select itemElem.Value;

            return nameValue.ToArray<string>()[0];
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 ID를 가져옵니다.
        /// </summary>
        /// <returns>아이템 ID입니다.</returns>
        public int GetID()
        {
            IEnumerable<string> idValue = from itemElem in this.targetXmlFile.Root.Elements()
                                          where itemElem.Name == "ID"
                                          select itemElem.Value;

            return int.Parse(idValue.ToArray<string>()[0]);
        }

        /// <summary>
        /// 현재 참조 중인 Xml 파일에서 아이템 이미지(Sprite)를 가져옵니다. 가져올 때는 Resources 폴더 하위에 있는 Images 폴더에서 참조하게 됩니다.
        /// </summary>
        /// <returns>아이템의 이미지 (Sprite)입니다.</returns>
        public Sprite GetSprite()
        {
            IEnumerable<string> spriteValue = from itemElem in this.targetXmlFile.Root.Elements("Sprite")
                                              select itemElem.Value;
            
            return Resources.Load<Sprite>("Images/" + spriteValue.ToArray<string>()[0]);
        }
    }
}
