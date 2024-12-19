using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;


namespace Itens
{

    public class ItemLayoutManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public ItemLayout prefabLayout;
        public Transform container;
        public List<ItemLayout> itemLayouts;

        private void Start()
        {
            CreateItem();

        }

        private void CreateItem()
        {
            foreach (var setup in CoinsManager.Instance.itemSetups)
            {
                var item = Instantiate(prefabLayout, container);
                item.Load(setup);
                itemLayouts.Add(item);
            }
        }

    }

}
