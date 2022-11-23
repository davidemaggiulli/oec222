namespace GenericExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic List Test");

            IGenericList<int> list = new GenericList<int>(3);
            IGenericList<string> list2 = new GenericList<string>();
            //IGenericList<Foo> list3 = new GenericList<Foo,IFoo>();
            IGenericList<int> list4 = new StackGenericList<int>();


            for (int i = 0; i < 100; i++)
                list.Add(i);

            list.RemoveAt(10);
            list.RemoveAt(11);
            list.Remove(50);
   

            list2.Add("Io");
            list2.Add("sono");
            list2.Add("una");
            list2.Add("lista");
            list2.Add("di");
            list2.Add("stringhe");


            //var casted = (StackGenericList<int>)list;
            bool isCastable = false;
            try
            {
                ((GenericList<string>)list2).GenericMethod(new DateTime(1987, 6, 27));
                isCastable = true;
            }
            catch (InvalidCastException)
            {
                isCastable = false;
            }
            if(list2 is GenericList<string>)
            {

            }
            if(list2 is string)
            {

            }
            try
            {
                var list3 = list2 as GenericList<string>;
                var list5 = list2 as GenericList<int>;
                decimal xx = 10;
                var x = xx as int?;

            }catch(InvalidCastException e1)
            {

            }catch(Exception e2)
            {

            }


            list4 = list;


            Console.ReadLine();

        }
    }
}