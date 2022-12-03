// See https://aka.ms/new-console-template for more information
using CASH_Masters_POS_App;

Console.Title = "Welcome to Masters POS App";
Console.WriteLine("Hello, World!");

//--Object service
Service service = new Service();
service.runLogic();


