namespace CASH_Masters_POS_App;

public class Service
{
    #region Global Variables
    //--Global Variables
    private List<decimal> denominations = new List<decimal>();
    private List<decimal> products = new List<decimal>();
    private decimal totalCost = 0;
    decimal totalRecived = 0;
    private int menuOption = 0;
    #endregion

    public void runLogic()
    {
        //Select country and set currency
        selectCountry();

        do
        {
            Console.WriteLine("Please select menu option 1)Add Products 2)Pay 3)Exit");
            string optionString;
            do
            {
                optionString = Console.ReadLine();
            } while (!validIntNumber(optionString));
            menuOption = int.Parse(optionString);

            switch (menuOption)
            {
                case 1: //Add Products and get total
                    addProducts();
                    break;
                case 2: //Pay and get change
                    if(totalCost <= 0)
                        Console.WriteLine("No products");
                    else
                        pay();
                    break;
                case 3: // Exit program
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

        } while (menuOption != 3);

    }        

    private void selectCountry()
    {
        Console.WriteLine("Select your country: MX or US");
        string country = Console.ReadLine();            

        switch (country.ToUpper())
        {
            case "US":
                denominations.Add(0.01m);
                denominations.Add(0.05m);
                denominations.Add(0.10m);
                denominations.Add(0.25m);
                denominations.Add(0.50m);
                denominations.Add(1m);
                denominations.Add(2m);
                denominations.Add(5m);
                denominations.Add(10m);
                denominations.Add(20m);
                denominations.Add(50m);
                denominations.Add(100m);
                break;
            case "MX":
                denominations.Add(0.05m);
                denominations.Add(0.10m);
                denominations.Add(0.20m);
                denominations.Add(0.50m);
                denominations.Add(1m);
                denominations.Add(2m);
                denominations.Add(5m);
                denominations.Add(10m);
                denominations.Add(20m);
                denominations.Add(50m);
                denominations.Add(100m);
                break;
            default:
                Console.WriteLine("Dont exist " + country);
                selectCountry();
                break;
        }
    }

    private void addProducts()
    {
        int a = 0;
        do
        {
            Console.WriteLine("Select option 0)Add new product 1)No more products");
            string optionString;
            do
            {
                optionString = Console.ReadLine();
            } while (!validIntNumber(optionString));
            int option = int.Parse(optionString);

            if (option == 0)
            {
                Console.WriteLine("Add cost:");
                string productCostString = Console.ReadLine();

                if (validDecimalNumber(productCostString))
                {
                    decimal productCost = decimal.Parse(productCostString);
                    products.Add(productCost);
                }
                else
                {
                    addProducts();
                }
                
            }
            if (option == 1)
            {
                totalCost = products.Sum();
                Console.WriteLine("Total = " + totalCost);
                a = 1;
            }
        } while (a == 0);
    }

    private void pay()
    {
        Console.WriteLine("Enter payment");
        Console.WriteLine("Select option or 99 to pay");
        Console.WriteLine("Options: ");
        for (int x = 0; x < denominations.Count(); x++)
        {
            Console.Write(x + ")" + denominations[x] + ", ");
        }
        Console.WriteLine(" 99)Pay");
        int optionSelected = 0;
        do
        {
            string optionString;
            do
            {
                optionString = Console.ReadLine();
            } while (!validIntNumber(optionString));
            optionSelected = int.Parse(optionString);

            if (optionSelected <= denominations.Count())
            {
                if (optionSelected >= denominations.Count())
                {
                    Console.WriteLine("No valid option");
                }
                else
                {
                    totalRecived = totalRecived + denominations[optionSelected];
                    Console.WriteLine("Current balance: " + totalRecived);
                }
            }
            else if(optionSelected != 99){
                Console.WriteLine("No valid option");
            }                    

            if (optionSelected == 99)
            {
                //Valid minimum amout
                if (totalRecived < totalCost)
                {
                    Console.WriteLine("Insufficient balance to pay, please complete the minimum amount of " + totalCost);
                    optionSelected = 0;
                }
            }

        } while (optionSelected != 99);

        giveChange();
    }

    private void giveChange()
    {
        decimal change = totalRecived - totalCost;
        denominations.Reverse();
        Console.WriteLine("Your Change:");
        foreach (decimal d in denominations)
        {
            while (change >= d)
            {
                Console.WriteLine(d);
                change -= d;
            }
        }
        resetValues();
    }

    private void resetValues()
    {
        products.Clear();
        totalCost = 0;
        totalRecived = 0;
        denominations.Reverse();
    }

    public bool validDecimalNumber(string data)
    {
        decimal valor;
        bool esNumero;
        esNumero = decimal.TryParse(data, out valor);
        if (!esNumero)
            Console.WriteLine("No valid Option");
        return esNumero;
    }

    public bool validIntNumber(string data)
    {
        int valor;
        bool esNumero;
        esNumero = int.TryParse(data, out valor);
        if (!esNumero)
            Console.WriteLine("No valid Option");
        return esNumero;
    }

}
