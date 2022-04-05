namespace HalloDelegate
{
    delegate void SimpleDelegate();
    delegate void DelegateWithPara(string msg);
    delegate long CalcDelegate(int a, int b);

    internal class HalloDele
    {
        public HalloDele()
        {
            SimpleDelegate myDele = SimpleMethod;
            Action myAction = SimpleMethod;
            Action myActionAno = delegate () { Console.WriteLine("Hallo"); };
            Action myActionAno2 = () => { Console.WriteLine("Hallo"); };
            Action myActionAno3 = () => Console.WriteLine("Hallo");

            DelegateWithPara myDeleWithPara = MethodWithPara;
            Action<string> myActionWithPara = MethodWithPara;
            Action<string> myParaActionAno = delegate (string txt) { Console.WriteLine(txt); };
            Action<string> myParaActionAno2 = (string txt) => { Console.WriteLine(txt); };
            Action<string> myParaActionAno3 = (txt) => Console.WriteLine(txt);
            Action<string> myParaActionAno4 = x => Console.WriteLine(x);

            CalcDelegate myCalc = Minus;
            Func<int, int, long> myFuncCalc = Sum;
            Func<int, int, long> myCalcAno = delegate (int a, int b) { return a + b; };
            Func<int, int, long> myCalcAno2 = (int a, int b) => { return a + b; };
            Func<int, int, long> myCalcAno3 = (a, b) => { return a + b; };
            Func<int, int, long> myCalcAno4 = (a, b) => a + b;

            List<string> texts = new List<string>();

            texts.Where(x => x.StartsWith("b"));
            texts.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return b - a;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodWithPara(string text)
        {
            Console.WriteLine(text);
        }

        public void SimpleMethod()
        {
            Console.WriteLine("Hello");
        }
    }
}
