using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.BaseApplication.DataHandle;

namespace BankDirectConnection.UTest.Domain
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rt1 = Instruction.NewInsSid("01");
            var rt2 = Instruction.NewInsSid("02");
            var test = Instruction.GetTimestamp().Substring(10-8);
            var test1 = Instruction.GetTimestamp();
            Console.WriteLine(test);
            Console.WriteLine(test1);
            Console.WriteLine(rt1);
            Console.WriteLine(rt2);
            Random rd = new Random();
            var rt3 = rd.Next(1, 3);
            Console.WriteLine(rt3);
            var rt4 = rd.Next(1, 3);
            Console.WriteLine(rt4);
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(Instruction.NewInsSid("01"));
            }
        }
    }
}
