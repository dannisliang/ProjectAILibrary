using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 아이템에 대한 정보를 담고 있는 추상 클래스입니다.
    /// </summary>
    public abstract class Item : IUsableItem
    {
        private static Dictionary<int, Item> idList = new Dictionary<int, Item>(); // 현재까지 생성된 아이템들의 ID를 가지고 있는 LIst입니다.

        /// <summary>
        /// 아이템의 ID가 다른 아이템들의 ID와 충돌하지 않는지 체크합니다. 겹칠 시에는 예외가 발생합니다.
        /// </summary>
        /// <param name="itemID">검사하고자 하는 ID입니다.</param>
        private static void CheckUniqueID(int itemID)
        {
            if (idList.ContainsKey(itemID))
            {
                throw new ArgumentException("Item 인스턴스 생성 중 오류 발생 : 생성하고자 하는 아이템의 ID를 이미 다른 아이템이 가지고 있습니다.");
            }
        }

        /// <summary>
        /// 아이템 구성을 위해 필요한 정보를 통해 Item 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="itemID">해당 Item의 고유 ID를 가리킵니다.</param>
        /// <param name="name">해당 Item의 이름입니다.</param>
        /// <param name="itemSprite">아이템의 이미지를 나타냅니다. 기본 값은 null입니다.</param>
        /// <param name="itemDescription">이 아이템에 대한 설명문을 나타냅니다.</param>
        /// <param name="isGet">획득되었는지에 대한 여부입니다. 기본 값은 False입니다.</param>
        /// <param name="isImported">Import 되었는지에 대한 여부입니다. 기본 값은 False입니다.</param>
        public Item(int itemID, string name, Sprite itemSprite = null, string itemDescription = "", bool isGet = false, bool isImported = false)
        {
            CheckUniqueID(itemID);          // 겹치는 아이템 ID인지 검사합니다.

            this.ItemDescription = itemDescription;
            this.ItemID = itemID;
            this.IsGet = isGet;
            this.IsImported = isImported;
            this.Name = name;
            this.ItemSprite = itemSprite;

            idList.Add(this.ItemID, this);        // ID List에 현재 추가된 아이템의 ID를 추가합니다.
        }

        /// <summary>
        /// 이 아이템의 고유 ID를 가져옵니다. 읽기 전용 프로퍼티입니다.
        /// </summary>
        public int ItemID
        {
            get;
            private set;
        }

        /// <summary>
        /// 이 아이템의 이름을 가져옵니다. 읽기 전용 프로퍼티입니다.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 이 아이템의 획득 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsGet
        {
            get;
            set;
        }

        /// <summary>
        /// 이 아이템이 Import 되었는지에 대한 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsImported
        {
            get;
            set;
        }

        /// <summary>
        /// 현재 아이템의 이미지(Sprite)를 가져옵니다. 읽기 전용 프로퍼티입니다.
        /// </summary>
        public Sprite ItemSprite
        {
            get;
            private set;
        }

        /// <summary>
        /// 이 아이템에 대한 설명을 가져옵니다.
        /// </summary>
        public string ItemDescription
        {
            get;
            private set;
        }

        /// <summary>
        /// 아이템 배열에서 찾고자 하는 아이템을 찾아줍니다. 찾지 못하면 null을 반환합니다.
        /// </summary>
        /// <param name="items">여러 아이템이 들어있는 배열입니다.</param>
        /// <param name="nameToFind">찾고자 하는 아이템의 이름입니다.</param>
        /// <returns>찾은 아이템입니다.</returns>
        public static Item FindItem(Item[] items, string nameToFind)
        {
            return Array.Find<Item>(items, (item => item.Name == nameToFind));
        }

        /// <summary>
        /// 이미 생성된 적 있던 아이템을 탐색하여 반환합니다.
        /// </summary>
        /// <param name="itemIdToFind">찾으려고 하는 아이템의 아이디입니다.</param>
        /// <returns>결과입니다.</returns>
        public static Item ItemFromDictionary(int itemIdToFind)
        {
            try
            {
                return idList[itemIdToFind];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}