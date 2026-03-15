using System;


public interface IPaymentMethod
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} with Credit Card"); //Added :C for auto currency shown
    }
}

public class CryptoPayment : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} with Crypto");
    }
}

//Previous Work before Generic was implamented
// public interface IReceiptSender
// {
//     void SendReceipt(string email, decimal amount);
// }

// public class EmailReceiptSender : IReceiptSender
// {
//     public void SendReceipt(string email, decimal amount)
//     {
//         Console.WriteLine($"Receipt for {amount:C} sent to {email}"); //Followed the same process for the email receipt. I wanted to keep them seperate for SOLID, but felt that the current examples on the slide were inelligent. 
//     }
// }

public class ReceiptSender<T>
{
    public void SendReceipt(T recipient, decimal amount)
    {
        // Works for string (email), int (customer ID), etc.
        Console.WriteLine($"Receipt for {amount:C} sent to {recipient}");
    }
}

//Previous Work before Generic was implamented
// public class PaymentProcessor
// {
//     private readonly IReceiptSender receiptSender; //Reducing complexity. Readonly receipt for customer.

//     public PaymentProcessor(IReceiptSender receiptSender)
//     {
//         this.receiptSender = receiptSender;
//     }

//     public void ProcessPayment(IPaymentMethod method, decimal amount, string email) //I refuse to sign off on a payment processor that even has the ability to not send receipts to the customer. It is going into the main program. 
//     //Goods and Services Tax Act 1985.
//     {
//         method.Pay(amount);
//         receiptSender.SendReceipt(email, amount);
//     }
// }

public class PaymentProcessor<T>
{
    private readonly ReceiptSender<T> receiptSender;

    public PaymentProcessor(ReceiptSender<T> receiptSender)
    {
        this.receiptSender = receiptSender;
    }

    public void ProcessPayment(IPaymentMethod method, decimal amount, T recipient)
    {
        method.Pay(amount);
        receiptSender.SendReceipt(recipient, amount);
    }
}

//Previous work before task 4 generics were added.
// public class Program
// {
//     public static void Main()
//     {
//         // String recipient (email)
//         var emailSender = new ReceiptSender<string>();
//         var emailProcessor = new PaymentProcessor<string>(emailSender);

//         emailProcessor.ProcessPayment(new CreditCardPayment(), 100, "customer@example.com");
//         emailProcessor.ProcessPayment(new CryptoPayment(), 200, "customer@example.com");

//         Console.WriteLine(); // Spacer

//         // Int recipient (customer ID)
//         var idSender = new ReceiptSender<int>();
//         var idProcessor = new PaymentProcessor<int>(idSender);

//         idProcessor.ProcessPayment(new CreditCardPayment(), 300, 12345);
//         idProcessor.ProcessPayment(new CryptoPayment(), 400, 67890);
//     }
// }

public class Program
{
    static void Main()
    {
        // Test with int
        var intCollection = new SortedCollection<int>();
        intCollection.AddItem(50);
        intCollection.AddItem(10);
        intCollection.AddItem(30);
        Console.WriteLine("Sorted integers:");
        intCollection.PrintAll();

        Console.WriteLine();

        // Test with Transaction
        var transactionCollection = new SortedCollection<Transaction>();
        transactionCollection.AddItem(new Transaction { Amount = 200 });
        transactionCollection.AddItem(new Transaction { Amount = 100 });
        transactionCollection.AddItem(new Transaction { Amount = 150 });
        Console.WriteLine("Sorted transactions:");
        transactionCollection.PrintAll();
    }
}