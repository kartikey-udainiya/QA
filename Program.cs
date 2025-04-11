using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

            // Fill main form
            driver.FindElement(By.Name("First Name")).SendKeys("Kartikey");
            driver.FindElement(By.Name("Last Name")).SendKeys("udainiya");
            driver.FindElement(By.Name("Email")).SendKeys("Kartikeyudainiya@gmail.com");

            // Switch to first iframe
            driver.SwitchTo().Frame(1);
            Console.WriteLine("Switched to outer iframe");
            driver.FindElement(By.Name("First Name")).SendKeys("Kartikey");
            driver.FindElement(By.Name("Last Name")).SendKeys("Udainiya");
            driver.FindElement(By.Name("Email")).SendKeys("kartikeyudainiya@gmail.com");

            // Switch to nested iframe inside first iframe
            IWebElement nestedIframe = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(nestedIframe);
            Console.WriteLine("Switched to nested iframe");
            driver.FindElement(By.Id("fname")).SendKeys("Kartikey");
            driver.FindElement(By.Id("lname")).SendKeys("Udainiya");
            driver.FindElement(By.Id("email")).SendKeys("kartikeyudainiya@gmail.com");

            // Switch to another level of nested iframe
            IWebElement nestedIframe2 = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(nestedIframe2);
            Console.WriteLine("Switched to nested iframe level 2");
            driver.FindElement(By.Id("fname")).SendKeys("Kartikey");
            driver.FindElement(By.Id("lname")).SendKeys("Udainiya");
            driver.FindElement(By.Id("email")).SendKeys("kartikeyudainiya@gmail.com");
            // Back to main content
            driver.SwitchTo().DefaultContent();
            Console.WriteLine("Switched back to default content");

            // Switch to iframe by ID and fill its form
            driver.SwitchTo().Frame("iframeId");
            Console.WriteLine("Switched to iframe by ID");
            driver.FindElement(By.Name("First Name")).SendKeys("Kartikey");
            driver.FindElement(By.Name("Last Name")).SendKeys("udainiya");
            driver.FindElement(By.Name("Email")).SendKeys("kartikeyudainiya@gmail.com");

            // Back to main again
            driver.SwitchTo().DefaultContent();
            Console.WriteLine("Switched back to default content");
    

            // Wait for a while to see the result
            Thread.Sleep(2000);

            // Switch back to the main content
            driver.SwitchTo().DefaultContent();
            Console.WriteLine("Switched back to default content");

            // create a javascript executor to access shadow DOM elements
             IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //now create a web element to access the shadow DOM element
            // First element (e.g., First Name)
            var firstNameElement = js.ExecuteScript("return document.querySelector('shadow-form > section > #fname')");
            if (firstNameElement == null) throw new NullReferenceException("First name element not found.");
            IWebElement firstName = (IWebElement)firstNameElement;
            js.ExecuteScript("arguments[0].setAttribute('value', 'kartikey')", firstName);

            // Second element (e.g., Last Name)
            var lastNameElement = js.ExecuteScript("return document.querySelector('shadow-form > section > #lname')");
            if (lastNameElement == null) throw new NullReferenceException("Last name element not found.");
            IWebElement lastName = (IWebElement)lastNameElement;
            js.ExecuteScript("arguments[0].setAttribute('value', 'udainiya')", lastName);

            // Third element (e.g., country)
            var selectElement = js.ExecuteScript("return document.querySelector('shadow-form > section > select')");
            if (selectElement == null) throw new NullReferenceException("Select element not found.");
            IWebElement select = (IWebElement)selectElement;
            js.ExecuteScript("arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))", select);

            // nested shadow DOM element
            var nestedFirstNameElement = js.ExecuteScript("return document.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedFirstNameElement == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName2 = (IWebElement)nestedFirstNameElement;
            string setValueScript2 = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript2, firstName2);

            var nestedLastNameElement = js.ExecuteScript("return document.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedLastNameElement == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName2 = (IWebElement)nestedLastNameElement;
            string setValueScript2LastName = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName, lastName2);

            var nestedSelectElement = js.ExecuteScript("return document.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedSelectElement == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect = (IWebElement)nestedSelectElement;
            string setValueScriptSelect = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect, nestedSelect);





            // nested shadow dom with level 3
            var nestedFirstNameElement2 = js.ExecuteScript("return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedFirstNameElement2 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName3 = (IWebElement)nestedFirstNameElement2;
            string setValueScript3 = "arguments[0].setAttribute('value', 'kartikey3')";
            js.ExecuteScript(setValueScript3, firstName3);

            var nestedLastNameElement2 = js.ExecuteScript("return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedLastNameElement2 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName3 = (IWebElement)nestedLastNameElement2;
            string setValueScript2LastName3 = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName3, lastName3);

            var nestedSelectElement2 = js.ExecuteScript("return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedSelectElement2 == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect2 = (IWebElement)nestedSelectElement2;
            string setValueScriptSelect2 = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect2, nestedSelect2);

            


            // nested shadow dom with level 4
            var nestedFirstNameElement3 = js.ExecuteScript("return document.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedFirstNameElement3 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName4 = (IWebElement)nestedFirstNameElement3;
            string setValueScript4 = "arguments[0].setAttribute('value', 'kartikey4')";
            js.ExecuteScript(setValueScript4, firstName4);

            var nestedLastNameElement4 = js.ExecuteScript("return document.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedLastNameElement4 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName4 = (IWebElement)nestedLastNameElement4;
            string setValueScript2LastName4 = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName4, lastName4);

              var nestedSelectElement3 = js.ExecuteScript("return document.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedSelectElement3 == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect3 = (IWebElement)nestedSelectElement3;
            string setValueScriptSelect3 = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect3, nestedSelect3);



            // nested shadow dom with level 5
            var nestedFirstNameElement4 = js.ExecuteScript("return document.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > input')");
            if (nestedFirstNameElement4 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName5 = (IWebElement)nestedFirstNameElement4;
            string setValueScript5 = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript5, firstName5);

            var nestedLastNameElement5 = js.ExecuteScript("return document.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedLastNameElement5 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName5 = (IWebElement)nestedLastNameElement5;
            string setValueScript2LastName5 = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName5, lastName5);

            var nestedSelectElement4 = js.ExecuteScript("return document.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedSelectElement4 == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect4 = (IWebElement)nestedSelectElement4;
            string setValueScriptSelect4 = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect4, nestedSelect4);

            
           
            // nested shadow dom with level 6
            var nestedFirstNameElement5 = js.ExecuteScript("return document.querySelector('nestedshadow-form6').shadowRoot.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedFirstNameElement5 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName6 = (IWebElement)nestedFirstNameElement5;
            string setValueScript6 = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript6, firstName6);

            var nestedLastNameElement6 = js.ExecuteScript("return document.querySelector('nestedshadow-form6').shadowRoot.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedLastNameElement6 == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName6 = (IWebElement)nestedLastNameElement6;
            string setValueScript2LastName6 = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName6, lastName6);

            var nestedSelectElement5 = js.ExecuteScript("return document.querySelector('nestedshadow-form6').shadowRoot.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedSelectElement5 == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect5 = (IWebElement)nestedSelectElement5;
            string setValueScriptSelect5 = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect5, nestedSelect5);
            
            // iframe inside shadow DOM
            var iframeElement = js.ExecuteScript("return document.querySelector('nestedshadow-iframe').shadowRoot.querySelector('#iframeId')");
            if (iframeElement == null)
            {
                throw new NullReferenceException("The iframe element was not found.");
            }
            IWebElement iframe = (IWebElement)iframeElement;

            driver.SwitchTo().Frame(iframe);
            Console.WriteLine("Switched to iframe inside shadow DOM");

            IWebElement firstNameInsideIframe = driver.FindElement(By.Id("fname"));
            firstNameInsideIframe.SendKeys("kartikey");
            IWebElement lastNameInsideIframe = driver.FindElement(By.Id("lname"));
            lastNameInsideIframe.SendKeys("udainiya");
            IWebElement emailInsideIframe = driver.FindElement(By.Id("email"));
            emailInsideIframe.SendKeys("kartikeyudainiya@gmai.com");
            Console.WriteLine("Filled field inside iframe successfully!");  

            driver.SwitchTo().Frame(1);  
            driver.FindElement(By.Name("First Name")).SendKeys("kartikey");
            driver.FindElement(By.Name("Last Name")).SendKeys("udainiya");
            driver.FindElement(By.Name("Email")).SendKeys("kartikeyudainiya@gmail.com");

            Console.WriteLine("Filled field inside iframe successfully!");

            IWebElement iframeNested = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/iframe"));
            Console.WriteLine("Switched to nested iframe inside shadow DOM");

            driver.SwitchTo().Frame(iframeNested);
            Console.WriteLine("Switched to nested iframe inside shadow DOM");

            IWebElement firstNameInsideNestedIframe = driver.FindElement(By.Id("fname"));   
            firstNameInsideNestedIframe.SendKeys("kartikey");
            IWebElement lastNameInsideNestedIframe = driver.FindElement(By.Id("lname"));
            lastNameInsideNestedIframe.SendKeys("udainiya");
            IWebElement emailInsideNestedIframe = driver.FindElement(By.Id("email"));
            emailInsideNestedIframe.SendKeys("kartikeyudainiya@gmail.com");
            Console.WriteLine("Filled field inside nested iframe successfully!");
    
             // Switch to another level of nested iframe
            IWebElement nestedIframe3 = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(nestedIframe3);
            Console.WriteLine("Switched to nested iframe level 2");
            driver.FindElement(By.Id("fname")).SendKeys("kartikey");
            driver.FindElement(By.Id("lname")).SendKeys("udainiya");
            driver.FindElement(By.Id("email")).SendKeys("kartikeyudainiya@gmail.com");

              driver.SwitchTo().ParentFrame(); 
              driver.SwitchTo().ParentFrame(); 
              driver.SwitchTo().ParentFrame(); 
              

            // switch to iframe with Id 
            driver.SwitchTo().Frame("iframeId");
            Console.WriteLine("Switched to nested iframe with Id inside shadow DOM");
            driver.FindElement(By.Id("fname")).SendKeys("Kartikey");
            driver.FindElement(By.Id("lname")).SendKeys("Udainiya");
            driver.FindElement(By.Id("email")).SendKeys("kartikeyudainiya@gmail.com");

             driver.SwitchTo().ParentFrame(); 
            
            var shadowDomInsideIframeInShadowDomFirstName = js.ExecuteScript("return document.querySelector('shadow-form >  section > #fname')");
            if (shadowDomInsideIframeInShadowDomFirstName == null)
            {
                throw new NullReferenceException("The shadow DOM element was not found.");
            }
            IWebElement firstNamesInsideShadowDom = (IWebElement)shadowDomInsideIframeInShadowDomFirstName;

              string setValueScriptForName = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScriptForName, firstNamesInsideShadowDom);

            var shadowDomInsideIframeInShadowDomLastName = js.ExecuteScript("return document.querySelector('shadow-form >  section > #lname')");
            if (shadowDomInsideIframeInShadowDomLastName == null)
            {
                throw new NullReferenceException("The shadow DOM element was not found.");
            }
            IWebElement lastNamesInsideShadowDom = (IWebElement)shadowDomInsideIframeInShadowDomLastName;
            string setValueScriptForNameLastName = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScriptForNameLastName, lastNamesInsideShadowDom);

            var shadowDomInsideIframeInShadowDomSelect = js.ExecuteScript("return document.querySelector('shadow-form >  section > select')");
            if (shadowDomInsideIframeInShadowDomSelect == null)
            {
                throw new NullReferenceException("The shadow DOM element was not found.");
            }
            IWebElement selectInsideShadowDom = (IWebElement)shadowDomInsideIframeInShadowDomSelect;
            string setValueScriptForNameSelect = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptForNameSelect, selectInsideShadowDom);

            Console.WriteLine("Filled field inside shadow DOM successfully!");


            // nested shadow DOM element inside iframe
            var nestedElementInsideIframeFirstName = js.ExecuteScript("return document.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedElementInsideIframeFirstName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName2InsideIframe = (IWebElement)nestedElementInsideIframeFirstName;
            string setValueScript2InsideIframe = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript2InsideIframe, firstName2InsideIframe);
           
           var nestedElementInsideIframeLastName = js.ExecuteScript("return document.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedElementInsideIframeLastName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName2InsideIframe = (IWebElement)nestedElementInsideIframeLastName;
            string setValueScript2LastNameInsideIframe = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastNameInsideIframe, lastName2InsideIframe);

            var nestedElementInsideIframeSelect = js.ExecuteScript("return document.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedElementInsideIframeSelect == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelectInsideIframe = (IWebElement)nestedElementInsideIframeSelect;
            string setValueScriptSelectInsideIframe = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelectInsideIframe, nestedSelectInsideIframe);

            Console.WriteLine("Filled field inside nested shadow DOM successfully!");

            // nested shadow dom with level 3 inside iframe
            var nestedElement2InsideIframeFirstName = js.ExecuteScript("return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedElement2InsideIframeFirstName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName3InsideIframe = (IWebElement)nestedElement2InsideIframeFirstName;
            string setValueScript3InsideIframe = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript3InsideIframe, firstName3InsideIframe);

            var nestedElement2InsideIframeLastName = js.ExecuteScript("return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedElement2InsideIframeLastName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName3InsideIframe = (IWebElement)nestedElement2InsideIframeLastName;
            string setValueScript2LastName3InsideIframe = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName3InsideIframe, lastName3InsideIframe);

            var nestedElement2InsideIframeSelect = js.ExecuteScript("return document.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedElement2InsideIframeSelect == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect2InsideIframe = (IWebElement)nestedElement2InsideIframeSelect;
            string setValueScriptSelect2InsideIframe = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect2InsideIframe, nestedSelect2InsideIframe);
            Console.WriteLine("Filled field inside nested shadow DOM successfully!");
   

            // nested shadow dom with level 4 inside iframe
            var nestedElement3InsideIframeFirstName = js.ExecuteScript("return document.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedElement3InsideIframeFirstName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName4InsideIframe = (IWebElement)nestedElement3InsideIframeFirstName;
            string setValueScript4InsideIframe = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript4InsideIframe, firstName4InsideIframe);

            var nestedElement3InsideIframeLastName = js.ExecuteScript("return document.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedElement3InsideIframeLastName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName4InsideIframe = (IWebElement)nestedElement3InsideIframeLastName;
            string setValueScript2LastName4InsideIframe = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName4InsideIframe, lastName4InsideIframe);

            var nestedElement3InsideIframeSelect = js.ExecuteScript("return document.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedElement3InsideIframeSelect == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect3InsideIframe = (IWebElement)nestedElement3InsideIframeSelect;
            string setValueScriptSelect3InsideIframe = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect3InsideIframe, nestedSelect3InsideIframe);
            Console.WriteLine("Filled field inside nested level 4 shadow DOM successfully!");

            // nested shadow dom with level 5 inside iframe
            var nestedElement4InsideIframeFirstName = js.ExecuteScript("return document.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedElement4InsideIframeFirstName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName5InsideIframe = (IWebElement)nestedElement4InsideIframeFirstName;
            string setValueScript5InsideIframe = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript5InsideIframe, firstName5InsideIframe);

            var nestedElement4InsideIframeLastName = js.ExecuteScript("return document.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");
            if (nestedElement4InsideIframeLastName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName5InsideIframe = (IWebElement)nestedElement4InsideIframeLastName;
            string setValueScript2LastName5InsideIframe = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName5InsideIframe, lastName5InsideIframe);

            var nestedElement4InsideIframeSelect = js.ExecuteScript("return document.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedElement4InsideIframeSelect == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect4InsideIframe = (IWebElement)nestedElement4InsideIframeSelect;
            string setValueScriptSelect4InsideIframe = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect4InsideIframe, nestedSelect4InsideIframe);
            Console.WriteLine("Filled field inside nested level 5 shadow DOM successfully!");

            // nested shadow dom with level 6 inside iframe
            var nestedElement5InsideIframeFirstName = js.ExecuteScript("return document.querySelector('nestedshadow-form6').shadowRoot.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #fname')");
            if (nestedElement5InsideIframeFirstName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement firstName6InsideIframe = (IWebElement)nestedElement5InsideIframeFirstName;
            string setValueScript6InsideIframe = "arguments[0].setAttribute('value', 'kartikey')";
            js.ExecuteScript(setValueScript6InsideIframe, firstName6InsideIframe);

            var nestedElement5InsideIframeLastName = js.ExecuteScript("return document.querySelector('nestedshadow-form6').shadowRoot.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > #lname')");  
            if (nestedElement5InsideIframeLastName == null)
            {
                throw new NullReferenceException("The nested shadow DOM element was not found.");
            }
            IWebElement lastName6InsideIframe = (IWebElement)nestedElement5InsideIframeLastName;
            string setValueScript2LastName6InsideIframe = "arguments[0].setAttribute('value', 'udainiya')";
            js.ExecuteScript(setValueScript2LastName6InsideIframe, lastName6InsideIframe);

            var nestedElement5InsideIframeSelect = js.ExecuteScript("return document.querySelector('nestedshadow-form6').shadowRoot.querySelector('nestedshadow-form5').shadowRoot.querySelector('nestedshadow-form4').shadowRoot.querySelector('nestedshadow-form3').shadowRoot.querySelector('nestedshadow-form').shadowRoot.querySelector('shadow-form > section > select')");
            if (nestedElement5InsideIframeSelect == null)
            {
                throw new NullReferenceException("The nested select element was not found.");
            }
            IWebElement nestedSelect5InsideIframe = (IWebElement)nestedElement5InsideIframeSelect;
            string setValueScriptSelect5InsideIframe = "arguments[0].value = 'India'; arguments[0].dispatchEvent(new Event('change'))";
            js.ExecuteScript(setValueScriptSelect5InsideIframe, nestedSelect5InsideIframe);
            Console.WriteLine("Filled field inside nested level 6 shadow DOM successfully!");

       
            Thread.Sleep(1000);

            Console.WriteLine("Fields filled successfully!");
            Thread.Sleep(300000);
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
