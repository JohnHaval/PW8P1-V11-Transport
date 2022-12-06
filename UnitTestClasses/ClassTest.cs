using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Transports;
using Transports.Children;
using System.Diagnostics;
using TraceLib;

namespace UnitTestClasses
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void _1CarDeathSituationTest()
        {
            #region Тестирование новых фич класса для README
            MDTrace.GiveHeaderToReadme("README.md");
            MDTrace.GiveHorizontalSeparator();
            var numStrings = new string[3];
            numStrings.SetValue("Всего 6 тестов;", 0);
            numStrings.SetValue("Программа работает корректно;", 1);
            numStrings.SetValue("Тесты были снова усовершенствованы.", 2);
            MDTrace.GiveNumberStrings(numStrings);
            var headers = new string[2];
            headers.SetValue("Тест №", 0);
            headers.SetValue("Состояние", 1);
            var values = new string[4];
            #endregion

            Car car = new Car(100, 100, Transport.TransportControl.Hard, "MyCompany", true);
            car.DeathCarSituation();
            Assert.IsTrue(car.Control == Transport.TransportControl.Impossible);
            Assert.IsTrue(car.IsCrashed == true);
            Debug.Write("\nИнформация по классу:");
            MainTrace.ToTrace($"Управляемость:{car.Control}\nСостояние:{car.IsCrashed}\nТекущий комфорт:{car.Comfort}\nВладелец:{car.HasOwner}");
            MDTrace.TestResults.Add(true);//Условно добавлено (для демонстрации работы)
        }
        [TestMethod]
        public void _2BusElectroBusTest()
        {
            Bus bus = new Bus();
            bus.ElectroBusSetup(true);
            MainTrace.ToTrace($"Это электробус: {bus.IsElectroBus} (должен быть true)");
            Assert.IsTrue(bus.IsElectroBus);
            MDTrace.TestResults.Add(true);//Условно добавлено (для демонстрации работы)
            //#region Тестирование новых фич часть 2
            //values.SetValue($"Тест {TraceTransfer.Counter}", 0);
            //values.SetValue("Прошел", 1);
            //values.SetValue($"Тест {TraceTransfer.Counter + 1}", 2);
            //values.SetValue("Прошел", 3);
            //TraceTransfer.GiveStringsToTable(headers, values);
            //#endregion
        }
        [TestMethod]
        public void _3BusPlacesTest()
        {
            Bus bus = new Bus();
            bus.MaxPassengers = 100;
            bus += 10;
            MainTrace.ToTrace($"Текущее кол-во: {bus.CurrentPassengers}\nМаксимальное:{bus.MaxPassengers}\nСвободное:{bus.FreePlaces}");
            MDTrace.TestResults.Add(true);//Условно добавлено (для демонстрации работы)
        }
        [TestMethod]
        public void _4TruckSpaceTest()
        {
            Truck truck = new Truck();
            truck.MaxSpace = 100;
            truck += 10;
            MainTrace.ToTrace($"Текущая занятость: {truck.CurrentSpace}\nМаксимальное:{truck.GetMaxSpace()}\nСвободное:{truck.FreeSpace}");
            MDTrace.TestResults.Add(true);//Если все пройдено успешно
        }
        [TestMethod]
        public void _5TruckSpaceMustFalseTest()//Must False
        {
            Truck truck = new Truck();
            truck.MaxSpace = 5;
            try
            {
                truck += 10;
                MainTrace.ToTrace($"Текущая занятость: {truck.CurrentSpace}\nМаксимальное:{truck.GetMaxSpace()}\nСвободное:{truck.FreeSpace}");
                MDTrace.TestResults.Add(true);//Если все пройдено успешно
            }
            catch 
            {
                MDTrace.TestResults.Add(false);//Условно добавлено (для демонстрации работы)
                MainTrace.ToTrace($"Test {MainTrace.Counter + 1} - Превысить допустимое значение в грузовике невозможно!");
                throw new Exception();
            }
        }
        [TestMethod]
        public void _6TruckSpaceMustFalseWithLess0Test()//Must False
        {
            Truck truck = new Truck();
            truck.MaxSpace = 5;
            try
            {
                truck -= 10;
                MainTrace.ToTrace($"Текущая занятость: {truck.CurrentSpace}\nМаксимальное:{truck.GetMaxSpace()}\nСвободное:{truck.FreeSpace}");
                MDTrace.TestResults.Add(true);//Если все пройдено успешно
            }
            catch
            {
                //TraceTransfer.ToTrace($"Test {TraceTransfer.Counter + 1} - Отрицательное место в грузовике быть не может!");//Необходимо задать + 1, так как значение временно отстает
                //Или так
                MainTrace.ToTrace($"!Исключение! - Отрицательное место в грузовике быть не может!");
                MDTrace.TestResults.Add(false);//Тест не пройден
                MainTrace.ToReadme();
                throw new Exception();
            }
        }
    }
}
