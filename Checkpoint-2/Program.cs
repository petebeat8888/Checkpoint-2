/*
 *  Kod för att genera en produkt lista
 *  Som sorteras med hjälp av LINQ
 * 
 * 
 * 
 * 
 */



// Create Lists

List<Product> productlist = new();
List<CategoryList> categorylist = new();



while (true)
{

    int intPrice = 0;
    // declare empty strings
    string priceInput = ""; 
    string categoryInput = "";
    string productnameInput = "";

    // reset color
    Console.ResetColor();

    Console.WriteLine("");
    Console.WriteLine("Lägg till ny produkt.");
    Console.WriteLine("Avsluta med q för att visa listan.");
    Console.WriteLine("");


    // input Category
    while (true)
    {
        Console.ResetColor();
        Console.Write("Skriv in din produkts kategori: ");
        categoryInput = Console.ReadLine();

        if (categoryInput.ToLower().Trim() == "q")
        {
            break;
        }

        if (string.IsNullOrWhiteSpace(categoryInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktig input! verkar vara tom. Försök igen.");
            continue;
        }
        else
        {
            break;
        }
    }
    if (categoryInput.ToLower().Trim() == "q")
    {
        string response = Showlist(productlist, categorylist);
        if(response == "yes")
        {
            continue;
        }
        else
        {
            break;
        }
    }


    // input Product name
    while (true)
    {
        Console.ResetColor();
        Console.Write("Skriv in din produkts namn: ");
        productnameInput = Console.ReadLine();

        if (productnameInput.ToLower().Trim() == "q")
        {
            break;
        }
        if (string.IsNullOrWhiteSpace(productnameInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktig input! verkar vara tom. Försök igen.");
            continue;
        }
        else
        {
            break;
        }
    }
    if (productnameInput.ToLower().Trim() == "q")
    {
        string response = Showlist(productlist, categorylist);
        if (response == "yes")
        {
            continue;
        }
        else if (response != "no")
        {
            //Console.WriteLine("Du sökte efter:" + response);
            break;
        }
        else
        {
            break;
        }
    }


    // input Price
    while (true) {
        Console.ResetColor();
        Console.Write("Skriv in din produkts pris: ");
        priceInput = Console.ReadLine();

        if (priceInput.ToLower().Trim() == "q")
        {
            break;
        }

        bool Success = int.TryParse(priceInput, out intPrice);

        if (Success == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktigt pris värde! Försök igen.(endast siffror)");
            continue;
        }
        else
        {
            break;
        }
    }
    if (priceInput.ToLower().Trim() == "q")
    {
        string response = Showlist(productlist, categorylist);
        if (response == "yes")
        {
            continue;
        }
        else
        {
            break;
        }
    }


    productlist.Add(new Product(categoryInput, productnameInput, intPrice));

    // I want to just add unique values but havent yet figured out how to do that, was gonna use Distinct() but havent figured out how to
    categorylist.Add(new CategoryList(categoryInput));


}




static string Showlist(List<Product> productlistRef, List<CategoryList> categoryRef)
{

    List<Product> sortedProducts = productlistRef.OrderBy(product => product.Price).ToList();

    Console.ResetColor();
    Console.WriteLine("");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("Lista på Samtliga produkter:");
    Console.WriteLine("Kategori".PadRight(15) + "Produkt namn".PadRight(15) + "Pris");

    foreach (Product product in sortedProducts)
    {
        Console.WriteLine(product.Category.PadRight(15) + product.Productname.PadRight(15) + product.Price.ToString());
    }

    int sumPrice = sortedProducts.Sum(product => product.Price);

    Console.WriteLine("");
    Console.WriteLine("Pris för samtliga produkter: " + sumPrice);

    ShowCategories(categoryRef);

    Console.WriteLine("-------------------");
    Console.Write("Vill du lägga till fler produkter? (y/n)");
    //Console.WriteLine("Vill du söka efter en viss produkt? (skriv produktens namn istället)");

    string more = Console.ReadLine();
    if (more.ToLower().Trim() == "y")
    {
        return "yes";
    }
    else if (more.Trim() != "")
    {
        // does not work
        //List<Product> prodSearch = productlistRef.Where(product => product.Productname == more);
        //IEnumerable<string> prodSearch = (IEnumerable<string>)sortedProducts.Select(product => product.Productname == more);

        //return prodSearch;
        return "";
    }
    else
    {
        return "no";
    }


}



static void ShowCategories(List<CategoryList> categorylistRef)
{
    List<CategoryList> sortedCategories = categorylistRef.OrderBy(product => product.CategoryAll).ToList();

    Console.ResetColor();
    Console.WriteLine("");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("Lista på Samtliga kategorier:");
    Console.WriteLine("Kategori");

    foreach (CategoryList product in sortedCategories)
    {
        Console.WriteLine(product.CategoryAll);
    }

}



                                                                                                                                                

class Product
{
    public Product(string category, string productname, int price)
    {
        Category = category;
        Productname = productname;
        Price = price;
    }

    public string Category { get; set; }
    public string Productname { get; set; }
    public int Price { get; set; }

}


class CategoryList
{
    public CategoryList(string category)
    {
        CategoryAll = category;
    }

    public string CategoryAll { get; set; }

}








