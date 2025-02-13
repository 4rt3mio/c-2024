namespace Task1
{
    public class PerformAction
    {
        public static int DoAction(int varPerformed)
        {
            if (varPerformed % 2 == 0)
            {
                varPerformed /= 2;
            }
            else
            {
                varPerformed += 3;
            }
            return varPerformed;
        }
        public static double DoAction(double varPerformed)
        {
            varPerformed += 3;
            return varPerformed;
        }
    }
}