using Program;

namespace Lab6Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EqualsWithSameOBjectRefferences()
        {
            Person first = new("Петров А.Н.", new DateTime(2000, 4, 12), "Москва","142526343");
            Person second = first;
            bool result = first.Equals(second);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualsWithSameOBjects()
        {
            Person first = new("Петров А.Н.", new DateTime(2000, 4, 12), "Москва", "142526343");
            Person second = new("Петров А.Н.", new DateTime(2000, 4, 12), "Москва", "142526343");
            bool result = first.Equals(second);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualsWithDifferentOBjects()
        {
            Person first = new("Петров А.Н.", new DateTime(2004, 1, 14), "Москва", "142526343");
            Person second = new("Иванов Р.Б.", new DateTime(2000,4,12), "Тирасполь", "523645967");
            bool result = first.Equals(second);
            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void GetHashCodeWithDifferentOBjects()
        {
            Person first = new("Петров А.Н.", new DateTime(2004, 1, 14), "Москва", "142526343");
            Person second = new("Иванов Р.Б.", new DateTime(2000, 4, 12), "Тирасполь", "523645967");
            bool result = first.GetHashCode() == second.GetHashCode();
            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void GetHashCodeWithSameOBjects()
        {
            Person first = new("Петров А.Н.", new DateTime(2004, 1, 14), "Москва", "142526343");
            Person second = new("Петров А.Н.", new DateTime(2004, 1, 14), "Москва", "142526343");
            bool result = first.GetHashCode() == second.GetHashCode();
            Assert.IsTrue(result);
        }
    }
}