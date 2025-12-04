using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    //Який принцип S.O.L.I.D. порушено? Виправте!
    //Тут було порушено принцип єдиної відповідальності (Single Responsibility Principle).
    class Item
    {
        
    }
    class Order
    {
        private List<Item> itemList;
        
        internal IReadOnlyList<Item> ItemList => itemList.AsReadOnly(); 
        public Order(List<Item> items) {/*...*/}

        public void CalculateTotalSum() {/*...*/}
        public void GetItemCount() {/*...*/}
        public void AddItem(Item item) {/*...*/}
        public void DeleteItem(Item item) {/*...*/}

    }
    class OrderViewer
    {
        public void PrintOrder() {/*...*/}
        public void ShowOrder() {/*...*/}
    }
    class OrderRepository
    {
        public void Load() {/*...*/}
        public void Save() {/*...*/}
        public void Update() {/*...*/}
        public void Delete() {/*...*/} 
    }

    class Program
    {
        static void Main()
        {
            var items = new List<Item> { new Item(), new Item() };
            var order = new Order(items);

            var viewer = new OrderViewer();
            viewer.ShowOrder(order);

            var repository = new OrderRepository();
            repository.Save(order);
        }
    }
}