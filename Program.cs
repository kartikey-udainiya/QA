using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

            var firstName = driver.FindElement(By.Name("First Name"));
            firstName.SendKeys("John");

            var lastName = driver.FindElement(By.Name("Last Name"));
            lastName.SendKeys("Doe");

            var email = driver.FindElement(By.Name("Email"));
            email.SendKeys("johndoe@gmail.com");
        
            Console.WriteLine("Fields filled successfully!");
            Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
