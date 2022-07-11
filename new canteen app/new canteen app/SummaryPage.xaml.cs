using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace new_canteen_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryPage : ContentPage
    {
        decimal totalPrice;




        List<string> items = new List<string>();


        List<FoodItems> foodItems = new List<FoodItems>();
        FoodItems burger = new FoodItems(4M, "Burger", 0);
        FoodItems chickenburger = new FoodItems(3.50M, "Chicken Burger", 0);
        FoodItems chips = new FoodItems(2M, "Chips", 0);
        FoodItems mash = new FoodItems(1.5M, "Mash", 0);
        FoodItems water = new FoodItems(0.8M, "Water", 0);
        FoodItems coke = new FoodItems(1M, "Coke", 0);


        public SummaryPage()
        {
            InitializeComponent();
        }

                

        private void AddToKart(object sender, EventArgs e)
        {
            var button = (ImageButton)sender; 
            var classId = button.ClassId;

            if(classId == "Burger")
            {
                receiptFunction(burger, classId);
            }

            if (classId == "ChickenBurger")
            {
                receiptFunction(chickenburger, classId);


            }

            if (classId == "Chips")
            {

                receiptFunction(chips, classId);

            }

            if (classId == "Mash")
            {
                receiptFunction(mash, classId);

            }

            if (classId == "Water")
            {
                receiptFunction(water, classId);

            }

            if (classId == "Coke")
            {

                receiptFunction(coke, classId);
            }

            Price.Text = ("Total: £" + totalPrice);
        }

        public void receiptFunction(FoodItems item, string classId)
        {
            totalPrice = totalPrice + item.price;
            if (foodItems.Contains(item) == false)
            {

                foodItems.Add(item);
            }

            item.quantity++;
        }



        private void ClearBasket()
        {
            foodItems.Clear();

            burger = new FoodItems(4M, "Burger", 0);
            chickenburger = new FoodItems(3.50M, "Chicken Burger", 0);
            chips = new FoodItems(2M, "Chips", 0);
            mash = new FoodItems(1.5M, "Mash", 0);
            water = new FoodItems(0.8M, "Water", 0);
            coke = new FoodItems(1M, "Coke", 0);

            totalPrice = 0;
            Price.Text = ("Total: £" + totalPrice);


           



           
        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new OrderPage(foodItems, totalPrice));
        }

        private void Basket_Clear(object sender, EventArgs e)
        {
            ClearBasket();
        }
    }
}