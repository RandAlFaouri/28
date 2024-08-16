using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CAReflection
{


    internal class Program
    {
        
        private static void Main(string[] args)
        {
            Console.WriteLine("MemvberInfo");
            MemberInfo[] members=typeof(BankAccount).GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("FieldInfo");
            MemberInfo[] fields = typeof(BankAccount).GetFields( BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("PropertyInfo");
            MemberInfo[] properties  = typeof(BankAccount).GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine(property.GetGetMethod());
                Console.WriteLine(property );
            }
            Console.WriteLine("EventInfo");
            MemberInfo[] events = typeof(BankAccount).GetEvents();
            foreach (var e in events)
            {
                Console.WriteLine(e);
            }
            /*  BankAccount account = new BankAccount(" A123", "Rand F.", 1000);
              account.OnNegativeBalance += Account_OnNegativeBalance ;
              account.WithDraw(500);
              account.WithDraw(600);
              Console.WriteLine(account);*/

            /*  Console.Write("Enemy: ");

              do
              {
                  var input = "CAReflection." + Console.ReadLine();
                  object obj = null;
                  try
                  {
                      var aName =typeof(Program).Assembly.GetName().Name;
                      var enemy = Activator.CreateInstance("CAReflection", input);
                      obj = enemy.Unwrap();
                  }
                  catch
                  { }
                  switch (obj)
                  {
                      case Goon g:

                          Console.WriteLine(g);
                          break;
                      case Agar a:
                          Console.WriteLine(a);
                          break;
                      case Pixa p:
                          Console.WriteLine(p);
                          break;

                      default:
                          Console.WriteLine("Unkown enemy");
                          break;

                  }


              }
              while (true);*/
            //  Console.WriteLine(new Goon());
            /*
            int i = (int)Activator.CreateInstance(typeof(int));
            i = 3;
            DateTime dt=(DateTime)Activator.CreateInstance(typeof(DateTime),2021,01,01);
            Console.WriteLine(dt);*/

            /* var i = new Int32();
             i = 3; */
            /*Type t1 = DateTime.Now.GetType();//at runtime
            Console.WriteLine(t1);
            Type t2 = typeof(DateTime); //at compile time
            Console.WriteLine(t2);
            Console.WriteLine($"FullName: {t1.FullName}");//Namespace.TypeName
            Console.WriteLine($"Namespace: {t1.Namespace}");//Namespace
            Console.WriteLine($"Name: {t1.Name}");//Namespace
            Console.WriteLine($"BaseType: {t1.BaseType}");//Namespace
            Console.WriteLine($"IsPublic: {t1.IsPublic}");
            Console.WriteLine($"Assembly: {t1.Assembly}");
            Type t3 = typeof(int[,]);
            Console.WriteLine($"T3 Type:{t3.Name}");
            var nestedTypes = typeof(Employee).GetNestedTypes();
            for(int i=0;i<nestedTypes.Length;i++) 
            
            { 
            Console.WriteLine(nestedTypes[i]);
        } 
            var t4 = typeof(int);
            var interfaces = t4.GetInterfaces();
            for (int i = 0; i < interfaces.Length; i++)

            {
                Console.WriteLine(interfaces[i]);
            }*/



        }

        private static void Account_OnNegativeBalance(object? sender, EventArgs e)
        {
            var bankAccount = (BankAccount)sender;
            Console.WriteLine("NEGATIVE BALANCE!!!");
          
        }
    }
    /*  public class Goon
      {
          public override string ToString()
          {
              return $"{{Speed:{20}, HitPower: {13},Strength: {7}}}";
          }
      }
  public class Agar
  {
      public override string ToString()
      {
          return $"{{Speed:{23}, HitPower: {11},Strength: {12}}}";
      }

  }
      public class Pixa
      {
          public override string ToString()
          {
              return $"{{Speed:{25}, HitPower: {10},Strength: {9}}}";
          }
      }*/
    /* internal class Employee
     {
     }*/

    public class BankAccount
    {
        private string accountNo;
        private string holder;
        private decimal balance;
        public string AccountNo => accountNo;
        public string Holder => accountNo;
        public event EventHandler OnNegativeBalance; 
        public BankAccount(string accountNo, string holder, decimal balance)
        {
            this.accountNo = accountNo;
            this.holder = holder;
            this.balance = balance;
        }
        public void Deposit(decimal ammount)
        {
            this.balance += ammount;

        }
        public void WithDraw(decimal amount)
        {
            this.balance -= amount;
            if (this.balance < 0)
            {
                this.OnNegativeBalance.Invoke(this, null);
            }

        }
        public override string ToString()
        {
            return $"{{Account No.: {accountNo},Holder:{holder},Balance: ${balance}}}";
        }
    }
}