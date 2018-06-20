using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /*
    Reference - https://stackoverflow.com/questions/2019402/when-why-to-use-delegates 
     
    Explanation 1: I have 2 projects here which build my solution: Example2(FTP) and a SaveDatabase.

    So, our application starts by looking for any downloads and downloading the file(s) then it calls the SaveDatabase project.

    Now, our application needs to notify the FTP site when a file is saved to the database by uploading a file with Meta data (ignore why, it's a request from 
    the owner of the FTP site). The issue is at what point and how? We need a new method called NotifyFtpComplete() but in which of our projects should it be 
    saved too - FTP or SaveDatabase? Logically, the code should live in our FTP project. But, this would mean our NotifyFtpComplete will have to be triggered or, 
    it will have to wait until the save is complete, and then query the database to ensure it is in there. What we need to do is tell our SaveDatabase project to 
    call the NotifyFtpComplete() method direct but we can't; we'd get a ciruclar reference and the NotifyFtpComplete() is a private method. What a shame, this 
    would have worked. Well, it can.

    During our application's code, we would have passed parameters between methods, but what if one of those parameters was the NotifyFtpComplete method. Yup, we 
    pass the method, with all of the code inside as well. This would mean we could execute the method at any point, from any project. Well, this is what the 
    delegate is. This means, we can pass the NotifyFtpComplete() method as a parameter to our SaveDatabase() class. At the point it saves, it simply executes the 
    delegate.
    */


    public delegate void NotifyDelegate();

    public class Example2
    {
        private static string _notice = "Notified";
            
        public static void Start(Notify notificationDelegate)
        {
            //Note, this NotifyDelegate type is defined in the SaveToDatabase project
            NotifyDelegate nofityDelegate = new NotifyDelegate(NotifyIfComplete);
            SaveToDatabase sd = new SaveToDatabase();
            sd.Start(nofityDelegate);
            Console.ReadKey();
            notificationDelegate.Invoke("Example2 executed!");
        }

        /*this is the method which will be delegated - the only thing it has in common with the NofityDelegate is that it takes 0 parameters and that it 
        returns void. However, it is these 2 which are essential. It is really important to notice that it writes a variable which, due to no constructor, 
        has not yet been called (so _notice is not initialized yet). */
        private static void NotifyIfComplete()
        {
            Console.WriteLine(_notice);
        }
    }

    public class SaveToDatabase
    {
        public void Start(NotifyDelegate nd)
        {
            Console.WriteLine("Yes, I shouldn't write to the console from here, it's just to demonstrate the code executed.");
            Console.WriteLine("SaveToDatabase Complete");
            Console.WriteLine(" ");
            nd.Invoke();
        }
    }
}
